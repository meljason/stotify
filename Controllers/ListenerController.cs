using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stotify.Data;
using Stotify.Models;

namespace Stotify.Controllers
{
    public class ListenerController : Controller
    {
        private StotifyContext db = new StotifyContext();
        // GET: Listener/List
        public ActionResult List()
        {
            List<Listener> listeners = db.Listeners.SqlQuery("SELECT * from Listeners").ToList();
            return View(listeners);

        }
    }
}