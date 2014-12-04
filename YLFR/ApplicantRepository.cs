using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}