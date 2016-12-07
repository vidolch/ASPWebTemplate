using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BrowserClient.Controllers;
using BrowserClient.ViewModels.UserManagment;
using DataAccess.Models;
using Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.EntityServices;
using TestStack.FluentMVCTesting;
using Assert = NUnit.Framework.Assert;

namespace BrowserClient.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            
            var service = new Mock<UserService>();
            
            var users = new List<User>
            {
                new User { Username = "vidolch"},
                new User { Username = "ivan"}
            }.AsQueryable();

            service.Setup(x => x.GetAll()).Returns(users);

            UserController controller = new UserController(service.Object);

            controller.WithCallTo(x => x.Index()).ShouldRenderView("Index").WithModel<UserListViewModel>(
                vm =>
                {
                    Assert.AreEqual(users, vm.Items);
                }).AndNoModelErrors();
        }

        [TestMethod]
        public void Details()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);

            var service = new Mock<UserService>();

            string username = "vidolch";

            service.Setup(x => x.Get(It.IsAny<int>())).Returns(new User { Username = username, Role = Role.Admin });

            UserController controller = new UserController(service.Object);

            controller.WithCallTo(x => x.Details(1)).ShouldRenderView("Details").WithModel<UserViewModel>(
                vm =>
                {
                    Assert.AreEqual(username, vm.Username);
                }).AndNoModelErrors();
        }
    }
}
