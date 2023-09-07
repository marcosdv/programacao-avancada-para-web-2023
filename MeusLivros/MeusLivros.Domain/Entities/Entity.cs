namespace MeusLivros.Domain.Entities;

public class Entity : IEquatable<Entity>
{
    public int Id { get; set; }

    public bool Equals(Entity? other)
    {
        return this.Id == other?.Id;
    }
}