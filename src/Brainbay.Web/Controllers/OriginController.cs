using Brainbay.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainbay.Web.Controllers
{
    public class OriginController : Controller
    {
        private IOriginBusiness _originBusiness;
        public OriginController(IOriginBusiness originBusiness)
        {
            _originBusiness = originBusiness; 
        }
        public async Task<IActionResult> Index()
        {

            var result = await _originBusiness.GetAllOriginsAsync();
            if (result.Status == Common.OperationStatus.Succeeded)
            {
                return View(result.Result);
            }
            else
            {
                return View();
            }
        }
    }
}
