using AutoFixture.Xunit2;
using Domain.CommandHandlers;
using Domain.Entities;
using Domain.Repositories;
using NSubstitute;
using Xunit;
using FluentAssertions;
using AutoFixture;

namespace AutoFixtureSamples
{
    public class AddProductCommandHandlerTests
    {
        /// <summary>
        /// With AutoFixture.Xunit2
        /// </summary>
        /// <param name="product"></param>
        [Theory, AutoData]
        public void ValidProduct_AddIsCalled_ReturnsTrue_AutoData(Product product)
        {
            
            var productRepository = Substitute.For<IProductsRepository>();

            var addProductCommandHandler = new AddProductCommandHandler(productRepository);

            var result = addProductCommandHandler.Handle(product);

            result.Success.Should().BeTrue();
        }


        [Fact]
        public void ValidProduct_AddIsCalled_ReturnsTrue()
        {
            var product = new Fixture().Create<Product>();

            var productRepository = Substitute.For<IProductsRepository>();

            var addProductCommandHandler = new AddProductCommandHandler(productRepository);

            var result = addProductCommandHandler.Handle(product);

            result.Success.Should().BeTrue();
        }
    }
}