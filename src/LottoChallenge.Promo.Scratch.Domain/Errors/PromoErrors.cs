namespace LottoChallenge.Promo.Scratch.Domain.Errors;

public static class PromoErrors
{
    public static Error NotFound(int promoId) => new(
        "Promo.NotFound", $"The promotion with Id = '{promoId}' was not found");
}
