using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YLFR.Models;
using YLFR.ViewModels;

namespace YLFR
{
    public class ApplicantRepository : IApplicantRepository
    {
        MentorshipAppllicantsEntities entities = null;

        public ApplicantRepository(MentorshipAppllicantsEntities entities)
        {
            this.entities = entities;
        }

        public List<Applicant> GetAllApplicants()
        {
            return entities.Applicants.ToList();
        }

        public Applicant GetApplicantByID(int id)
        {
            return entities.Applicants.SingleOrDefault(x => x.ApplicantId == id);
        }

        public Applicant GetApplicantByEmailAddress(string email)
        {
            return entities.Applicants.SingleOrDefault(x => x.Email == email);
        }

        public void AddApplicant(Applicant applicant)
        {
            entities.Applicants.Add(applicant);
        }

        public void UpdateApplicant(Page2ViewModel vm, string email)
        {
            //Applicant page2Applicant = GetApplicantByEmailAddress(email);
            Applicant applicant = MapPage2VMToApplicantDM(vm, email);
            
        }

        public void Save()
        {
            entities.SaveChanges();
        }

        public Applicant MapPage2VMToApplicantDM(Page2ViewModel vm, string email)
        {
            Applicant applicant = new Applicant();
            applicant = GetApplicantByEmailAddress(email);
            applicant.HaveYouBeenArrested = vm.HaveBeenArrested;
            applicant.WhatWasTheCharge = vm.MisdemeanorCharge;
            applicant.DrivingViolation = vm.DrivingViolation;
            applicant.DrivingViolationCharge = vm.DrivingViolationCharge;
            applicant.FacebookRegistered = vm.FacebookRegistered;
            applicant.MayWeInvite = vm.FacebookInvite;
            applicant.DoYouHaveTransportation = vm.HaveTransportation;
            applicant.ProvideRide = vm.ProvideRide;
            


            return applicant;
        }

        public Applicant MapViewModelToApplicantDomainModel(Page1ViewModel vm)
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
            return applicant;
        }
    }
}