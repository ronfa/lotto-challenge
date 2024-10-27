using LottoChallenge.Promo.Scratch.Application.Requests;
using LottoChallenge.Promo.Scratch.Application.Services;
using LottoChallenge.Promo.Scratch.Domain.Errors;
using LottoChallenge.Promo.Scratch.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LottoChallenge.Promo.Scratch.Api.Controllers;

[Route("api/[controller]")]
public class ScratchcardController(
    ILogger<ScratchcardController> logger, 
    IReadonlyScratchCardRepository repository,
    IScratchCardService service)
    : ControllerBase
{
    [HttpGet("{promoId:int}")]
    public async Task<IActionResult> Get(int promoId, CancellationToken cancellationToken)
    {
        if (promoId <= 0)
        {
            return Problem(detail: PromoErrors.NotFound(promoId).Description);
        }

        var scratchCards = await repository.GetListAsync(promoId, cancellationToken);
        return Ok(scratchCards);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ScratchCardRequest request, CancellationToken cancellationToken)
    {
        // Scratch the card
        var response = await service.ScratchCardAsync(request, cancellationToken);
        return Ok(response);
    }
}