using CVC_Poc.Models;
using CVC_Poc.Models.Constant;
using CVC_Poc.Models.Domain;
using CVC_Poc.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CVC_Poc.Controllers
{
    public class DisplayObjectController : Controller
    {
        private readonly Context _db;
        protected readonly IConfiguration Configuration;
        public DisplayObjectController(IConfiguration configuration)
        {
            Configuration = configuration;
            _db = new Context(Configuration);
        }
        // GET: DisplayObjectController
        public ActionResult Index()
        {
            var objectList = _db.DisaplayObjects.ToList();
            List<DisplayObjectVm> model = new List<DisplayObjectVm>();
            foreach (var val in objectList)
            {
                var data = new DisplayObjectVm
                {
                    Fields = val.Fields,
                    Name = val.Name,
                    TypeName = Enum.GetName(typeof(DisplayType), val.Type),
                    UserName = CVCConstants.Users.FirstOrDefault(c => c.Id == val.UserId)?.Name
                };
                model.Add(data);
            }
            return View(model);
        }

        // GET: DisplayObjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisplayObjectController/Create
        public ActionResult Create()
        {
            DisplayObjectVm displayObject = new DisplayObjectVm();
            displayObject.FieldList = new List<SelectListItem>();
            foreach (PropertyInfo p in typeof(Company).GetProperties())
            {
                displayObject.FieldList.Add(new SelectListItem { Text = p.Name, Value = p.Name });
            }
            
            return View(displayObject);
        }

        // POST: DisplayObjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisplayObjectVm display)
        {
            try
            {
                DisplayObject display1 = new DisplayObject
                {
                    DeveloperId = 1,
                    CreatedOn = DateTime.UtcNow,
                    Fields = display.Fields,
                    Name = display.Name,
                    Type = (DisplayType)Convert.ToInt32(display.TypeVal),
                    UpdatedOn = DateTime.UtcNow,
                    UserId = display.UserId
                };
                _db.DisaplayObjects.Add(display1);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisplayObjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisplayObjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisplayObjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisplayObjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
