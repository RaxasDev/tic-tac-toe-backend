using Domain.Models.Enum;

namespace Application.Dto;

public record CreatePlayerMatchDto(
    string PlayerXName,
    string PlayerOName,
    int MovementsX,
    int MovementsO,
    WinnerSideEnum WinnerSide
);