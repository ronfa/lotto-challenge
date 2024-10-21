using LottoChallenge.Promo.Scratch.Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LottoChallenge.Promo.Scratch.Infrastructure.Repositories;
public class ReadOnlyScratchCardRepository(ILogger<ReadOnlyScratchCardRepository> logger, IPromoDbContext dbContext)
    : IReadonlyScratchCardRepository
{
    public async Task<ScratchCardViewModel?> GetAsync(int promoId, int scratchCardId, CancellationToken cancellationToken)
    {
        var result = from scratchCard in dbContext.ScratchCards
            where scratchCard.Id == scratchCardId
            select new ScratchCardViewModel
            {
                Name = scratchCard.Name,
                Id = scratchCard.Id,
                Reward = scratchCard.Reward,
                Scratched = scratchCard.Scratched
            };

        return await result.FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<IList<ScratchCardViewModel>> GetListAsync(int promoId, CancellationToken cancellationToken)
    {
        var result = from scratchCard in dbContext.ScratchCards
            select new ScratchCardViewModel
            {
                Name = scratchCard.Name,
                Id = scratchCard.Id,
                Reward = scratchCard.Reward,
                Scratched = scratchCard.Scratched
            };

        return await result.ToListAsync(cancellationToken: cancellationToken);
    }
}