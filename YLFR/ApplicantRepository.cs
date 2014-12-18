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

        public void AddApplicant(Applicant applicant)
        {
            entities.Applicants.Add(applicant);
        }

        public void UpdateApplicant(Applicant applicant)
        {
            
        }

        public void Save()
        {
            entities.SaveChanges();
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