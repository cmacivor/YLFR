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
        Applicant MapViewModelToApplicantDomainModel(Page1ViewModel viewModel);
        void AddApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        void Save();
    }

    public interface ICommitmentDaysRepository
    {
        List<CommitmentDay> GetCommitmentDaysByApplicantID(int applicantID);
        void AddCommitmentDays(List<CommitmentDay> commitmentDays);
        void DeleteCommitmentDaysByApplicantID(int applicantID);
        void Save();
    }

    public interface ICommitmentTimesRepository
    {
        List<CommitmentTime> GetCommitmentTimesByApplicantID(int applicantID);
        void AddCommitmentTimes(List<CommitmentTime> commitmentTimes);
        void DeleteCommitmentTimesByApplicantID(int applicantID);
        void Save();
    }

    public interface IInterestAreasRepository
    {
        List<InterestArea> GetInterestAreasByApplicantID(int applicantID);
        void AddInterestAreas(List<InterestArea> interestAreas);
        void DeleteInterestAreaByApplicantID(int applicantID);
        void Save();
    }

    public interface ILearningCenterPreferenceRepository
    {
        List<LearningCenterPreference> GetLearningCenterPreferencesByApplicantID(int applicantID);
        void AddLearningCenterPreferenceByApplicantID(List<LearningCenterPreference> learningPreferences);
        void DeleteLearningCenterPreferenceByApplicantID(int applicantID);
        void Save();
    }

    public interface IAvailableTimesRepository
    {
        IEnumerable<AvailableTimes> GetAvailableTimes();
        Page2ViewModel GetAvailableDaysInitialModel();
        //void AddAvailableTime(AvailableTime availableTime);
        //void DeleteAvailableTime(int availableTimeID);
        //void Save();
    }

    public interface IInterestAreaTypesRepository
    {
        IEnumerable<InterestAreasTypeOptions> GetInterestAreaTypeOptions();
        //void AddInterestAreaType(InterestAreaType interestAreaType);
        //void DeleteInterestAreaType(int interestAreaTypeID);
        //void Save();
    }

    public interface ILearningCenterPreferenceTypesRepository
    {
        IEnumerable<LearningCenterPreferencesOptions> GetLearningCenterPreferenceOptions();
        //void AddLearningCenterPreferenceType(LearningCenterPreferenceType preferenceType);
        //void DeleteLearningCenterPreferenceType(int learningCenterPrefID);
        //void Save();
    }
}
