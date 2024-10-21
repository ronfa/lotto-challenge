using Xunit;
using AutoFixture;
using FluentAssertions;
using LottoChallenge.Promo.Scratch.Api.Controllers;
using LottoChallenge.Promo.Scratch.Application.Requests;
using LottoChallenge.Promo.Scratch.Application.Responses;
using LottoChallenge.Promo.Scratch.Application.Services;
using LottoChallenge.Promo.Scratch.Domain.Models;
using LottoChallenge.Promo.Scratch.Infrastructure.Repositories;
using LottoChallenge.Promo.Scratch.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace LottoChallenge.Promo.Scratch.Tests;

public class ScratchcardControllerTests
{
    private readonly Fixture _fixture;
    private readonly IReadonlyScratchCardRepository _readOnlyRepo;
    private readonly IScratchCardRepository _repo;
    private readonly IScratchCardService _service;
    private readonly ScratchcardController _controller;

    public ScratchcardControllerTests()
    {
        _fixture = new Fixture();
        _readOnlyRepo = Substitute.For<IReadonlyScratchCardRepository>();
        _repo = Substitute.For<IScratchCardRepository>();
        _controller = new ScratchcardController(Substitute.For<ILogger<ScratchcardController>>(), _readOnlyRepo, new ScratchCardService(_readOnlyRepo, _repo))
        {
            ControllerContext = Substitute.For<ControllerContext>()
        };
        _controller.ControllerContext.HttpContext = Substitute.For<HttpContext>();
        
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllCards()
    {
        var promoId = _fixture.Create<int>();

        var viewModel = _fixture.Build<List<ScratchCardViewModel>>()
            .Create();
        
        _readOnlyRepo.GetListAsync(promoId, CancellationToken.None)
            .Returns(viewModel);

        var response = await _controller.Get(promoId, CancellationToken.None);
        
        response.Should().BeOfType<OkObjectResult>()
            .Subject.Value.Should().BeOfType<List<ScratchCardViewModel>>();

        await _readOnlyRepo
            .Received(1)
            .GetListAsync(promoId, Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task PostAsync_SavesScratchCard()
    {
        var request = _fixture.Create<ScratchCardRequest>();

        var viewModel = _fixture.Build<ScratchCardViewModel>()
            .Create();
        
        _readOnlyRepo.GetAsync(request.PromoId, request.ScratchCardId, CancellationToken.None)
            .Returns(viewModel);

        _repo.SaveAsync(Arg.Any<ScratchCard>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        
        var response = await _controller.Post(request, CancellationToken.None);
        
        response.Should().BeOfType<OkObjectResult>()
            .Subject.Value.Should().BeOfType<ScratchCardResponse>();

        await _readOnlyRepo
            .Received(1)
            .GetAsync(request.PromoId, request.ScratchCardId, Arg.Any<CancellationToken>());
    }
}