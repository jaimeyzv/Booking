using System.Web;
using System.Web.Mvc;

namespace BookingMVC.Filter
{
    public class AuthUserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if ((controllerName == "IniciarSesion" || controllerName == "Registro") && filterContext.HttpContext.Session["Miembro"] != null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }
            else if ((controllerName != "IniciarSesion" || controllerName == "Registro") && filterContext.HttpContext.Session["Miembro"] == null)
            {
                filterContext.Result = new RedirectResult("~/IniciarSesion/Index");
                return;
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}