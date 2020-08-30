using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestForEventRegister.Controllers
{
    public class BackEvent2Controller : Controller
    {
        public ActionResult Event_B()
        {
            dbEventSet db = new dbEventSet();
            var events = from t in (new dbEventSet()).tEventSet
                         select t;
            return View(events);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tEventSet p)
        {
            dbEventSet db = new dbEventSet();            
            db.tEventSet.Add(p);
            db.SaveChanges();
            return RedirectToAction("Event_B");
        }       

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Event_B");

            dbEventSet db = new dbEventSet();
            tEventSet x = db.tEventSet.FirstOrDefault(m => m.fEventId == id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Edit(tEventSet p)
        {
            if (string.IsNullOrEmpty(p.fEventTitle))
                return RedirectToAction("Event_B");
            dbEventSet db = new dbEventSet();
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


        public ActionResult RegistertDetail()
        {
            dbEventSet db = new dbEventSet();
            var RegistertPpl = from t in (new dbEventSet()).tEventRegister
                               select t;
            return View(RegistertPpl);
        }
    }
}