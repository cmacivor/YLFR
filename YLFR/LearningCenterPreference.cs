//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YLFR
{
    using System;
    using System.Collections.Generic;
    
    public partial class LearningCenterPreference
    {
        public int LearningCenterPreferenceID { get; set; }
        public int ApplicantID { get; set; }
        public string LearningCenterPreference1 { get; set; }
    
        public virtual Applicant Applicant { get; set; }
    }
}