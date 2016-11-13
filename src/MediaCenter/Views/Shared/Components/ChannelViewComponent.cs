using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaCenter.Models;

namespace MediaCenter.Views.Shared.Components
{
    public class ChannelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            TvChannel[] viewModels = MediaCenterManager.ListChannels();
            //RedirectToAction("ProgramGuide");
            return View(viewModels);
        }
    }
}
