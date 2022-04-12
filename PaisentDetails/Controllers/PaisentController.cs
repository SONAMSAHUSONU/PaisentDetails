using PaisentDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaisentDetails.Controllers
{
    public class PaisentController : Controller
    {
        // GET: Paisent
        public ActionResult GetPaisentDetails()
        {
            PaisentModelManager paisentModelManager = new PaisentModelManager();
            List<PaisentModel> ListData = paisentModelManager.GetPaisent();
            return View(ListData);
        }
        [HttpGet]
        public ActionResult Ins_Update_Search_Delete()
        {
            PaisentModel paisentModel = new PaisentModel();
            List<BloodGroup> bloodGroups = new List<BloodGroup>();
            bloodGroups.Add(new BloodGroup() { BG_Name = "B+",BG_id=101 });
            bloodGroups.Add(new BloodGroup() { BG_Name = "A+", BG_id = 102 });
            bloodGroups.Add(new BloodGroup() { BG_Name = "B-", BG_id = 103 });
            bloodGroups.Add(new BloodGroup() { BG_Name = "o+", BG_id = 104 });
            foreach (var item in bloodGroups)
            {
                //paisentModel.BG = new List<SelectListItem>

            {
                    new SelectListItem { Value = item.BG_Name, Text = item.BG_Name };
                //new SelectListItem{Value="o-ve",Text="o-Ve" },
                //new SelectListItem{Value="b+ve",Text="b+Ve" },
                //new SelectListItem{Value="b-ve",Text="b-Ve" },

            };


            }
            ViewResult vr = View("PaisentDetailsView", paisentModel);
            ActionResult ar = vr;
            return ar;

        }
        [HttpPost]
        public ActionResult Ins_Update_Search_Delete(PaisentModel paisentModel, string x)
        {
            if (x == "Insert")
            {
                PaisentModelManager paisentModelManager = new PaisentModelManager();
                paisentModelManager.InsertPaisent(paisentModel);
                RedirectToRouteResult rr = RedirectToAction("GetPaisentDetails", "Paisent");
                ActionResult ar = rr;
                return ar;
            }
            if (x == "Update")
            {
                PaisentModelManager paisentModelManager = new PaisentModelManager();
                paisentModelManager.UpdatePaisent(paisentModel);
                RedirectToRouteResult rr = RedirectToAction("GetPaisentDetails", "Paisent");
                ActionResult arr = rr;
                return rr;
            }
            if (x == "Delete")
            {
                PaisentModelManager paisentModelManager = new PaisentModelManager();
                paisentModelManager.DeletePaisent(paisentModel);
                RedirectToRouteResult rr = RedirectToAction("GetPaisentDetails", "Paisent");
                ActionResult arr = rr;
                return rr;
            }
            if (x == "Search")
            {
                return RedirectToAction("SearchPaisent", "Paisent", paisentModel);
            }
            return null;

        }
        public ActionResult SearchPaisent(PaisentModel paisentModel)
        {
            PaisentModelManager paisentModelManager = new PaisentModelManager();
            PaisentModel paisentModel1 = paisentModelManager.SearchPaisent(paisentModel);
            return View("PaisentDetailsView", paisentModel1);
        }

    }
    public class BloodGroup
    {
        public int BG_id { get; set; }
        public string BG_Name { get; set; }
    }
}