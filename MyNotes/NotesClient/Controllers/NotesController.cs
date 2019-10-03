using Newtonsoft.Json;
using NotesClient.Helpers;
using NotesClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NotesClient.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            IEnumerable<MvcNotesModel> notesList;

            HttpResponseMessage responseMessage = GlobalVariables.webApiClient.GetAsync("/api/Notes").Result;
            notesList = responseMessage.Content.ReadAsAsync<IEnumerable<MvcNotesModel>>().Result;

            return View(notesList);
        }

        // GET: Notes/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<MvcNotesModel> notesList;

            HttpResponseMessage responseMessage = GlobalVariables.webApiClient.GetAsync($"/api/Notes/{id}").Result;
            notesList = responseMessage.Content.ReadAsAsync<IEnumerable<MvcNotesModel>>().Result;


            return View(notesList);
        }

        // GET: Notes/Create
        public ActionResult Create(MvcNotesModel notesModel)
        {
            if (notesModel.UserID > 0)
            {
                string result = string.Empty;
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(notesModel), Encoding.UTF8, "application/json");
                
                var response = GlobalVariables.webApiClient.PostAsync("api/notes/", httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<string>(responseData);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}