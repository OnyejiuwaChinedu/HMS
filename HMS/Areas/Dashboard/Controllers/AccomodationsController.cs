using HMS.Areas.Dashboard.ViewModels;
using HMS.Entities;
using HMS.Services;
using HMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationsController : Controller
    {
        AccomodationPackagesService accomodationPackagesServices = new AccomodationPackagesService();
        AccomodationsService accomodationsService = new AccomodationsService();

        public ActionResult Index(string searchTerm, int? accomodationPackageID, int? page)
        {
            int recordSize = 5;
            page = page ?? 1;

            AccomodationsListingModel model = new AccomodationsListingModel();

            model.SearchTerm = searchTerm;
            model.AccomodationPackageID = accomodationPackageID;
            model.AccomodationPackages = accomodationPackagesServices.GetAllAccomodationPackages();

            model.Accomodations = accomodationsService.SearchAccomodations(searchTerm, accomodationPackageID, page.Value, recordSize);

            var totalRecords = accomodationsService.SearchAccomodationsCount(searchTerm, accomodationPackageID);

            model.Pager = new Pager(totalRecords, page, recordSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {

            AccomodationActionModel model = new AccomodationActionModel();

            if (ID.HasValue)// edit
            {
                var accomodation = accomodationsService.GetAllAccomodationByID(ID.Value);

                model.ID = accomodation.ID;
                model.Name = accomodation.Name;
                model.Description = accomodation.Description;
                model.AccomodationPackageID = accomodation.AccomodationPackageID;
            }

            model.AccomodationPackages = accomodationPackagesServices.GetAllAccomodationPackages();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;
            if (model.ID > 0) // tyring to edit model
            {
                var accomPack = accomodationsService.GetAllAccomodationByID(model.ID);

                accomPack.AccomodationPackageID = model.AccomodationPackageID;
                accomPack.Name = model.Name;
                accomPack.Description = model.Description;


                result = accomodationsService.UpdateAccomodation(accomPack);
            }
            else // create the record
            {
                Accomodation accomodation = new Accomodation();
                accomodation.AccomodationPackageID = model.AccomodationPackageID;
                accomodation.Name = model.Name;
                accomodation.Description = model.Description;


                result = accomodationsService.SaveAccomodation(accomodation);

            }

            if (result)
            {

                json.Data = new { Success = true };
            }
            else
            {

                json.Data = new { Success = false, Message = "Unable to perform action on  Accomodation Package" };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {

            AccomodationActionModel model = new AccomodationActionModel();

            var accomodation = accomodationsService.GetAllAccomodationByID(ID);

            model.ID = accomodation.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodation = accomodationsService.GetAllAccomodationByID(model.ID);

            result = accomodationsService.DeleteAccomodation(accomodation);

            if (result)
            {

                json.Data = new { Success = true };
            }
            else
            {

                json.Data = new { Success = false, Message = "Unable to perform action on  Accomodation" };
            }
            return json;
        }
    }
}