using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    public class URLController : Controller
    {
        private UrlBs objBs;
        private CategoryBs objCatBs;
        private UserBs objUserBs;

        public URLController()
        {
            objBs = new UrlBs();
            objCatBs = new CategoryBs();
            objUserBs = new UserBs();
        }

        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objCatBs.GetALL().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objUserBs.GetALL().ToList(), "UserId", "UserEmail");
            return View();
        }
        //
        // GET: /User/URL/


        [HttpPost]
        public ActionResult Create(tbl_Url myUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.Insert(myUrl);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objCatBs.GetALL().ToList(), "CategoryId", "CategoryDesc");
                    ViewBag.UserId = new SelectList(objUserBs.GetALL().ToList(), "UserId", "UserEmail");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed: " + e1.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
