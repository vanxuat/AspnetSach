using sach_Controller;
using Sach_value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websach.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Menu(string view = "")
        {
            return PartialView(view);
        }

        public ActionResult LoginNemu(string view = "")
        {
            return PartialView(view);
        }


        public ActionResult SilderHinh()
        {
            return PartialView();
        }


        public ActionResult PartialviewMenu()
        {
             List<TudachValue> Listtutuach = new TusachController().getElements();

            ViewBag.ListuSach = Listtutuach;

            return PartialView();
        }


        public ActionResult Index(int pagindex=0)
        {
            int pagesize = 6;
            int tongsach = new SachController().TongSoSach();
            List<sachvalue> lsach = new SachController().DanhsachPTrang(pagindex * pagesize, pagesize);
            int maxPage = (tongsach / pagesize) + (tongsach % pagesize > 0 ? 1 : 0);

            ViewBag.MaxPage = maxPage;

            ViewBag.danhsachSp = lsach;

            int sodong = lsach.Count / 4 + (lsach.Count % 4 == 0 ? 0 : 1);
            ViewBag.sodong = sodong;
          

            return View();
        }

        public ActionResult DanhsachSP(int pagindex)
        {
            return View();
        }

        
        public ActionResult ChiTietSp(string ID)
        {
            Guid IDsach = Guid.Parse(ID);
            sachvalue sac = new SachController().LaySachTheoID(IDsach);

            ViewBag.Chitietsp = sac;

            return View();
        }


        public ActionResult LayTuSachPT(string ID,int pageIndex=0)
        {
            Guid TSID = Guid.Parse(ID);
            int CountPgae = 5;


            List<sachvalue> CountSoluong = new SachController().LaySachTheoIDTu(TSID);

            int SLSach = CountSoluong.Count;


            List<sachvalue> ListSach = new SachController().LaySachTheoIDTPhanTrang(TSID, pageIndex * CountPgae, CountPgae);

            int maxPage = (SLSach / CountPgae) + (SLSach % CountPgae == 0 ? 0 : 1);

            ViewBag.Maxpage = maxPage;

            int soDong = ListSach.Count / 4 + (ListSach.Count % 4 == 0 ? 0 : 1);

            ViewBag.Sodong = soDong;
            ViewBag.Danhsach = ListSach;
            return View();
        }

        [HttpPost]
        public JsonResult MuaSach(string ID,string Gia)
        {

            taikhoan tk = (taikhoan)Session[CommonConstants.SESSION_ACCOUNT];
            if (tk == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            DonHangValue DonHang = new GioHangController().KiemTraTkTrongDonHang(tk.id);
            if(DonHang != null)
            {
                GioHangValue GioHang = new GioHangValue()
                {
                    IdDonHang=DonHang.IdDonHang,
                    IdGioHang=Guid.NewGuid(),
                    IdSach=Guid.Parse(ID),
                    Soluong=1,
                    Tamtinh=decimal.Parse(Gia)
                };

                bool ThemGh = new GioHangController().ThemGioHang(GioHang);
                decimal? tongiten = new GioHangController().TongTien(DonHang.IdDonHang);
                DonHang.TongTien = tongiten;

                new GioHangController().CapNhatDonHang(DonHang);


                if (ThemGh == true)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {

                DonHangValue DHMoi = new DonHangValue()
                {
                    IdDonHang = Guid.NewGuid(),
                    IdNguoiMua = tk.id,
                    NgayDatHang = DateTime.Now.Date,
                    TongTien = 0
                };

                bool ThemDonHang = new GioHangController().ThemDonHang(DHMoi);
                if(ThemDonHang == true)
                {

                    GioHangValue Ghmoi = new GioHangValue()
                    {
                        IdDonHang=DHMoi.IdDonHang,
                        IdGioHang=Guid.NewGuid(),
                        IdSach = Guid.Parse(ID),
                        Soluong=1,
                        Tamtinh=Decimal.Parse(Gia)
                    };

                   bool ThemGioHangM = new GioHangController().ThemGioHang(Ghmoi);

                    decimal? tongtien = new GioHangController().TongTien(DHMoi.IdDonHang);
                    DHMoi.TongTien = tongtien;



                    bool CapNhatDonH = new GioHangController().CapNhatDonHang(DHMoi);
                    if(ThemDonHang == true)
                    {
                        return Json(true, JsonRequestBehavior.DenyGet);
                    }
                }
            }
            

            return Json(true,JsonRequestBehavior.DenyGet);
        }
        

        public ActionResult SPSach()
        {

            taikhoan tk =(taikhoan) Session[CommonConstants.SESSION_ACCOUNT];

            DonHangValue Dh = new GioHangController().KiemTraTkTrongDonHang(tk.id);

            List<ThongTinGioHang> DanhsachSP = new GioHangController().DanhSachSpTrongGio(Dh.IdDonHang);

            decimal? TongTien = new GioHangController().TongTien(Dh.IdDonHang);
            ViewBag.TongTien = TongTien;

            return View(DanhsachSP);
        }
        
        public JsonResult XoaSpGioHang(string Id)
        {
            Guid IDGioHang = Guid.Parse(Id);

            bool kq = new GioHangController().XoaSPGioHang(IDGioHang);

            if (kq == true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);


        }

        public ActionResult ThayDoiSoL(string SL,string IDGioHang,string GiaTam,string IDDonHang)
        {

            Guid IDGioHangs = Guid.Parse(IDGioHang);
            Guid IDDonHangs = Guid.Parse(IDDonHang);
            int soluong = int.Parse(SL);
            decimal giatam = decimal.Parse(GiaTam);
            GioHangValue Gh = new GioHangValue()
            {
                IdGioHang=IDGioHangs,
                Soluong=soluong,
                Tamtinh=giatam
            };




            bool kq = new GioHangController().UpdateGiohang(Gh);

            decimal? TongGia = new GioHangController().TongTien(IDDonHangs);

            DonHangValue Donh = new DonHangValue()
            {
                IdDonHang = IDDonHangs,
                TongTien = TongGia
            };


            bool updae = new GioHangController().CapNhatDonHang(Donh);



            if (kq == false)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }


            return Json(true, JsonRequestBehavior.AllowGet);
        }



    }
}