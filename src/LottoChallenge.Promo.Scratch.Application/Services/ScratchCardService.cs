using LottoChallenge.Promo.Scratch.Application.Requests;
using LottoChallenge.Promo.Scratch.Application.Responses;
using LottoChallenge.Promo.Scratch.Domain.Models;
using LottoChallenge.Promo.Scratch.Infrastructure.Repositories;

namespace LottoChallenge.Promo.Scratch.Application.Services;

public class ScratchCardService(IReadonlyScratchCardRepository readonlyRepo, IScratchCardRepository repository) : IScratchCardService
{
    public async Task<ScratchCardResponse> ScratchCardAsync(ScratchCardRequest request, CancellationToken cancellationToken)
    {
        var response = new ScratchCardResponse();
        var item = await readonlyRepo.GetAsync(request.PromoId, request.ScratchCardId, cancellationToken);

        if (item == null)
        {
            return new ScratchCardResponse(false, $"Scratch card with id {request.PromoId} was not found");
        }

        if (item.Scratched)
        {
            return new ScratchCardResponse(false, $"Scratch card with id {request.ScratchCardId} already scratched");
        }
        
        item.Scratched = true;
        
        await repository.SaveAsync(new ScratchCard
        {
            Id = item.Id,
            Scratched = true,
            Name = item.Name,
            Reward = item.Reward
        }, cancellationToken);
        
        return new ScratchCardResponse(
            true, 
            $"Scratch card with id {request.ScratchCardId} scratched successfully",
            await readonlyRepo.GetAsync(request.PromoId, request.ScratchCardId, cancellationToken));
    }
}