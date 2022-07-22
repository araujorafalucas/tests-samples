using AutoFixture;
using Domain.CommandHandlers;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AutoFixtureSamples;

public class UpdateProductCommandHandlerTests
{

    [Fact]
    public void ExistingProduct_UpdateIsCalled_ReturnsTrue()
    {
        var productRepository = Substitute.For<IProductsRepository>();

        var product = new Fixture().Create<Product>();

        productRepository.Get(product.Id).Returns(new Product());

        var updateProductCommandHandler = new UpdateProductCommandHandler(productRepository);

        var result = updateProductCommandHandler.Handle(product);

        result.Success.Should().BeTrue();
    }


    [Fact]
    public void NonExistingProduct_UpdateIsCalled_ReturnsTrue()
    {
        var productRepository = Substitute.For<IProductsRepository>();

        var product = new Fixture().Create<Product>();

        productRepository.Get(product.Id).Returns(null as Product);

        var updateProductCommandHandler = new UpdateProductCommandHandler(productRepository);

        var result = updateProductCommandHandler.Handle(product);

        result.Success.Should().BeFalse();
    }

}
