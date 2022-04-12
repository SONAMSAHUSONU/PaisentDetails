using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaisentDetails.Models
{
    public class PaisentModel
    {
        public string p_id { get; set; }
        public string p_Fname { get; set; }
        public string p_Lname { get; set; }
        public string p_Mobile { get; set; }
        public string p_Age { get; set; }
        public string p_Email { get; set; }
        public List<SelectListItem> BloodGroup { get; set; }

        public List<SelectListItem> BG { get; set; }

    }
}