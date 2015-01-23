using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YLFR.Models;
using YLFR.ViewModels;
using YLFR;

namespace YLFR.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = null;
        


        public HomeController()
            : this(new UnitOfWork())
        {

        }

        public HomeController(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void LoadGenderSelectList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            //SelectList items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Male", Value = "Male" });
            items.Add(new SelectListItem { Text = "Female", Value = "Female" });

            var selectList = new SelectList(items, "Value", "Text");

            ViewBag.Gender = selectList;
            //IEnumerable<SelectListItem> items = new List<SelectListItem>();
        }

        public ActionResult Page1()
        {
            LoadGenderSelectList();
           

            return View();
        }

        [HttpGet]
        public ActionResult Page2()
        {
            return View(unitOfWork.AvailableTimesRepository.GetAvailableDaysInitialModel());
        }

        [HttpPost]
        public ActionResult Page1(Page1ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Applicant applicant = new Applicant
                {
                    FirstName = vm.FirstName,
                    MiddleName = vm.MiddleName,
                    LastName = vm.LastName,
                    Date = DateTime.Now,
                    Address = vm.Address,
                    Phone = vm.Phone,
                    BirthDate = vm.BirthDate,
                    Gender = vm.Gender,
                    Employer = vm.Employer,
                    BusinessPhone = vm.BusinessPhone,
                    Email = vm.Email,
                    //Email = Session["userID"].ToString(),
                    HighestLevelEducation = vm.EducationLevel,
                    AdvancedEducation = vm.AdvancedEducation,
                    EmergencyContactName = vm.EmergencyContactName,
                    EmergencyContactRelationship = vm.EmergencyContactRelationship,
                    EmergencyContactPhone = vm.EmergencyContactPhone,
                    HowDidYouHear = vm.HowDidYouHear,
                    WhyAreYouInterested = vm.WhyAreYouInterested,
                    PreviousVolunteerExperience = vm.PreviousVolunteerExperience,
                    HobbiesTalentSkills = vm.HobbiesTalentSkills,
                    CommunityChurchAffiliations = vm.CommunityChurchAffiliations
                };

                unitOfWork.ApplicantRepository.AddApplicant(applicant);
                unitOfWork.ApplicantRepository.Save();
                return RedirectToAction("Page2");
            }
            LoadGenderSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Page2(Page2ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //get the record from current user from the session
                if (!String.IsNullOrEmpty(SessionHelper.UserEmail))
                {
                    string email = SessionHelper.UserEmail;
                    var applicant = unitOfWork.ApplicantRepository.GetApplicantByEmailAddress(SessionHelper.UserEmail);
                    if (applicant != null)
                    {
                        unitOfWork.ApplicantRepository.UpdateApplicant(vm, email);
                        unitOfWork.CommitmentDaysRepository.AddCommitmentDays(vm.PostedAvailableDays, email);
                        unitOfWork.CommitmentTimesRepository.AddCommitmentTimes(vm.PostedAvailableTimes, email);
                        unitOfWork.InterestAreasRepository.AddInterestAreas(vm.PostedInterestAreas, email);
                        unitOfWork.LearningCenterPreferenceRepository.AddLearningCenterPreferenceByApplicantID(vm.PostedLearningCenters, email);
                        unitOfWork.ApplicantRepository.Save();


                        //logging
                        //YLFREventSource.Log.RecordSaved(vm);
                    }


                }


            }
            return View(unitOfWork.AvailableTimesRepository.GetAvailableDaysInitialModel());
        }

        [HttpPost]
        public JsonResult SaveInterestArea(PostedInterestAreas learningCenterPref)
        {
            //need to replace this with Session variable later
            //string testEmail = "cmacivor82@gmail.com";
            if (!String.IsNullOrEmpty(SessionHelper.UserEmail))
            {
                var records = unitOfWork.InterestAreasRepository.GetInterestAreasByApplicantEmail(SessionHelper.UserEmail);
                foreach (var item in records)
                {
                    unitOfWork.InterestAreasRepository.DeleteInterestArea(item);
                    unitOfWork.InterestAreasRepository.Save();
                }

                //unitOfWork.LearningCenterPreferenceRepository.AddLearningCenterPreferenceByApplicantID(learningCenterPref, testEmail);
                unitOfWork.InterestAreasRepository.AddInterestAreas(learningCenterPref, SessionHelper.UserEmail);
                unitOfWork.InterestAreasRepository.Save();
                return Json("OK");
            }
            return Json("Session is null");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetInterestAreasByEmailID(jQueryDataTableParamModel param)
        {
            //need to replace this with Session variable later
            //string testEmail = "cmacivor82@gmail.com";
            if (!String.IsNullOrEmpty(SessionHelper.UserEmail))
            {
                string email = SessionHelper.UserEmail;
                var interestAreas = unitOfWork.InterestAreasRepository.GetInterestAreasByApplicantEmail(email);
                var result = from c in interestAreas
                             select new[] { 
                             c.InterestAreaID.ToString(), 
                             //c.ApplicantID.ToString(), 
                             c.InterestArea1, 
                             c.PreferenceRanking.ToString() 
                         };
                return Json(new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = interestAreas.Count(),
                    iTotalDisplayRecords = interestAreas.Count(),
                    aaData = result
                }, JsonRequestBehavior.AllowGet);
            }
            return Json("Session is null", JsonRequestBehavior.AllowGet);
        }

        //for inline editing of the PreferenceRanking column in the InterestAreas table
        /// <summary>Action that updates data
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <param name="value">Value that should be set</param>
        /// <param name="rowId">Id of the row</param>
        /// <param name="columnPosition">Position of the
        ///           column(hidden columns are not counted)</param>
        /// <param name="columnId">Position of the column(hidden columns are counted)</param>
        /// <param name="columnName">Name of the column</param>
        /// <returns>value if update suceed - any other value
        ///        will be considered as an error message on the client-side</returns>
        public string UpdateData(int id, string value, int? rowId, 
           int? columnPosition, int? columnId, string columnName)
        {
            //need to replace this with Session variable later
            //string testEmail = "cmacivor82@gmail.com";

            

            unitOfWork.InterestAreasRepository.UpdatePreferenceRanking(id, value);

            return value;
        }

       

    }
}