namespace SimpleMvc.App.Controllers
{
    using System;
    using Framework.Attributes.Methods;
    using Framework.Controllers;

    public class HomeController : Controller
    {
        public void Index()
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Create(int id)
        {
            throw new NotImplementedException();
        }
    }
}
