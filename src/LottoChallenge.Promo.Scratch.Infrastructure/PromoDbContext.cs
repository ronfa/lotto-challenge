using LottoChallenge.Promo.Scratch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LottoChallenge.Promo.Scratch.Infrastructure;

public partial class PromoDbContext(DbContextOptions<PromoDbContext> options) : DbContext(options), IPromoDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ScratchCard>().HasKey(p => p.Id);
        modelBuilder.Entity<ScratchCard>().Property(p => p.Id).ValueGeneratedOnAdd();
        
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        // Ensure data exists when application starts
        modelBuilder.Entity<ScratchCard>().HasData(GenerateScratchCards().ToArray());
    }

    private static List<ScratchCard> GenerateScratchCards()
    {
        const int MaxCards = 10000;
        const int MaxConsolations = 100;

        var list = new List<ScratchCard>();

        Enumerable.Range(0, MaxCards).ToList().ForEach(i => list.Add(
            new ScratchCard
            {
                Name = $"Scratch {i + 1}",
                Id = i + 1,
                Scratched = false,
                Reward = "Sorry, try again!",
            }));
        
        // Set 1 random grand prize
        var winner = new Random().Next(MaxCards);
        list[winner].Reward = "Congratulations!!! You won the game!!!";
        
        // set 100 consolation prizes
        var prizes = new List<int>();
        while (prizes.Count < MaxConsolations)
        {
            var result = new Random().Next(MaxCards);
            if (prizes.Contains(result) || result == winner) 
                continue;
            list[result].Reward = "You win a consolation prize!";
            prizes.Add(result);
        }

        return list;
    }

    public DbSet<ScratchCard> ScratchCards { get; set; }
}

