using LottoChallenge.Promo.Scratch.Application.Requests;
using LottoChallenge.Promo.Scratch.Application.Responses;

namespace LottoChallenge.Promo.Scratch.Application.Services;

public interface IScratchCardService
{
    Task<ScratchCardResponse> ScratchCardAsync(ScratchCardRequest request, CancellationToken cancellationToken);
}