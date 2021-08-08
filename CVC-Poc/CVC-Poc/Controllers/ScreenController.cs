using CVC_Poc.Models;
using CVC_Poc.Models.Constant;
using CVC_Poc.Models.Domain;
using CVC_Poc.Models.ViewModels;
using CVC_Poc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CVC_Poc.Controllers
{
    public class ScreenController : Controller
    {
        // GET: ScreenController
        private readonly Context _db;
        protected readonly IConfiguration Configuration;
        //private UserSession _user;
        public ScreenController(IConfiguration configuration)
        {
            Configuration = configuration;
            _db = new Context(Configuration);
            //_user = ContextHelper();
        }
        private UserSession ContextHelper()
        {
            var user = HttpContext?.Session.GetString(CVCConstants.SessionName);
            return user != null ? JsonConvert.DeserializeObject<UserSession>(user) : new UserSession { Id = 0, Roles = 0 };
        }
        public ActionResult Index()
        {
            var screens = _db.DisaplayScreens.ToList();
            List<ScreenVm> model = new List<ScreenVm>();
            foreach (var val in screens)
            {
                ScreenVm screen = new ScreenVm
                {
                    Name = val.Name,
                    TemplateName = Enum.GetName(typeof(TemplateTypes), val.Template),
                    CustomerName = CVCConstants.Users.FirstOrDefault(c => c.Id == val.UserId)?.Name
                };
                model.Add(screen);
            }
            return View(model);
        }

        public ActionResult GetMyScreens()
        {
            var screens = _db.DisaplayScreens.Where(c => c.UserId == ContextHelper().Id).ToList();
            List<ScreenMenu> menus = new List<ScreenMenu>();
            foreach (var val in screens)
            {
                ScreenMenu menu = new ScreenMenu
                {
                    Id = val.ScreenId,
                    Name = val.Name
                };
                menus.Add(menu);
            }
            return Ok(menus);
        }

        public ActionResult MyScreen(int screenId)
        {
            var screenById = _db.DisaplayScreens.FirstOrDefault(c => c.ScreenId == screenId);
            var objects = screenById.ObjectPlacements.Select(c => c.Objectid).ToList();
            var displayObject = _db.DisaplayObjects.Where(c => objects.Contains(c.ObjectId)).ToList();
            var listType = displayObject.FirstOrDefault(c => c.Type == DisplayType.List);
            var formType = displayObject.FirstOrDefault(c => c.Type == DisplayType.Forms);

            //for list
            var companyValue = _db.Companies.Where(c => c.UserId == screenById.UserId).ToList();
            ScreenLoad screen = new ScreenLoad
            {
                ScreenName = screenById?.Name,
                TemplateName = Enum.GetName(typeof(TemplateTypes), screenById.Template),
                ElementListType = new ElementListTypeVm
                {
                    Headers = listType.Fields,
                    ColumnCount = listType.Fields.Count,
                    RowCount = companyValue.Count
                },
            };
            int row = 0;
            foreach (var val in companyValue)
            {
                int j = 0;
                for (int i = 0; i < listType.Fields.Count; i++)
                {
                    var data = new Cells { Column = j,Row =row , Text = GetColumn(val, listType.Fields[i]) };
                    screen.ElementListType.Cells.Add(data);
                    j++;
                }
                row++;
            }

            for (int i = 0; i < formType.Fields.Count; i++)
            {
                var propertyType = companyValue[0].GetType().GetProperty(formType.Fields[i]);
                ElementFieldType fieldType = new ElementFieldType
                {
                    FieldName = formType.Fields[i],
                    FieldType = GetFieldType(propertyType)
                };
                screen.ElementFormTypes.Add(fieldType);
            }

            return View(screen.TemplateName, screen);
        }

        // GET: ScreenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScreenController/Create
        public ActionResult Create()
        {
            ScreenVm model = new ScreenVm();
            return View(model);
        }

        public ActionResult ObjectList(int userId)
        {
            var displayObject = _db.DisaplayObjects.Where(c => c.UserId == userId).ToList();
            return Ok(displayObject);
        }

        // POST: ScreenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScreenVm model)
        {
            try
            {
                DisplayScreen displayScreen = new DisplayScreen
                {
                    DeveloperId = 1,
                    CreatedOn = DateTime.UtcNow,
                    Name = model.Name,
                    Template = (TemplateTypes)Convert.ToInt32(model.TemplateTypes),
                    UserId = model.UserId,
                    ObjectPlacements = new List<ObjectPlacement>
                    {
                        new ObjectPlacement { Objectid = model.Element1, PlacedAt = 1},
                        new ObjectPlacement { Objectid = model.Element2, PlacedAt = 2 }
                    }
                };
                _db.DisaplayScreens.Add(displayScreen);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ScreenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScreenController/Edit/5
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

        // GET: ScreenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScreenController/Delete/5
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

        #region Private methods
        private string GetColumn<T>(T items, string columnName)
        {
            var value = items.GetType().GetProperty(columnName).GetValue(items)?.ToString();
            //.Select(x => x.GetType().GetProperty(columnName).GetValue(x));
            return value;
        }

        private string GetFieldType(PropertyInfo property)
        {
            if (property.PropertyType == typeof(int))
                return "Number";
            else if (property.PropertyType == typeof(DateTime))
                return "Date";
            else
                return "Text";
        }
        #endregion
    }
}
