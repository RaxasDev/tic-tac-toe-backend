namespace Domain.Models;

public class Player : BaseEntity
{
    public string Name { get; private set; }

    Player(string name)
    {
        Name = name;
    }
}