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
            //var autoMapperConfig = new AutoMapperConfig();
            //autoMapperConfig.Execute(typeof(JokesController).Assembly);
            //const string JokeContent = "SomeContent";
            //var jokesServiceMock = new Mock<IJokesService>();
            //jokesServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
            //    .Returns(new Joke { Content = JokeContent, Category = new JokeCategory { Name = "asda" } });
            //var controller = new JokesController(jokesServiceMock.Object);
            //controller.WithCallTo(x => x.ById("asdasasd"))
            //    .ShouldRenderView("ById")
            //    .WithModel<JokeViewModel>(
            //        viewModel =>
            //        {
            //            Assert.AreEqual(JokeContent, viewModel.Content);
            //        }).AndNoModelErrors();



            UserController controller = new UserController();

            ActionResult action = controller.Index();

            Assert.IsNotNull(action);

        }
    }
}
