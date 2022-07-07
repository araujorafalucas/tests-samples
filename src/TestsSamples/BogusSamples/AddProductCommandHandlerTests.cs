using Bogus;
using Domain.CommandHandlers;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace BogusSamples
{
    public class AddProductCommandHandlerTests
    {
        [Fact]
        public void ValidProduct_AddIsCalled_ReturnTrue()
        {

            var productRepository = Substitute.For<IProductsRepository>();

            var addProductCommandHandler = new AddProductCommandHandler(productRepository);

            var product = new Faker<Product>("en_US")
                .RuleFor(p => p.Id, f => f.Random.Int(0, 10000))
                .RuleFor(p => p.Name, f => f.Name.FindName()).Generate();


            var result = addProductCommandHandler.Handle(product);

            result.Sucess.Should().BeTrue();

        }

        [Fact]
        public void InvalidProduct_AddIsCalled_ReturnFalse()
        {
            var produtctRepository = Substitute.For<IProductsRepository>();

            var addProductCommandHandler = new AddProductCommandHandler(produtctRepository);

            var product = new Faker<Product>("en_US")
                .RuleFor(p => p.Id, f => f.Random.Int(0, 100)).Generate();


            product.Name = null;

            var result = addProductCommandHandler.Handle(product);

            result.Sucess.Should().BeFalse();

        }
    }
}