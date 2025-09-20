using Domain.Interfaces;

namespace Domain.Models;

public class Player : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    private readonly List<GameMatch> _gameMatchesAsX = new();
    public IReadOnlyCollection<GameMatch> GameMatchesAsX => _gameMatchesAsX;
    private readonly List<GameMatch> _gameMatchesAsO = new();
    public IReadOnlyCollection<GameMatch> GameMatchesAsO => _gameMatchesAsO;

    protected Player()
    {
    }

    Player(string name)
    {
        Name = name;
    }
}