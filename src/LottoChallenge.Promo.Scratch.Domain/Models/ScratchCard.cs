namespace LottoChallenge.Promo.Scratch.Domain.Models;

public class ScratchCard
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Scratched { get; set; }
    public string Reward { get; set; }
}