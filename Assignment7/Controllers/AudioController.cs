using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class AudioController : Controller
    {
        Manager m = new Manager();

        // GET: Audio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Audio/Details/5
        [Route("clip/{id}")]
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var o = m.TrackAudioGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else if(o.AudioContentType == null)
            {
                // Without this, an exception will occur if you view the details of a track
                // that doesn't have a clip uploaded
                // o.AudioContentType will be null (since there's nothing in the DB column)
                // and you can't return File() when content type is null

                return new EmptyResult();
            }
            else
            {
                return File(o.Audio, o.AudioContentType);
            }
        }
    }
}
