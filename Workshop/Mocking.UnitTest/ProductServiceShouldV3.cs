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

namespace Mocking.UnitTest
{
    public class ProductServiceShouldV3
    {
        [Fact]
        public void OnlyReturnProductsUnderPrice()
        {
            // Arrange
            var fixture = new Fixture();
            var fakeProducts = fixture.Create <List<Product>>();

            var mockRepository = new Mock<IRepository<Product>>();
            var productService = new ProductService(mockRepository.Object);

            mockRepository.Setup(repo => repo.ListAll()).Returns(fakeProducts);

            // Act
            var result = productService.ListAllProductsUnderPrice(20);

            // Assert
            Assert.DoesNotContain(result, product => product.Price >= 20);
        }
    }
}
