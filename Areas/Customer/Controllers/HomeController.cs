using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseStudy.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        CaseStudyEntities dbObj = new CaseStudyEntities();
        int a;
        // GET: Customer/Home
        public ActionResult Index()
        {
            var data = TempData["UserId"];
            Session["userId"] = data;
            return View();
        }
        [HttpGet]
      
        public ActionResult Application()
        {
            CustomerPolicyDetail users = new CustomerPolicyDetail();
            List<PolicyDetail> list = new List<PolicyDetail>();
            var items = dbObj.PolicyDetails.ToList();
            ViewBag.Name = new SelectList(items, "PolicyId", "PolicyName");
            
            List<object> tempLIst = new List<object>();
            tempLIst.Add("HalfYearly");
            tempLIst.Add("Quarterly");
            tempLIst.Add("Yeary");

            ViewBag.Term = new SelectList(tempLIst, "policyTerm");
            List<object> Relation = new List<object>();
            Relation.Add("Father");
            Relation.Add("Mother");
            Relation.Add("Wife");
            Relation.Add("Husband");
            ViewBag.Rel = new SelectList(Relation, "relation");


            if (users != null)

                return View();
            else
                return Content("OOPS....<br/>There are some network issues...please connect after sometime");
        }
        [HttpPost]
        public ActionResult GetMaturity(int PolicyId)
        {
            Session["PolicyId"] = PolicyId;
            CaseStudyEntities dbObj = new CaseStudyEntities();
            List<PolicyCoverage> selectlist = dbObj.PolicyCoverages.Where(x => x.PolicyID == PolicyId).ToList();
            ViewBag.PolicyCovAmount = new SelectList(selectlist, "PolicyAmount", "PolicyAmount");
            
            return PartialView("GetMaturity");
           
        }
        [HttpGet]
        public ActionResult Duration(int PolicyAmount)
        {
            Session["PolicyAmount"] = PolicyAmount;
            CaseStudyEntities dbObj = new CaseStudyEntities();
            // int Policyamount = Convert.ToInt32(PolicyAmount);
            //List<PolicyCoverage> selectlist = dbObj.PolicyCoverages.Where(x => x.PolicyAmount == PolicyAmount).ToList();
            //ViewBag.Duration = new SelectList(selectlist, "PolicyDuration", "PolicyDuration");
            PolicyCoverage PolicyData = dbObj.PolicyCoverages.FirstOrDefault(m => m.PolicyAmount == PolicyAmount);
            List<int> Policydata = new List<int>();
            Policydata.Add((int)PolicyData.PolicyDuration);
            Policydata.Add((int)PolicyData.PolicyCoverageAmount);
            Session["Duration"] = PolicyData.PolicyDuration;
            //return View();
            return Json(Policydata, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UserTerms(string PolicyTerm)
        {
            string Term = PolicyTerm;
            int Duration = (int)Session["Duration"];
            int PolicyAmount = (int)Session["PolicyAmount"];
            int UserTerms = 0;
            int PremiumAmount = 0;
            var PolicyId = (int)Session["PolicyId"];
            var UserId = dbObj.PolicyDetails.FirstOrDefault(m => m.PolicyID == PolicyId);
            a = (int)UserId.UserID;
            Session["ManagerId"] = a;
            //var Managerdata = from c in dbObj.UsersRegistrationDetails where c.UserID == a select c.Username;
            var Managername = dbObj.UsersRegistrationDetails.FirstOrDefault(m => m.UserID == a);
            string Manager = Managername.Username;
            if (Term == "Half Yearly")
            {
                UserTerms = Duration * 2;

            }
            else if (Term == "Quarter Yearly")
            {
                UserTerms = Duration * 3;
            }
            else
            {
                UserTerms = Duration * 1;
            }
            PremiumAmount = PolicyAmount / UserTerms;
            List<object> TermDetails = new List<object>();
            TermDetails.Add(UserTerms);
            TermDetails.Add(PremiumAmount);
            TermDetails.Add(Manager);
            //return View();
            return Json(TermDetails, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Application(PolicyDetailCoverageModel Model)
        {
            CustomerPolicyDetail usertable = new CustomerPolicyDetail();
            // PolicyDetailCoverageModel Model = new PolicyDetailCoverageModel();
            if (ModelState.IsValid)
            {
                if (dbObj != null)
                {
                    //dbObj.CustomerPolicyDetails.Add(userdetails);
                    usertable.UserID = (int)Session["userId"];
                    usertable.PolicyID = Model.PolicyID;
                    usertable.RegisterdDate = Model.RegisterdDate;
                    usertable.Duration = Model.PolicyDuration;
                    usertable.PolicyAmount = Model.Srlno;
                    usertable.PolicyTerm = Model.PolicyTerm;
                    usertable.UserNoTerms = Model.UserNoTerms;
                    usertable.PremiumAmount = Model.PremiumAmount;
                    usertable.NomineeName = Model.NomineeName;
                    usertable.NomineeRelation = Model.NomineeRelation;
                    usertable.ManagerID = (int)Session["ManagerId"];
                    Random R = new Random();
                    int num = R.Next();
                    usertable.RegisteredID = num;
                    TempData["msg"] = "Your Registration Id is :" + num;
                    // TempData.Keep("message");
                    // ViewBag.SuccessMessage = TempData["msg"];
                    dbObj.CustomerPolicyDetails.Add(usertable);
                    dbObj.SaveChanges();
                    //return View(Model);
                    return RedirectToAction("Index", "Home", new { area = "Customer" });
                }
                else
                    return Content("Registration is not successful...Please try again...");
            }
            else
                return View(Model);
        }
    }
}