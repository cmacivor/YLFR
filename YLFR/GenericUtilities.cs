﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YLFR
{
    public class GenericUtilities
    {
        MentorshipAppllicantsEntities entities = null;
        private static string userID;
        
        public static string UserID
        {
            get { return userID; }
            set 
            { 
                //userID = value;
                userID = System.Web.HttpContext.Current.Session["userID"].ToString();
            }
        }

        private int applicantID;

        public int ApplicantID
        {
            get { return applicantID; }
            set 
            {
                applicantID = entities.Applicants.FirstOrDefault(x => x.Email == UserID).ApplicantId;
            }
        }
        

        public GenericUtilities()
        {
            this.entities = new MentorshipAppllicantsEntities();
        }
        
    }
}