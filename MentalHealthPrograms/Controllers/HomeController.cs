using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using DataAccess;
using Logger;

namespace MentalHealthPrograms.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadData()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
            List<MentalHealthProgram> data = new List<MentalHealthProgram>();

            //Paging Size (10,20,50,100)    
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            try
            {
                List<MentalHealthProgram> programs = MentalHealthProgramsDataAccess.GetMentalHealthPrograms();
                programs.ForEach(prog => prog.Website = !String.IsNullOrEmpty(prog.Website) ? "<a class='btn btn-info' href='" + prog.Website + "' target='_blank'>View Website</a>" : string.Empty);

                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn)
                    {
                        case "Name":
                            programs = (sortColumnDir == "asc") ? programs.OrderBy(x => x.Name_1).ToList() : programs.OrderByDescending(x => x.Name_1).ToList();
                            break;
                        case "Street 1":
                            programs = (sortColumnDir == "asc") ? programs.OrderBy(x => x.Street_1).ToList() : programs.OrderByDescending(x => x.Street_1).ToList();
                            break;
                        case "Street 2":
                            programs = (sortColumnDir == "asc") ? programs.OrderBy(x => x.Street_2).ToList() : programs.OrderByDescending(x => x.Street_2).ToList();
                            break;
                        case "City":
                            programs = (sortColumnDir == "asc") ? programs.OrderBy(x => x.City).ToList() : programs.OrderByDescending(x => x.City).ToList();
                            break;
                    }
                }

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    programs = programs.Where(m => m.Name_1.ToLower().Contains(searchValue.ToLower())).ToList();
                }

                //total number of rows count     
                recordsTotal = programs.Count();
                //Paging     
                data = programs.Skip(skip).Take(pageSize).ToList();
            }
            catch(Exception ex)
            {
                ErrorLogger.Error(ex, ex.Message);
            }

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }
    }
}