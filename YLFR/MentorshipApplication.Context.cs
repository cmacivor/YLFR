﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MentorshipAppllicantsEntities : DbContext
    {
        public MentorshipAppllicantsEntities()
            : base("name=MentorshipAppllicantsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<CommitmentDay> CommitmentDays { get; set; }
        public virtual DbSet<CommitmentTime> CommitmentTimes { get; set; }
        public virtual DbSet<InterestArea> InterestAreas { get; set; }
        public virtual DbSet<LearningCenterPreference> LearningCenterPreferences { get; set; }
    }
}