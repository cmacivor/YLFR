using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YLFR.Models;
using YLFR.ViewModels;

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
            //quick test
            //GenericUtilities util = new GenericUtilities();
            //int id = util.GetApplicantID();

            return View();
        }

        [HttpGet]
        public ActionResult Page2()
        {
            OptionsRepository options = new OptionsRepository();
            return View(options.GetAvailableDaysInitialModel());
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

    }
}