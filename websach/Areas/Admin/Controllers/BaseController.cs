using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace websach.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (taikhoan)Session[CommonConstants.SESSION_ACCOUNT];
            if (session == null)
            {
                // Chưa đăng nhập => trang chủ khách hàng
                filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new
                        {
                            controller = "Login",
                            action = "Index",
                            Area = "Admin"
                        }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}