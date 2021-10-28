using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileDownloader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDownloader.Tests
{
    [TestClass()]
    public class DirectoryAdressTests
    {
        [DataRow(@"c:\")]
        [DataRow(@"c:\1\")]
        [TestMethod()]
        public void IsAdressValidTest_AdressIsValid_ReturnTrue(string adress)
        {
            //Arrange
            DirectoryAdress Dr = new ();
            //Act
            var result = Dr.IsAdressValid(adress);
            //Assert
            Assert.IsTrue(result);          
        }
        [DataRow(@"c: \1\")]
        [TestMethod()]
        public void IsAdressValidTest_AdressIsValid_ReturnFalse(string adress)
        {
            //Arrange
            DirectoryAdress Dr = new();
            //Act
            var result = Dr.IsAdressValid(adress);
            //Assert
            Assert.IsFalse(result);
            //Assert.Fail();
        }

    }
}