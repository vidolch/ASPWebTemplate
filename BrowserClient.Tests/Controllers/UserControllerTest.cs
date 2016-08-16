using System;
using System.Web.Mvc;
using BrowserClient.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrowserClient.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Index()
        {
            UserController controller = new UserController();

            ActionResult action = controller.Index();

            Assert.IsNotNull(action);

        }
    }
}
