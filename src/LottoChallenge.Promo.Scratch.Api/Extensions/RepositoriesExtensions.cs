using LottoChallenge.Promo.Scratch.Infrastructure.Repositories;

namespace LottoChallenge.Promo.Scratch.Api.Extensions;

public static class RepositoriesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddScoped<IReadonlyScratchCardRepository, ReadOnlyScratchCardRepository>()
            .AddScoped<IScratchCardRepository, ScratchCardRepository>();
    }
}