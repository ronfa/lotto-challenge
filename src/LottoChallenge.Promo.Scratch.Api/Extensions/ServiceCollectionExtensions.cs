using LottoChallenge.Promo.Scratch.Application.Services;

namespace LottoChallenge.Promo.Scratch.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddScoped<IScratchCardService, ScratchCardService>();
    }
    
}