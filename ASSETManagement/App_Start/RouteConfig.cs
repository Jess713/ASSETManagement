using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ASSETManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    //public class ClientsController : Controller
    //{

    //    //public string Create { get; set; }

    //    //
    //    // GET: /Clients/

    //    public ActionResult Create()
    //    {
    //        return View();
    //    }
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
    //}

    //public class CatchallControllerFactory : IControllerFactory
    //{
    //    #region IControllerFactory Members

    //    public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
    //    {

    //        if (requestContext.RouteData.Values["controller"].ToString() == "Clients")
    //        {
    //            DefaultControllerFactory factory = new DefaultControllerFactory();
    //            return factory.CreateController(requestContext, controllerName);
    //        }
    //        else
    //        {
    //            ClientsController controller = new ClientsController();
    //            //controller.Create = requestContext.RouteData.Values["action"].ToString();
    //            return controller;
    //        }

    //    }

    //    public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void ReleaseController(IController controller)
    //    {
    //        if (controller is IDisposable)
    //            ((IDisposable)controller).Dispose();
    //    }

    //    #endregion
    //}
}
