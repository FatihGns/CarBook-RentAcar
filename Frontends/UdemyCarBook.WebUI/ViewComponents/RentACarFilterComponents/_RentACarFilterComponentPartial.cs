﻿using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            v = "AAA";
            TempData["value"] = v;

            return View();
        }
    }
}
