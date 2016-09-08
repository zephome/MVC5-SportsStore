using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrage - 설정
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductId = 1, Name = "P1" },
                new Product { ProductId = 2, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" },
                new Product { ProductId = 4, Name = "P4" },
                new Product { ProductId = 5, Name = "P5" }
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 4;

            // Act - 실행
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;

            // Assert - 검증
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 1);
            Assert.AreEqual(prodArray[0].Name, "P5");
        }
    }
}
