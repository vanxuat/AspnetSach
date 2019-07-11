using sach_Controller;
using Sach_value;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websach.Areas.Admin.Controllers
{
    public class QuanLyController : BaseController
    {
        // GET: Admin/QuanLy

        public ActionResult ThemTuSach()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTuSach(TudachValue ts)
        {
            bool kt = new TusachController().InsertElement(ts);
            if (kt == true)
            {
                return RedirectToAction("DanhSachTuS");
            }
            return View();
        }

        public ActionResult DanhSachTuS()
        {

            List<TudachValue> listts = new TusachController().getElements();
         


            return View(listts);
        }

        public ActionResult XoaTuSach(string idxoa)
        {

            Guid idtusach = Guid.Parse(idxoa);

            bool kq = new TusachController().XoaTuSachTheoID(idtusach);
            if (kq == false)
            {
                ModelState.AddModelError("loisukhongduoc", "Không Thể Sửa Được");
                return RedirectToAction("DanhSachTuS");
            }



            return RedirectToAction("DanhSachTuS");
        }
        [HttpGet]
        public ActionResult SuaTuSach(string idsua)
        {
            Guid IDtus = Guid.Parse(idsua);

            TudachValue tsvl = new TusachController().LayTuSachID(IDtus);


            return View(tsvl);


        }
        [HttpPost]
        public ActionResult SuaTuSach(TudachValue sach)
        {
            bool kq = new TusachController().SuaTuSach(sach);
            if (kq == false)
            {
                ModelState.AddModelError("Loi", "Không thể sửa được");
                return View();
            }

            return RedirectToAction("DanhSachTuS");


        }


        public ActionResult ThemSach()
        {
            ViewBag.Tusach = new TusachController().getElements();

            return View();
        }
        

        [HttpPost]
        public ActionResult ThemSach(HttpPostedFileBase HinhAnh,sachvalue sach)
        {


            string gui = Guid.NewGuid().ToString();
            string Filename = gui + Path.GetFileName(HinhAnh.FileName);
            string path = Path.Combine(Server.MapPath("/Areas/Admin/containt/Image/"), Filename);
            HinhAnh.SaveAs(path);
            sach.HinhAnh = "/Areas/Admin/containt/Image/" + Filename;
            bool tc= new SachController().InsertElement(sach);
            

            return RedirectToAction("ListSach");
        }


        public ActionResult ListSach()
        {
            List<sachvalue> listsach = new SachController().getElements();


            return View(listsach);
         }

      [HttpPost]
        public JsonResult XoaSach(string id)
        {

            Guid IDSach = Guid.Parse(id);

            bool kqxoa = new SachController().XoaSachTheoID(IDSach);
            if (kqxoa == true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }


            return Json(false, JsonRequestBehavior.AllowGet);
            
        }



        public ActionResult SuaSach(string id)
        {
            Guid Idsach = Guid.Parse(id);

            sachvalue sach = new SachController().LaySachTheoID(Idsach);
           List<TudachValue> tusach = new TusachController().getElements();

            ViewBag.Tusach = tusach;

            
            return View(sach);
        }


        [HttpPost]
        public ActionResult SuaSach(HttpPostedFileBase HinhAnh, sachvalue sach)
        {

            string gui = Guid.NewGuid().ToString();
            string Filename = gui + Path.GetFileName(HinhAnh.FileName);
            string path = Path.Combine(Server.MapPath("/Areas/Admin/containt/Image/"), Filename);
            HinhAnh.SaveAs(path);
            sach.HinhAnh = "/Areas/Admin/containt/Image/" + Filename;

            bool kqsua = new SachController().SuaSach(sach);
            if (kqsua == true)
            {
                return RedirectToAction("ListSach");
            }


            return View();
        }
        public ActionResult InfoUser()
        {

            var data = (taikhoan)Session[CommonConstants.SESSION_ACCOUNT];

            return View("~/Areas/Admin/Views/QuanLy/InfoUser.cshtml",data);
        }




        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult UpdateMatKhau(taikhoan tk )
        {
            tk.id = ((taikhoan)Session[CommonConstants.SESSION_ACCOUNT]).id;
            bool kq = new TaikhoanController().UpdateMatKhau(tk);
            if (kq == true)
            {
                return Json("Cap Nhap Thanh cong", JsonRequestBehavior.AllowGet);

            }

            return Json("Cap nhat khong thanh cong", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult UpdateHinhanh(HttpPostedFileBase file)
        {
            taikhoan tk = new taikhoan();

            tk.id=((taikhoan)Session[CommonConstants.SESSION_ACCOUNT]).id;
            string gui = Guid.NewGuid().ToString();
            string Filename = gui + Path.GetFileName(file.FileName);
            string path = Path.Combine(Server.MapPath("/Areas/Admin/containt/Image/"), Filename);
            file.SaveAs(path);
            tk.hinhanh = "/Areas/Admin/containt/Image/" + Filename;

          bool kq=   new TaikhoanController().UpdateHinhAnh(tk);
            if (kq == true)
            {
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }


    }
}