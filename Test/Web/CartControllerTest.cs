using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;
using System.Web.Mvc;

namespace Test.Web
{
    [TestClass]
    public class CartControllerTest
    {
        CartController cart = new CartController();

        [TestMethod]
        public void IndexTest()
        {
            // Giriş yapmadığımız için boş sepet dönmeli

            cart = new CartController();
            ViewResult result = cart.Index() as ViewResult;
            Assert.AreEqual(null, result.Model);
     
        }
        
    }
}
