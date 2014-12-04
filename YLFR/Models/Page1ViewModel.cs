using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YLFR.ViewModels
{
    public class Page1ViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public string Employer { get; set; }

        [Required]
        [Display(Name = "Business Phone")]
        public string BusinessPhone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Highest level of education completed")]
        public string EducationLevel { get; set; }

        [Required]
        [Display(Name = "Advanced education or special job training")]
        public string AdvancedEducation { get; set; }

        [Required]
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Required]
        [Display(Name = "Emergency contact relationship")]
        public string EmergencyContactRelationship { get; set; }

        [Required]
        [Display(Name = "Emergency contact phone")]
        public string EmergencyContactPhone { get; set; }

        [Required]
        [Display(Name = "How did you hear about the Youth Life Foundation of Richmond?")]
        public string HowDidYouHear { get; set; }

        [Required]
        [Display(Name = "Why are you interested in volunteering with the Youth Life Foundation of Richmond?")]
        public string WhyAreYouInterested { get; set; }

        [Required]
        [Display(Name = "Previous volunteer experience")]
        public string PreviousVolunteerExperience { get; set; }

        [Required]
        [Display(Name = "Hobbies, special talents/skills")]
        public string HobbiesTalentSkills { get; set; }

        [Required]
        [Display(Name = "Community/Church Affiliations")]
        public string CommunityChurchAffiliations { get; set; }
    }
}