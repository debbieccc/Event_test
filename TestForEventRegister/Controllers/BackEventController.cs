using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using OfficeOpenXml;


namespace TestForEventRegister.Controllers
{
    public class BackEventController : Controller
    {
        dbEventSet db = new dbEventSet();

        public ActionResult Event_B()
        {
            IQueryable<tEventSet> events = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
            {
                events = from p in (new dbEventSet()).tEventSet
                           select p;
            }

            else
            {
                events = from p in (new dbEventSet()).tEventSet
                         where p.fEventTitle.Contains(keyword)
                           select p;
            }

            //var events = from t in (new dbEventSet()).tEventSet
            //             select t;
            return View(events);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tEventSet p)
        {
           if(p.fImage != null)
            {
                string photoName = Guid.NewGuid().ToString() + Path.GetExtension(p.fImage.FileName);
                var path = Path.Combine(Server.MapPath("~/image/event/"), photoName);
               // var frontpath = "C:/Users/User/Source/Repos/debbieccc/Front_test/eco/mage/event";
               // p.fImage.SaveAs(frontpath);
                p.fImage.SaveAs(path);
                p.fEventImgPath = "../image/event/" + photoName;
            }                 

            db.tEventSet.Add(p);
            db.SaveChanges();
            return RedirectToAction("Event_B");
                                 
        }       

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Event_B");

         //   dbEventSet db = new dbEventSet();
            tEventSet x = db.tEventSet.FirstOrDefault(m => m.fEventId == id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Edit(tEventSet p)
        {
            if (string.IsNullOrEmpty(p.fEventTitle))
                return RedirectToAction("Event_B");
        //    dbEventSet db = new dbEventSet();
            tEventSet editevent = db.tEventSet.FirstOrDefault(m => m.fEventId == p.fEventId);
            if (editevent != null)
            {
                editevent.fUserId = p.fUserId;
                editevent.fEventTitle = p.fEventTitle;
                editevent.fCategory = p.fCategory;
                editevent.fEventFromDay = p.fEventFromDay;
                editevent.fEventFromTime = p.fEventFromTime;
                editevent.fEventEndDate = p.fEventEndDate;
                editevent.fEventEndTime = p.fEventEndTime;
                editevent.fEventImgPath = p.fEventImgPath;
                editevent.fEventLocation = p.fEventLocation;
                editevent.fEventDescription = p.fEventDescription;
                editevent.fEventFeeOrFree = p.fEventFeeOrFree;
                editevent.fEventFee = p.fEventFee;
                editevent.fEventFromDay_R = p.fEventFromDay_R;
                editevent.fEventFromTime_R = p.fEventFromTime_R;
                editevent.fEventEndDate_R = p.fEventEndDate_R;
                editevent.fEventEndTime_R = p.fEventEndTime_R;
                editevent.fRemark = p.fRemark;
                
                db.SaveChanges();
            }
            return RedirectToAction("Event_B");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Event_B");
            }
            tEventSet t = db.tEventSet.FirstOrDefault(x => x.fEventId == Id);
            if (t != null)
            {
                db.tEventSet.Remove(t);
                db.SaveChanges();
            }
            return RedirectToAction("Event_B");
        }

        public ActionResult RegistertDetail(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Event_B");
            }
            
            tEventSet set = db.tEventSet.FirstOrDefault(m => m.fEventId == Id);
            ViewBag.fEventTitle = set.fEventTitle;

            if (set.ferEmail == 1)
            {
                ViewBag.ferEmail = 1;
            }
            if (set.ferGender == 1)
            {
                ViewBag.ferGender = 1;
            }
            if (set.ferBirthday == 1)
            {
                ViewBag.ferBirthday = 1;
            }
            if (set.ferIdentity == 1)
            {
                ViewBag.ferIdentity = 1;
            }
            if (set.ferOccupation == 1)
            {
                ViewBag.ferOccupation = 1;
            }
            if (set.ferVeganOrNot == 1)
            {
                ViewBag.ferVeganOrNot = 1;
            }
            if (set.ferOtherColumn1 != null)
            {
                ViewBag.ferOtherColumn1 = set.ferOtherColumn1;
            }
            if (set.ferOtherColumn2 != null)
            {
                ViewBag.ferOtherColumn2 = set.ferOtherColumn2;
            }
            if (set.ferOtherColumn3 != null)
            {
                ViewBag.ferOtherColumn3 = set.ferOtherColumn3;
            }
            if (set.ferOtherColumn4 != null)
            {
                ViewBag.ferOtherColumn4 = set.ferOtherColumn4;
            }
            if (set.ferOtherColumn5 != null)
            {
                ViewBag.ferOtherColumn5 = set.ferOtherColumn5;
            }
            var eventRegisterts = from t in (new dbEventSet()).tEventRegister
                                  where t.fEventId == Id
                         select t;
            return View(eventRegisterts);
        }

        public ActionResult TestDate()
        {
            return View();
        }

        public ActionResult Export()
        {
            //取出要匯出Excel的資料
            List<tEventRegister> rangerList = db.tEventRegister.ToList();

            //建立Excel
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage ep = new ExcelPackage();

            //建立第一個Sheet，後方為定義Sheet的名稱
            ExcelWorksheet sheet = ep.Workbook.Worksheets.Add("FirstSheet");

            int col = 1;    //欄:直的，因為要從第1欄開始，所以初始為1

            //第1列是標題列 
            //標題列部分，是取得DataAnnotations中的DisplayName，這樣比較一致，
            //這也可避免後期有修改欄位名稱需求，但匯出excel標題忘了改的問題發生。
            //取得做法可參考最後的參考連結。
            sheet.Cells[1, col++].Value = "No.";
            sheet.Cells[1, col++].Value = "活動編號";
            sheet.Cells[1, col++].Value = "戶號";
            sheet.Cells[1, col++].Value = "參加人數";
            sheet.Cells[1, col++].Value = "姓名";
            sheet.Cells[1, col++].Value = "聯絡電話";
            sheet.Cells[1, col++].Value = "電子郵件";
            sheet.Cells[1, col++].Value = "性別";
            sheet.Cells[1, col++].Value = "出生年月日";
            sheet.Cells[1, col++].Value = "身分證字號";
            sheet.Cells[1, col++].Value = "職業";
            sheet.Cells[1, col++].Value = "葷食/素食";            

            //資料從第2列開始
            int row = 2;    //列:橫的
            foreach (tEventRegister item in rangerList)
            {
                col = 1;//每換一列，欄位要從1開始
                        //指定Sheet的欄與列(欄名列號ex.A1,B20，在這邊都是用數字)，將資料寫入
                sheet.Cells[row, col++].Value = item.fEventRegisterId;
                sheet.Cells[row, col++].Value = item.fEventId;
                sheet.Cells[row, col++].Value = item.fUserId;
                sheet.Cells[row, col++].Value = item.fnumAttendPeople;
                sheet.Cells[row, col++].Value = item.ferName;
                sheet.Cells[row, col++].Value = item.ferPhone;
                sheet.Cells[row, col++].Value = item.ferEmail;
                sheet.Cells[row, col++].Value = item.ferGender;
                sheet.Cells[row, col++].Value = item.ferBirthday;
                sheet.Cells[row, col++].Value = item.ferIdentity;
                sheet.Cells[row, col++].Value = item.ferOccupation;
                sheet.Cells[row, col++].Value = item.ferVeganOrNot;
                row++;
            }

            //因為ep.Stream是加密過的串流，故要透過SaveAs將資料寫到MemoryStream，在將MemoryStream使用FileStreamResult回傳到前端
            MemoryStream fileStream = new MemoryStream();
            ep.SaveAs(fileStream);
            ep.Dispose();//如果這邊不下Dispose，建議此ep要用using包起來，但是要記得先將資料寫進MemoryStream在Dispose。
            fileStream.Position = 0;//不重新將位置設為0，excel開啟後會出現錯誤
            return File(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "活動報名名單.xlsx");
        }

    }
}