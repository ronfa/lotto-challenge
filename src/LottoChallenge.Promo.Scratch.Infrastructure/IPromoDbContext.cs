using LottoChallenge.Promo.Scratch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LottoChallenge.Promo.Scratch.Infrastructure;

public interface IPromoDbContext
{
    DbSet<ScratchCard> ScratchCards { get; set; }
    
    DatabaseFacade Database { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}