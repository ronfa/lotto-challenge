using LottoChallenge.Promo.Scratch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LottoChallenge.Promo.Scratch.Infrastructure.Repositories;

public class ScratchCardRepository(ILogger<ReadOnlyScratchCardRepository> logger, IPromoDbContext dbContext) : IScratchCardRepository
{
    public async Task SaveAsync(ScratchCard obj, CancellationToken cancellationToken = default)
    {
        if (obj.Id > 0)
        {
            var scratchCard = await dbContext.ScratchCards.FindAsync(obj.Id, cancellationToken);
            if (scratchCard != null)
            {
                scratchCard.Scratched = obj.Scratched;
            }
        }
        else
        {
            await dbContext.ScratchCards.AddAsync(obj, cancellationToken);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}