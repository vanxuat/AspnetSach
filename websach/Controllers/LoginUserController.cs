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
using System.Web.Mail;
using System.Web.Mvc;
using System.Web.Security;
using websach.App_Start;

namespace websach.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: LoginUser

        #region Đăng Nhập
        public JsonResult DangNhap(taikhoan tk)
        {
            if (ModelState.IsValid)
            {
                taikhoan user = new TaikhoanController().CheckElement(tk);
                if(user != null)
                {
                    Session.Add(CommonConstants.SESSION_ACCOUNT, user);
                    FormsAuthentication.SetAuthCookie(tk.nguoidung, true);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Đăng Xuât

        public ActionResult DangXuat()
        {

            Session.Remove(CommonConstants.SESSION_ACCOUNT);
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        #endregion


        #region Đăng Kí
        [HttpPost]
        public ActionResult Dangki(taikhoan tk )
        {

            if (ModelState.IsValid)
            {

                bool kt = new TaikhoanController().KiemTraTenDangKi(tk.nguoidung);
                if (kt == false)
                {
                    tk.id = Guid.NewGuid();
                    tk.Quyen = 0;
                     bool kq = new TaikhoanController().DangKiUserKhach(tk);


                    string d= Url.Action("Actived", "LoginUser", new { id = tk.id }, Request.Url.Scheme);

                    string link = string.Format("Dear {0}<BR/>Thank you for your registration, please click on the below link to comlete your registration: <a href=\"{1}\" title=\"User Email Confirm\">{1}</a>", tk.nguoidung, Url.Action("Actived", "LoginUser", new { id=tk.id }, Request.Url.Scheme));
                    bool b= new SMTPMail().sendmail(tk.email, "chúc mừng bạn ", link, null);

                }


            }

            return RedirectToAction("Index", "Home");
        }

        #endregion



        #region Kích Hoạt Tài Khoản
        public ActionResult Actived(string id)
        {

            Guid IDUser = Guid.Parse(id);

             new TaikhoanController().CapNhatQuyen(IDUser);

            return RedirectToAction("Index", "Home");
        }

        #endregion


        


    }
}