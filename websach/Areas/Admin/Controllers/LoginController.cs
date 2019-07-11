using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Plus.v1;
using Google.Apis.Plus.v1.Data;
using Google.Apis.Services;
using sach_Controller;
using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace websach.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(taikhoan tk)
        {

            var data = new TaikhoanController().CheckElement(tk);
            if (ModelState.IsValid)
            {
                if (data != null)
                {
                    Session.Add(CommonConstants.SESSION_ACCOUNT, data);
                    FormsAuthentication.SetAuthCookie(data.nguoidung, true);
                    return RedirectToAction("Index","QuanLy");
                }
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// /AuthCallback/IndexAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
                AuthorizeAsync(cancellationToken);

            if (result.Credential != null)
            {
                var service = new PlusService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });

                // YOUR CODE SHOULD BE HERE..
                // SAMPLE CODE:
                Person me = service.People.Get("me").Execute();
                if (me != null)
                {
                    taikhoan taik = new TaikhoanController().CheckGoole(me.Id);
                    if (taik == null)
                    {
                        taikhoan taikhoan = new taikhoan()
                        {
                            email = me.Emails.ElementAt(0).Value,
                            GoogleID = me.Id,
                            hinhanh = me.Image.Url,

                        };
                        bool resutl = new TaikhoanController().DangNhapGoogle(taikhoan);
                        Session.Add(CommonConstants.SESSION_ACCOUNT, taikhoan);


                        if (Session["CurrentUrl"] != null)
                            return Redirect((string)Session["CurrentUrl"]);
                        return RedirectToAction("Index", "QuanLy");
                    }

                    Session.Add(CommonConstants.SESSION_ACCOUNT, taik);
                    return RedirectToAction("Index", "QuanLy");
                }



                //    ViewBag.Message = "FILE COUNT IS: " + list.Items.Count();
                return RedirectToAction("Index");
            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove(CommonConstants.SESSION_ACCOUNT);

            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult DangKi(taikhoan tk)
        {
            var data = new TaikhoanController().InsertElement(tk);
            if(data == true)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}