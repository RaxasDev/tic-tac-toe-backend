using MediatR;

namespace Application.Queries.Player.GetAllPlayers;

public class GetAllPlayersQueryInput : IRequest<List<GetAllPlayersViewModel>>;