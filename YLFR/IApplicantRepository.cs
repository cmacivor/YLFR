using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YLFR.Models;
using YLFR.ViewModels;

namespace YLFR
{
    public interface IApplicantRepository
    {
        List<Applicant> GetAllApplicants();
        Applicant GetApplicantByID(int id);
        Applicant GetApplicantByEmailAddress(string email);
        Applicant MapViewModelToApplicantDomainModel(Page1ViewModel viewModel);
        Applicant MapPage2VMToApplicantDM(Page2ViewModel vm, string email);
        void AddApplicant(Applicant applicant);
        void UpdateApplicant(Page2ViewModel vm, string email);
        void Save();
    }

    public interface ICommitmentDaysRepository
    {
        List<CommitmentDay> GetCommitmentDaysByApplicantID(int applicantID);
        void AddCommitmentDays(PostedAvailableDays commitmentDays, string email);
        void DeleteCommitmentDaysByApplicantID(int applicantID);
        void Save();
    }

    public interface ICommitmentTimesRepository
    {
        List<CommitmentTime> GetCommitmentTimesByApplicantID(int applicantID);
        void AddCommitmentTimes(PostedAvailableTimes commitmentTimes, string email);
        void DeleteCommitmentTimesByApplicantID(int applicantID);
        void Save();
    }

    public interface IInterestAreasRepository
    {
        List<InterestArea> GetInterestAreasByApplicantID(int applicantID);
        void AddInterestAreas(PostedInterestAreas interestAreas, string email);
        void DeleteInterestArea(InterestArea interestArea);
        List<InterestArea> GetInterestAreasByApplicantEmail(string email);
        void Save();
    }

    public interface ILearningCenterPreferenceRepository
    {
        List<LearningCenterPreference> GetLearningCenterPreferencesByApplicantID(int applicantID);
        void AddLearningCenterPreferenceByApplicantID(PostedLearningCenters learningPreferences, string email);
        void DeleteLearningCenterPreferenceByApplicantID(int applicantID);
        void Save();
    }

    public interface IAvailableTimesRepository
    {
        IEnumerable<AvailableTimes> GetAvailableTimes();
        Page2ViewModel GetAvailableDaysInitialModel();
        //void AddAvailableTime(PostedAvailableTimes availableTimes, string email);
        //void DeleteAvailableTime(int availableTimeID);
        //void Save();
    }

    public interface IInterestAreaTypesRepository
    {
        IEnumerable<InterestAreasTypeOptions> GetInterestAreaTypeOptions();
        //void AddInterestAreaType(PostedInterestAreas interestAreas, string email);
        //void DeleteInterestAreaType(int interestAreaTypeID);
        //void Save();
    }

    public interface ILearningCenterPreferenceTypesRepository
    {
        IEnumerable<LearningCenterPreferencesOptions> GetLearningCenterPreferenceOptions();
        //void AddLearningCenterPreferenceType(PostedLearningCenters learningCenterPreferences, string email);
        //void DeleteLearningCenterPreferenceType(int learningCenterPrefID);
        //void Save();
    }
}
