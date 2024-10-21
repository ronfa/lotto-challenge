using LottoChallenge.Promo.Scratch.Infrastructure.ViewModels;

namespace LottoChallenge.Promo.Scratch.Application.Requests;

public class ScratchCardRequest
{
    public int PromoId { get; set; }
    public int ScratchCardId { get; set; }
}