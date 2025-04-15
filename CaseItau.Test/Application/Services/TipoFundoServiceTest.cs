using AutoMapper;
using CaseItau.API.Domain.Entities;
using CaseItau.Application.Services;
using CaseItau.Infrastructure.Repositories;
using CaseItau.Shared.Dtos;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CaseItau.Test.Application.Services
{
    public class TipoFundoServiceTest
    {
        private readonly Mock<ITipoFundoRepository> _mockTipoFundoRepository;
        private readonly Mock<IMapper> _mockMapper;

        public TipoFundoServiceTest()
        {
            _mockTipoFundoRepository = new Mock<ITipoFundoRepository>();
            _mockMapper = new Mock<IMapper>();

            _mockTipoFundoRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<TipoFundoEntity>());
        }

        [Fact]
        public async void GetAllAsyncShouldReturnTipoFundoDto()
        {
            TipoFundoService service = new TipoFundoService(_mockTipoFundoRepository.Object, _mockMapper.Object);
            IEnumerable<TipoFundoDto> result = await service.GetAllAsync();

            Assert.IsType<TipoFundoDto[]>(result);
        }

        [Fact]
        public async void GetAllAsyncShouldReturnTipoFundoDtoList()
        {
            _mockMapper.Setup(x => x.Map<IEnumerable<TipoFundoDto>>(It.IsAny<IEnumerable<TipoFundoEntity>>())).Returns(new List<TipoFundoDto>());

            TipoFundoService service = new TipoFundoService(_mockTipoFundoRepository.Object, _mockMapper.Object);
            IEnumerable<TipoFundoDto> result = await service.GetAllAsync();

            Assert.IsType<List<TipoFundoDto>>(result);
        }
    }
}
