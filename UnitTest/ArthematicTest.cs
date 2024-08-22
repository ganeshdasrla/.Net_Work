using ArthematicOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class ArthematicTest
    {
        public int i = 10, j = 25;
        [TestMethod]
        public void TestSum()
        {
            //AAA ::: A - Arrange, A - Act, A - Assert

            //Arrange
            Arthematic ar = new Arthematic();

            //Act

            //Assert
            Assert.AreEqual(35, ar.Sum(i, j));
        }

        [TestMethod]
        public void TestGetUser()
        {
            var emp = new Mock<Arthematic>();
            emp.Setup(x => x.Sum(It.IsAny<int>(), It.IsAny<int>())).Returns(i+j);
            Arthematic arr = new Arthematic(emp.Object);

            int sum = arr.Sum(i, j);
            Assert.AreEqual(i + j, sum);
        }

        [Fact]
        public void PerformAddition_ValidInputs_ReturnsCorrectSum()
        {
            // Arrange
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(service => service.Add(5, 3)).Returns(8);
    
            var calculator = new Calculator(mockCalculatorService.Object);
    
            // Act
            int result = calculator.PerformAddition(5, 3);
    
            // Assert
            Assert.Equal(8, result);
        }
    }
}
