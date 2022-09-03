using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacementManagement.API;
using PlacementManagement.API.Controllers;
using System.Web.Mvc;

namespace PlacementManagement.API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
