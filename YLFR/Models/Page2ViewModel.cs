using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace YLFR.ViewModels
{
    public class Page2ViewModel
    {
        [Required]
        [Display(Name="Have you ever been arrested or charged with a misdemeanor?")]
        public string HaveBeenArrested { get; set; }


        [Display(Name="If so, what was the charge?")]
        public string MisdemeanorCharge { get; set; }

        [Required]
        [Display(Name="Have you ever had a driving violation?")]
        public string DrivingViolation { get; set; }

        [Display(Name="If so, what was the charge?")]
        public string DrivingViolationCharge { get; set; }

        [Required]
        [Display(Name="Are you registered on Facebook?")]
        public string FacebookRegistered { get; set; }

        [Display(Name="May we invite you to be added as a group member of the Youth Life Center Center group on Facebook?")]
        public string FacebookInvite { get; set; }

        [Required]
        [Display(Name="Do you have your own transportation?")]
        public string HaveTransportation { get; set; }

        [Display(Name="Are you able to provide a ride to other mentors?")]
        public string ProvideRide { get; set; }

        [Display(Name="If you marked 'Other', please specify.")]
        public string  OtherInterestTypeSpecifics { get; set; }

        public SelectList DropDownListOptions { get; set; }

        public IEnumerable<AvailableDays> AvailableDays { get; set; }
        public IEnumerable<AvailableDays> SelectedAvailableDays { get; set; }
        public PostedAvailableDays PostedAvailableDays { get; set; }

        public IEnumerable<AvailableTimes> AvailableTimes { get; set; }
        public IEnumerable<AvailableTimes> SelectedAvailableTimes  { get; set; }
        public PostedAvailableTimes  PostedAvailableTimes { get; set; }

        public IEnumerable<InterestAreasTypeOptions> AvailableInterestAreas { get; set; }
        public IEnumerable<InterestAreasTypeOptions> SelectedInterestAreas { get; set; }
        public PostedInterestAreas PostedInterestAreas { get; set; }

        public IEnumerable<LearningCenterPreferencesOptions> AvailableLearningCenters { get; set; }
        public IEnumerable<LearningCenterPreferencesOptions> SelectedLearningCenters { get; set; }
        public PostedLearningCenters PostedLearningCenters { get; set; }
    }


    public class PostedAvailableDays
    {
        public string[] AvailableDayIds { get; set; }
    }

    public class PostedAvailableTimes
    {
        public string[] AvailableTimeIDs { get; set; }
    }

    public class PostedInterestAreas
    {
        public string[] AvailableInterestAreaIDs { get; set; }
    }

    public class PostedLearningCenters
    {
        public string[] AvailableLearningCenterIDs { get; set; }
    }
}