using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaCenter.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MediaCenter
{
    public class RecordController : Controller
    {
        // GET: /<controller>/
        public IActionResult ProgramGuide()
        {
            var programs = MediaCenterManager.ListPrograms();
            var tvChannels = MediaCenterManager.ListChannels();

            var model = new ProgramChannelVM { Programs = programs.ToArray(), TvChannels = tvChannels.ToArray() };

            return View(model);
            //ProgramGuideVM[] viewModels = MediaCenterManager.ListPrograms();
            //return View(viewModels);
        }

        
        public IActionResult ChannelsPW()
        {
            TvChannel[] viewModels = MediaCenterManager.ListChannels();
            //RedirectToAction("ProgramGuide");
            return PartialView(viewModels);
        }

        public IActionResult ManualRecord()
        {
            TvChannel[] viewModels = MediaCenterManager.ListChannels();
            //RedirectToAction("ProgramGuide");
            return PartialView(viewModels);
        }
    }
}
