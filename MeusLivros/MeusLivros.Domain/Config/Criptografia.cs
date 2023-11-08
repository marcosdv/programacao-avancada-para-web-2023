using System.Security.Cryptography;
using System.Text;

namespace MeusLivros.Domain.Config;

public class Criptografia
{
    #region | AES |

    private byte[] Key = Encoding.ASCII.GetBytes("!QAZ2WSX#EDC4RFV");
    private byte[] IV = Encoding.ASCII.GetBytes("5TGB&YHN7UJM(IK<");

    public string AesEncrypt(string texto)
    {
        //objeto que recebera os dados resultantes da criptografia
        byte[] encrypted;

        //Criando o objeto do Algoritmo de criptografia do AES
        using (var aesAlg = Aes.Create())
        {
            //Configurando o AES com a Chave e IV
            aesAlg.Key = Key;
            aesAlg.IV = IV;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            //Criando o encriptador baseado no algoritmo configurado
            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            //objeto para manipulacao de dados em memoria
            using (var memoryStream = new MemoryStream())
            {
                //objeto para manipulacao de dados criptografados em memoria
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    //Objeto que vai escrever na memoria cryptoStream
                    using (var stremWriter = new StreamWriter(cryptoStream))
                    {
                        //efetuanto a criptografia do texto
                        stremWriter.Write(texto);
                    }
                    //recuperando o valor criptografado da memoria
                    encrypted = memoryStream.ToArray();
                }
            }
        }

        //convertendo para string e retornando para o metodo
        return Convert.ToBase64String(encrypted);
    }

    public string AesDecrypt(string texto)
    {
        string retorno = "";

        byte[] textoCipher = Convert.FromBase64String(texto);

        //Criando o objeto do Algoritmo de criptografia do AES
        using (var aesAlg = Aes.Create())
        {
            //Configurando o AES com a Chave e IV
            aesAlg.Key = Key;
            aesAlg.IV = IV;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            //Criando o decriptador baseado no algoritmo configurado
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            //objeto para manipulacao de dados em memoria
            using (var memoryStream = new MemoryStream(textoCipher))
            {
                //objeto para manipulacao de dados criptografados em memoria
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (var stremReader = new StreamReader(cryptoStream))
                    {
                        retorno = stremReader.ReadToEnd();
                    }
                }
            }
        }

        return retorno;
    }

    #endregion

    #region | MD5 |

    public string MD5Encrypt(string texto)
    {
        var md5 = MD5.Create();

        byte[] dados = md5.ComputeHash(Encoding.UTF8.GetBytes(texto));

        var retorno = new StringBuilder();
        for (int i = 0; i < dados.Length; i++)
        {
            retorno.Append(dados[i].ToString("x2"));
        }

        return retorno.ToString();
    }

    #endregion
}