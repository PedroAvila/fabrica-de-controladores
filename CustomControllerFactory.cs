using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace FabricaDeControladores
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            ILogger logger = new DefaultLogger();
            Assembly a = Assembly.GetExecutingAssembly();
            string ns = a.GetTypes().Select(t => t.Namespace).Where(n => n.EndsWith(".Controllers")).FirstOrDefault();
            var typeName = ns + "." + controllerName + "Controller";
            Type controllerType = Type.GetType(typeName);
            IController controller = Activator.CreateInstance(controllerType, new[] { logger }) as Controller;
            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return System.Web.SessionState.SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}