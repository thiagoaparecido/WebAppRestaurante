using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAppRestaurante.Controllers;
using System.Web.Mvc;
using WebAppRestaurante.Models;

namespace WebAppRestaurante.Tests.Controllers
{
    [TestClass]
    public class PratosControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new PratosController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Create()
        {
            var controller = new PratosController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result.Model);
        }
    }
}
