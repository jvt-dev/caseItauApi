using System.Collections.Generic;
using AutoMapper;
using CaseItau.API.Domain.Entities;
using CaseItau.API.Infrastructure.Repositories;
using CaseItau.API.Shared.Dtos;
using CaseItau.Application.Exceptions;
using CaseItau.Application.Services;
using Moq;
using Xunit;

namespace CaseItau.Test.Application.Services
{
    public class FundoServiceTest
    {
        private readonly Mock<IFundoRepository> _mockFundoRepository;
        private readonly Mock<IMapper> _mockMapper;

        public FundoServiceTest()
        {
            _mockFundoRepository = new Mock<IFundoRepository>();
            _mockMapper = new Mock<IMapper>();

            _mockFundoRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<FundoEntity>());
            _mockFundoRepository.Setup(x => x.GetEntityByIdAsync(It.IsAny<string>())).ReturnsAsync(new FundoEntity());
        }

        [Fact]
        public async void GetAllAsyncShouldReturnFundoDto()
        {
            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            var result = await service.GetAllAsync();

            Assert.IsType<FundoDto[]>(result);
        }

        [Fact]
        public async void GetAllAsyncShouldReturnFundoDtoList()
        {
            _mockMapper.Setup(x => x.Map<IEnumerable<FundoDto>>(It.IsAny<IEnumerable<FundoEntity>>())).Returns(new List<FundoDto>());

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            var result = await service.GetAllAsync();

            Assert.IsType<List<FundoDto>>(result);
        }

        [Fact]
        public async void GetByIdAsyncShouldReturnFundoDto()
        {
            _mockMapper.Setup(x => x.Map<FundoDto>(It.IsAny<FundoEntity>())).Returns(new FundoDto());

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            var result = await service.GetByIdAsync("teste");

            Assert.IsType<FundoDto>(result);
        }

        [Fact]
        public async void GetByIdAsyncShouldThrowNotFoundException()
        {
            _mockFundoRepository.Setup(x => x.GetEntityByIdAsync(It.IsAny<string>())).ReturnsAsync((FundoEntity)null);

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            await Assert.ThrowsAsync<NotFoundException>(async () => await service.GetByIdAsync("teste"));
        }

        [Fact]
        public async void PutAsyncShouldThrowNotFoundException()
        {
            _mockFundoRepository.Setup(x => x.GetEntityByIdAsync(It.IsAny<string>())).ReturnsAsync((FundoEntity)null);

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            await Assert.ThrowsAsync<NotFoundException>(async () => await service.PutAsync("teste", It.IsAny<FundoDto>()));
        }

        [Fact]
        public async void PutAsyncShouldReturnTrue()
        {
            _mockFundoRepository.Setup(x => x.GetEntityByIdAsync(It.IsAny<string>())).ReturnsAsync(new FundoEntity());
            _mockFundoRepository.Setup(x => x.UpdateAsync(It.IsAny<FundoEntity>())).ReturnsAsync(1);

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            var result = await service.PutAsync("teste", new FundoDto());
            Assert.True(result);
        }

        [Fact]
        public async void PostAsyncShouldReturnTrue()
        {
            _mockFundoRepository.Setup(x => x.GetEntityByIdAsync(It.IsAny<string>())).ReturnsAsync(new FundoEntity());
            _mockFundoRepository.Setup(x => x.CreateAsync(It.IsAny<FundoEntity>())).ReturnsAsync(1);

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            var result = await service.PostAsync(new FundoDto());
            Assert.True(result);
        }

        [Fact]
        public async void DeleteAsyncShouldThrowNotFoundException()
        {
            _mockFundoRepository.Setup(x => x.GetEntityByIdAsync(It.IsAny<string>())).ReturnsAsync((FundoEntity)null);

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            await Assert.ThrowsAsync<NotFoundException>(async () => await service.DeleteAsync("teste"));
        }

        [Fact]
        public async void DeleteAsyncShouldReturnTrue()
        {
            _mockFundoRepository.Setup(x => x.GetEntityByIdAsync(It.IsAny<string>())).ReturnsAsync(new FundoEntity());
            _mockFundoRepository.Setup(x => x.DeleteAsync(It.IsAny<FundoEntity>())).ReturnsAsync(1);

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            var result = await service.DeleteAsync("teste");
            Assert.True(result);
        }

        [Fact]
        public async void MovimentarPatrimonioAsyncShouldThrowNotFoundException()
        {
            _mockFundoRepository.Setup(x => x.GetEntityByIdAsync(It.IsAny<string>())).ReturnsAsync((FundoEntity)null);

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            await Assert.ThrowsAsync<NotFoundException>(async () => await service.PutAsync("teste", It.IsAny<FundoDto>()));
        }

        [Fact]
        public async void MovimentarPatrimonioAsyncShouldReturnTrue()
        {
            _mockFundoRepository.Setup(x => x.GetEntityByIdAsync(It.IsAny<string>())).ReturnsAsync(new FundoEntity());
            _mockFundoRepository.Setup(x => x.UpdateAsync(It.IsAny<FundoEntity>())).ReturnsAsync(1);

            var service = new FundoService(_mockFundoRepository.Object, _mockMapper.Object);
            var result = await service.PutAsync("teste", new FundoDto());
            Assert.True(result);
        }
    }
}
