using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YLFR
{
    public class UnitOfWork
    {
        private MentorshipAppllicantsEntities entities = null;

        //This will be called from controller default constructor
        public UnitOfWork()
        {
            entities = new MentorshipAppllicantsEntities();
            ApplicantRepository = new ApplicantRepository(entities);
        }


        // This will be created from test project and passed on to the
        // controllers parameterized constructors
        public UnitOfWork(IApplicantRepository applicantRepo)
        {
            ApplicantRepository = applicantRepo;
        }


        public IApplicantRepository ApplicantRepository
        {
            get;
            private set;
        }
    }
}