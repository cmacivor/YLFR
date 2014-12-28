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
            //OptionsRepository = new OptionsRepository(entities);

            AvailableTimesRepository = new AvailableTimesRepository(entities);

            CommitmentTimesRepository = new CommitmentTimeRepository(entities);
            CommitmentDaysRepository = new CommitmentDayRepository(entities);
            InterestAreasRepository = new InterestAreaRepository(entities);
            LearningCenterPreferenceRepository = new LearningCenterPreferenceRepository(entities);
        }


        // This will be created from test project and passed on to the
        // controllers parameterized constructors
        public UnitOfWork(IApplicantRepository applicantRepo, ICommitmentDaysRepository availableDays, ICommitmentTimesRepository commitmentTimes, IInterestAreasRepository interestAreas, ILearningCenterPreferenceRepository learningCenterPreferences, IAvailableTimesRepository availableTimes)
        {
            ApplicantRepository = applicantRepo;
            CommitmentDaysRepository = availableDays;
            CommitmentTimesRepository = commitmentTimes;
            InterestAreasRepository = interestAreas;
            LearningCenterPreferenceRepository = learningCenterPreferences;
            AvailableTimesRepository = availableTimes;
        }

        

        public IApplicantRepository ApplicantRepository
        {
            get;
            private set;
        }

        public ICommitmentDaysRepository CommitmentDaysRepository
        {
            get;
            private set;
        }

        public ICommitmentTimesRepository CommitmentTimesRepository
        {
            get;
            private set;
        }

        public IInterestAreasRepository InterestAreasRepository
        {
            get;
            private set;
        }

        public ILearningCenterPreferenceRepository LearningCenterPreferenceRepository
        {
            get;
            private set;
        }

        public IAvailableTimesRepository AvailableTimesRepository
        {
            get;
            private set;
        }
       
    }
}