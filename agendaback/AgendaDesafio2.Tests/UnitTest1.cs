using AgendaDesafio2.Services;
using AgendaDesafioAPI.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using AgendaDesafioAPI.Models;

namespace AgendaDesafio2.Tests
{
    public class UnitTest1
    {
        private readonly IAgendaService agendaService;
        private IMapper _mapper;
        private readonly AgendaController _controller;
        
        public UnitTest1() {

            agendaService = Substitute.For<IAgendaService>();
            _mapper = Substitute.For<IMapper>();
            _controller = new AgendaController(agendaService, _mapper);


        }
        
        [Fact]
        public async Task Get_Ok()
        {
            // Arrange
            var agenda = AgendaTestes.Generate();
            agendaService.GetAllAsync().Returns(new List<Agenda> { agenda });

            // Act
            var resultado = (ObjectResult)await _controller.GetAllAsync();

            // Assert
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);

        }

        [Fact]
        public async Task GetById_Ok()
        {
            // Arrange
            var agenda = AgendaTestes.Generate();
            agendaService.GetByIdAsync(agenda.Id).Returns(Task.FromResult(agenda));

            // Act
            var actionResult = await _controller.GetByIdAsync(agenda.Id);

            // Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            var resultado = actionResult.Result as OkObjectResult;
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            var resultAgenda = resultado.Value as Agenda;
            resultAgenda.Should().NotBeNull();
            resultAgenda.Id.Should().Be(agenda.Id);
        }

        [Fact]
        public async Task Post_Ok()
        {
            // Arrange
            var agenda = AgendaTestes.Generate();
            agendaService.CreateAsync(Arg.Any<Agenda>()).Returns(Task.CompletedTask);

            // Act
            var actionResult = await _controller.CreateAsync(agenda);

            // Assert
            actionResult.Should().BeOfType<OkObjectResult>();
            var resultado = actionResult as OkObjectResult;
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().Be("Contato criado!");
        }

        [Fact]
        public async Task Delete_Ok()
        {
            // Arrange
            var agendaId = AgendaTestes.Generate().Id;
            agendaService.DeleteAsync(agendaId).Returns(Task.CompletedTask);

            // Act
            var resultado = (StatusCodeResult)await _controller.DeleteAsync(agendaId);

            // Assert
            resultado.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }
    }
}