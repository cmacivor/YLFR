using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YLFR;
using YLFR.Controllers;
using YLFR.ViewModels;
using System.Data;
using System.Data.Entity.Validation;


namespace YLFR.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
       

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //test saving of the first page of data
        [TestMethod]
        public void Page1()
        {
            try
            {
                HomeController controller = new HomeController();
                UnitOfWork unitOfWork = new UnitOfWork();
                Applicant applicant = new Applicant();
                //controller.Page1()
                Page1ViewModel model = new Page1ViewModel
                {
                    FirstName = "John",
                    MiddleName = "Henry",
                    LastName = "Smith",
                    Address = "123 Anywhere",
                    Phone = "8048691111",
                    BirthDate = DateTime.Now,
                    Gender = "Male",
                    Employer = "Something Company",
                    BusinessPhone = "8887899999",
                    Email = "cmacivor82@gmail.com",
                    EducationLevel = "Masters",
                    AdvancedEducation = "none",
                    EmergencyContactName = "Someone else",
                    EmergencyContactRelationship = "relationship",
                    EmergencyContactPhone = "8048883333",
                    HowDidYouHear = "word of mouth",
                    WhyAreYouInterested = "to serve people",
                    PreviousVolunteerExperience = "various places",
                    HobbiesTalentSkills = "none",
                    CommunityChurchAffiliations = "City Church"
                };
                //unitOfWork.ApplicantRepository.AddApplicant(model);
                applicant = unitOfWork.ApplicantRepository.MapViewModelToApplicantDomainModel(model);
                unitOfWork.ApplicantRepository.AddApplicant(applicant);
                unitOfWork.ApplicantRepository.Save();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        [TestMethod]
        public void Page2()
        {
            //List<AvailableDays> availableDays = new List<AvailableDays>();
            //availableDays.Add(new PostedAvailableDays { })
            PostedAvailableDays days = new PostedAvailableDays();
            days.AvailableDayIds = new string[] { "Monday", "Tuesday" };
            PostedAvailableTimes times = new PostedAvailableTimes();
            times.AvailableTimeIDs = new string[] { "3:30 - 5:30 PM", "4:30 - 6:30 PM" };
            PostedInterestAreas areas = new PostedInterestAreas();
            areas.AvailableInterestAreaIDs = new string[] { "Middle/High School Program", "Elective Leader" };
            PostedLearningCenters centers = new PostedLearningCenters();
            centers.AvailableLearningCenterIDs = new string[] { "Highland Park Learning Center (elementary)", "L.C. Remix (middle/high)" };

            Applicant applicant = new Applicant();
            string testEmail = "cmacivor82@gmail.com";
            UnitOfWork unitOfWork = new UnitOfWork();
            Page2ViewModel viewModel = new Page2ViewModel
            {
                HaveBeenArrested = "Yes",
                MisdemeanorCharge = "You don't want to know",
                DrivingViolation = "Yes",
                DrivingViolationCharge = "something I don't know",
                FacebookRegistered = "yep",
                FacebookInvite = "no",
                HaveTransportation = "yes",
                ProvideRide = "yes",

                PostedAvailableDays = days,
                PostedAvailableTimes = times,
                PostedInterestAreas = areas,
                PostedLearningCenters = centers
            };

            //applicant = unitOfWork.ApplicantRepository.MapPage2VMToApplicantDM(viewModel, testEmail);
             unitOfWork.ApplicantRepository.UpdateApplicant(viewModel, testEmail);
             //unitOfWork.ApplicantRepository.Save();
        }


        
    }
}
