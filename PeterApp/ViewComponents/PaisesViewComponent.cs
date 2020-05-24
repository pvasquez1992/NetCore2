using Microsoft.AspNetCore.Mvc;
using PeterApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterApp.ViewComponents
{
    public class PaisesViewComponent : ViewComponent
    {
        private readonly IPaisRepository _paisRepository;
        public PaisesViewComponent(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public IViewComponentResult Invoke()
        {
            var paises = _paisRepository.GetPaises();
            return View(paises);

        }
    }
}
