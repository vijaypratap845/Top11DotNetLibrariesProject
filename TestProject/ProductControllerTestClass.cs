using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top10LibrariesSampleProject.Controllers;
using Top10LibrariesSampleProject.DAL.Interfaces;
using Top10LibrariesSampleProject.Model;

namespace TestProject
{
    [TestFixture]
    public class ProductControllerTestClass
    {
        private readonly Mock<IProduct> _product = new Mock<IProduct>();
        private readonly Mock<ILoggerService> _logger = new Mock<ILoggerService>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        public IConfiguration _configuration;
        private ProductController _controller;

        public ProductControllerTestClass()
        {
            _product = new Mock<IProduct>();
            _controller = new ProductController(_product.Object, _logger.Object, _mapper.Object);
        }
        [Test]
        public async Task Product_ReturnsOkResult()
        {
            //Arrange
            IEnumerable<GetProduct> product = new List<GetProduct>
            {
            new GetProduct
            {
               ProductId=1,
               ProductName="Table",
               ProductCategory="Furniture",
               ProductDescription="Home Decore Furniture",
            }
            };
            

            _product.Setup(x => x.GetAllProducts()).ReturnsAsync(product);

            //Act
            var result = await _controller.GetAllProduct();

            //assert
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.AreEqual(200, okObjectResult.StatusCode);
        }
    }
}
