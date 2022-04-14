using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Mission13.Models;

namespace Mission13.Components
{
    public class LabelViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public LabelViewComponent(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];
            var blah = RouteData?.Values["teamName"];
            // return view
            return View(blah); 
        }
    }
}
