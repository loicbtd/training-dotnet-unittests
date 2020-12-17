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
using AutoFixture.Xunit2;
using Mocking.Domain.Exceptions;

namespace Mocking.UnitTest
{
    public class ProductServiceShouldV4
    {
        [Theory]
        [AutoMoqData]
        public void OnlyReturnProductsUnderPrice(
            int fakePrice,
            List<Product> fakeProducts,
            [Frozen] Mock<IRepository<Product>> mockRepository,
            ProductService productService
        )
        {
            // Arrange
            mockRepository.Setup(repo => repo.ListAll()).Returns(fakeProducts);

            // Act
            var result = productService.ListAllProductsUnderPrice(fakePrice);

            // Assert
            Assert.DoesNotContain(result, product => product.Price >= fakePrice);
            mockRepository.Verify(repo => repo.ListAll(), Times.Exactly(1));
        }

        [Theory]
        [AutoMoqData]
        public void Check_Negative_Price_During_Create(
          Product fakeProduct,
          [Frozen] Mock<IRepository<Product>> mockRepository,
          ProductService productService)
        {
            // Arrange.
            // Product must have negative price to verify this case.
            fakeProduct.Price = -10;

            // Act/Assert.
            Assert.Throws<NegativePriceException>(() => productService.CreateProduct(fakeProduct));
            mockRepository.Verify(repo => repo.Add(It.IsAny<Product>()), Times.Never);
        }
    }
}
