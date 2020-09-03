using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    }
}