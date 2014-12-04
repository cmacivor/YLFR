using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YLFR
{
    public interface IApplicantRepository
    {
        List<Applicant> GetAllApplicants();
        Applicant GetApplicantByID(int id);
        void AddApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        void Save();
    }

    public interface ICommitmentDaysRepository
    {
        List<CommitmentDay> GetCommitmentDaysByApplicantID(int applicantID);
        void AddCommitmentDaysByApplicantID(int applicantID);
        void DeleteCommitmentDaysByApplicantID(int applicantID);
        void Save();
    }

    public interface ICommitmentTimesRepository
    {
        List<CommitmentTime> GetCommitmentTimesByApplicantID(int applicantID);
        void AddCommitmentTimesByApplicantID(int applicantID);
        void DeleteCommitmentTimesByApplicantID(int applicantID);
        void Save();
    }
}
