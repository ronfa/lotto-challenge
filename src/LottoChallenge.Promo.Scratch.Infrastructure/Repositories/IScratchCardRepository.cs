using LottoChallenge.Promo.Scratch.Domain.Models;

namespace LottoChallenge.Promo.Scratch.Infrastructure.Repositories;

public interface IScratchCardRepository
{
    Task SaveAsync(ScratchCard obj, CancellationToken cancellationToken = default);
}