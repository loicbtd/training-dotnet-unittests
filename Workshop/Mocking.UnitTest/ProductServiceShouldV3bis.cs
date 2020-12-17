using Mocking.Domain.Entities;
using Mocking.Domain.Services;
using Mocking.Infrastructure.Data;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;
using Mocking.Domain.Interfaces;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace Mocking.UnitTest
{
    public class ProductServiceShouldV3bis
    {
        [Fact]
        public void OnlyReturnProductsUnderPrice()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            
            var fakeProducts = fixture.Create <List<Product>>();
            
            var mockRepository = fixture.Freeze<Mock<IRepository<Product>>>(); // toujours une et unique valeur
            mockRepository.Setup(repo => repo.ListAll()).Returns(fakeProducts);

            var productService = fixture.Create<ProductService>();

            var fakePrice = fixture.Create<int>();
            
            // Act
            var result = productService.ListAllProductsUnderPrice(fakePrice);

            // Assert
            Assert.DoesNotContain(result, product => product.Price >= fakePrice);
        }
    }
}
