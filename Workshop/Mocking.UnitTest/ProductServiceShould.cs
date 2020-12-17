using Mocking.Domain.Entities;
using Mocking.Domain.Services;
using Mocking.Infrastructure.Data;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mocking.UnitTest
{
    public class ProductServiceShould
    {
        // Integration Test /!\
        [Fact]
        public void OnlyReturnProductsUnderPrice()
        {
            // Arrange
            var productService = new ProductService(
                new EfRepository<Product>(
                    new ProductContext(
                        new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase("Products").Options)));

            productService.CreateProduct(new Product { Price = 10, Description = "Burger" });
            productService.CreateProduct(new Product { Price = 20, Description = "Burger" });
            productService.CreateProduct(new Product { Price = 5, Description = "Burger" });
            productService.CreateProduct(new Product { Price = 15, Description = "Burger" });
            productService.CreateProduct(new Product { Price = 150, Description = "Bike" });

            // Act
            var result = productService.ListAllProductsUnderPrice(20);

            // Assert
            Assert.Equal(3, result.Count());
        }
    }
}
