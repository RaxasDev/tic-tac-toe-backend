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

    public Player(string name)
    {
        Name = name;
    }

    public void AddGameMatchAsX(GameMatch gameMatch)
    {
        _gameMatchesAsX.Add(gameMatch);
    }
    
    public void AddGameMatchAsO(GameMatch gameMatch)
    {
        _gameMatchesAsO.Add(gameMatch);
    }
}