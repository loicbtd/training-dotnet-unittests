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

namespace Mocking.UnitTest
{
    public class ProductServiceShouldV2
    {
        [Fact]
        public void OnlyReturnProductsUnderPrice()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            var productService = new ProductService(mockRepository.Object);

            var fakeProducts = new List<Product>
            {
                new Product { Price = 20, Description = "Burger" },
                new Product { Price = 5, Description = "Burger" },
                new Product { Price = 10, Description = "Burger" },
                new Product { Price = 15, Description = "Burger" },
                new Product { Price = 150, Description = "Bike" },
            };

            mockRepository.Setup(repo => repo.ListAll()).Returns(fakeProducts);

            // Act
            var result = productService.ListAllProductsUnderPrice(20);

            // Assert
            Assert.Equal(3, result.Count());
        }
    }
}
