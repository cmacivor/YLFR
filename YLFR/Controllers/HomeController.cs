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

        public ActionResult Page1()
        {
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
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Page2(Page2ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //get the record from current user from the session 
            }
            return View();
        }

        [HttpPost]
        public JsonResult SaveInterestArea(PostedInterestAreas learningCenterPref)
        {
            //need to replace this with Session variable later
            string testEmail = "cmacivor82@gmail.com";

            //unitOfWork.LearningCenterPreferenceRepository.AddLearningCenterPreferenceByApplicantID(learningCenterPref, testEmail);
            unitOfWork.InterestAreasRepository.AddInterestAreas(learningCenterPref, testEmail);
            unitOfWork.InterestAreasRepository.Save();
            return Json("OK");
        }

        public ActionResult GetInterestAreasByEmailID(jQueryDataTableParamModel param)
        {
            //need to replace this with Session variable later
            string testEmail = "cmacivor82@gmail.com";

            var interestAreas = unitOfWork.InterestAreasRepository.GetInterestAreasByApplicantEmail(testEmail);
            var result = from c in interestAreas
                         select new[] { 
                             //c.InterestAreaID.ToString(), 
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
    }
}