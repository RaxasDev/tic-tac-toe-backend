namespace Application.Queries.Player.GetAllPlayers;

public class GetAllPlayersViewModel
{
    public string Name { get; private set; }

    GetAllPlayersViewModel(string name)
    {
        Name = name;
    }
}