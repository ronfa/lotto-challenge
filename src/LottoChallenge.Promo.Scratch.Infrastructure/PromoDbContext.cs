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
        var list = new List<ScratchCard>();

        Enumerable.Range(0, 100).ToList().ForEach(i => list.Add(
            new ScratchCard
            {
                Name = $"Scratch {i + 1}",
                Id = i + 1,
                Scratched = false,
                Reward = "Sorry, try again!",
            }));
        
        // Set 1 random grand prize
        var winner = new Random().Next(100);
        list[winner].Reward = "Congratulations!!! You won the game!!!";
        
        // set 5 consolation prizes
        var prizes = new List<int>();
        while (prizes.Count < 5)
        {
            var result = new Random().Next(100);
            if (prizes.Contains(result) || result == winner) 
                continue;
            list[result].Reward = "You win a consolation prize!";
            prizes.Add(result);
        }

        return list;
    }

    public DbSet<ScratchCard> ScratchCards { get; set; }
}

