using MediatR;

namespace Application.Queries.Player.GetAllPlayers;

public class GetAllPlayersQueryHandler
    : IRequestHandler<GetAllPlayersQueryInput, List<GetAllPlayersViewModel>>
{
    public async Task<List<GetAllPlayersViewModel>> Handle(
        GetAllPlayersQueryInput request, 
        CancellationToken cancellationToken
    )
    {
        await SimulateDelayAsync();
        
        return new List<GetAllPlayersViewModel>();
    }
    
    private async Task SimulateDelayAsync()
    {
        await Task.Delay(1500);
    }
}