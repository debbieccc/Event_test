using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestForEventRegister.Controllers
{
    public class BackEvent2Controller : Controller
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
           // tEventRegister t = db.tEventRegister.FirstOrDefault(x => x.fEventId == Id);
            
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