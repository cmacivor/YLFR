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
    
    public partial class CommitmentTime
    {
        public int CommitmentTimeID { get; set; }
        public int ApplicantID { get; set; }
        public string CommitmentTime1 { get; set; }
    
        public virtual Applicant Applicant { get; set; }
    }
}