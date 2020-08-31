//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace TestForEventRegister.Controllers
//{
//    public class BackEventController : Controller
//    {
//        public ActionResult Event_B()
//        {
//            TestForEventRegisterEntities2 db = new TestForEventRegisterEntities2();
//            var events = from t in (new TestForEventRegisterEntities2()).tEventSet
//                         select t;
//            return View(events);
//        }
//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Create(tEventSet p)
//        {
//            TestForEventRegisterEntities2 db = new TestForEventRegisterEntities2();
//            db.tEventSet.Add(p);
//            db.SaveChanges();
//            return RedirectToAction("SetRegistForm2");
//        }


//        //[HttpPost]
//        //public ActionResult SetRegistForm2(tEventSetRegister p)
//        //{
//        //    tEventSetRegister x = new tEventSetRegister();
//        //    p.fUserId = 1;
//        //    p.fnumAttendPeople = 1;
//        //    p.ferName = 1;
//        //    p.ferPhone = 1;
//        //    p.ferEmail = Int32.Parse(Request.Form["email_v"]) ;
//        //    p.ferGender = Int32.Parse(Request.Form["gender_v"]);
//        //    p.ferBirthday = Int32.Parse(Request.Form["birthday_v"]);
//        //    p.ferIdentity = Int32.Parse(Request.Form["idnumber_v"]);
//        //    p.ferOccupation = Int32.Parse(Request.Form["occupation_v"]);
//        //    p.ferVeganOrNot = Int32.Parse(Request.Form["veganornot_v"]);
//        //    p.ferOtherColumn1 = Int32.Parse(Request.Form["other1_v"]);
//        //    p.ferOtherColumn2 = Request.Form["other2_v"];
//        //    p.ferOtherColumn3 = Request.Form["other3_v"];
//        //    p.ferOtherColumn4 = Request.Form["other4_v"];
//        //    p.ferOtherColumn5 = Request.Form["other5_v"];
//        //    dbEventRegistEntities db = new dbEventRegistEntities();
//        //    db.tEventSetRegister.Add(p);
//        //    db.SaveChanges();
//        //    return RedirectToAction("Event_B");
//        //}

//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//                return RedirectToAction("Event_B");

//            TestForEventRegisterEntities2 db = new TestForEventRegisterEntities2();
//            tEventSet x = db.tEventSet.FirstOrDefault(m => m.fEventId == id);
//            return View(x);
//        }


//        [HttpPost]
//        public ActionResult Edit(tEventSet p)
//        {
//            if (string.IsNullOrEmpty(p.fEventTitle))
//                return RedirectToAction("Event_B");
//            TestForEventRegisterEntities2 db = new TestForEventRegisterEntities2();
//            tEventSet editevent = db.tEventSet.FirstOrDefault(m => m.fEventId == p.fEventId);
//            if (editevent != null)
//            {
//                editevent.fUserId = p.fUserId;
//                editevent.fEventTitle = p.fEventTitle;
//                editevent.fCategory = p.fCategory;
//                editevent.fEventFromDay = p.fEventFromDay;
//                editevent.fEventFromTime = p.fEventFromTime;
//                editevent.fEventEndDate = p.fEventEndDate;
//                editevent.fEventEndTime = p.fEventEndTime;
//                editevent.fEventImgPath = p.fEventImgPath;
//                editevent.fEventLocation = p.fEventLocation;
//                editevent.fEventDescription = p.fEventDescription;
//                editevent.fEventFeeOrFree = p.fEventFeeOrFree;
//                editevent.fEventFee = p.fEventFee;
//                editevent.fEventFromDay_R = p.fEventFromDay_R;
//                editevent.fEventFromTime_R = p.fEventFromTime_R;
//                editevent.fEventEndDate_R = p.fEventEndDate_R;
//                editevent.fEventEndTime_R = p.fEventEndTime_R;
//                editevent.fRemark = p.fRemark;
//                db.SaveChanges();
//            }
//            return RedirectToAction("Event_B");
//        }




//        public ActionResult RegistertDetail()
//        {
//            TestForEventRegisterEntities2 db = new TestForEventRegisterEntities2();
//            var RegistertPpl = from t in (new TestForEventRegisterEntities2()).tEventRegister
//                               select t;
//            return View(RegistertPpl);
//        }

//    }
//}