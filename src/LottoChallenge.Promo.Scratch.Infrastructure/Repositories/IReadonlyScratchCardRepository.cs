using LottoChallenge.Promo.Scratch.Infrastructure.ViewModels;

namespace LottoChallenge.Promo.Scratch.Infrastructure.Repositories;

public interface IReadonlyScratchCardRepository
{
    Task<ScratchCardViewModel?> GetAsync(int promoId, int scratchCardId, CancellationToken cancellationToken);
    public Task<IList<ScratchCardViewModel>> GetListAsync(int promoId, CancellationToken cancellationToken);
}