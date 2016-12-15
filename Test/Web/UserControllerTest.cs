using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web;
using Web.Controllers;
using System.Web.Mvc;
using Web.ViewModel;

namespace Test.Web
{
    [TestClass]
    public class UserControllerTest
    {
        UserController userController = new UserController();

        [TestMethod]
        public void AvatarTest()
        {
            ContentResult result = userController.Avatar(0) as ContentResult;
            Assert.AreEqual("Resim bulunamadı", result.Content);
        }

        [TestMethod]
        public void LoginTest()
        {
            UserViewModel user = new UserViewModel() { Email = "test", Password = "test" };
            ViewResult result = userController.Login(user) as ViewResult;
            Assert.AreEqual("Hatalı kullanıcı adı veya parola !", result.TempData["error"]);
        }
    }
}
