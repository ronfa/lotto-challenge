using LottoChallenge.Promo.Scratch.Infrastructure.ViewModels;

namespace LottoChallenge.Promo.Scratch.Application.Responses;

public class ScratchCardResponse(bool success = false, string message = "", ScratchCardViewModel? scratchCard = null)
{
    public bool Success { get; set; } = success;
    public string Message { get; set; } = message;
    public ScratchCardViewModel? ScratchCard { get; set; } = scratchCard;
}