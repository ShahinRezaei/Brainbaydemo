using Brainbay.Business;
using Brainbay.Common.Entities;
using Brainbay.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainbay.Web.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterBusiness _characterBusiness;
        private IStatusBusiness _statusBusiness;
        private ISpeciesBusiness _speciesBusiness;
        private IOriginBusiness _originBusiness;
        private ILocationBusiness _locationBusiness;
        private IGenderBusiness _genderBusiness;
        private ICharacterTypeBusiness _characterTypeBusiness;

        public CharacterController(ICharacterBusiness characterBusiness, IStatusBusiness statusBusiness,
            ISpeciesBusiness speciesBusiness,
            IOriginBusiness originBusiness,
            ILocationBusiness locationBusiness,
            IGenderBusiness genderBusiness,
            ICharacterTypeBusiness characterTypeBusiness)
        {
            _characterBusiness = characterBusiness;
            _statusBusiness = statusBusiness;
            _speciesBusiness = speciesBusiness;
            _originBusiness = originBusiness;
            _locationBusiness = locationBusiness;
            _genderBusiness = genderBusiness;
            _characterTypeBusiness = characterTypeBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PlanetCharacters(string plantName)
        {
            ViewBag.PlanetName = plantName;
            var result = await _characterBusiness.GetAllCharactersIncludeAsync(e => e.Origin.Name == plantName, "Origin");
            return View(result.Result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await generate();
            return View(model); 
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Image,Url,Status,Species,Location,Gender,Origin")] CharacterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fill in the blank boxes with appropriate value");
                model = await generate();
                return View(model);
            }

            var status = await _statusBusiness.GetByIdAsync(model.Status);
            var species = await _speciesBusiness.GetByIdAsync(model.Species);
            var gender = await _genderBusiness.GetByIdAsync(model.Gender);
            var location = await _locationBusiness.GetByIdAsync(model.Location);
            var origin = await _originBusiness.GetByIdAsync(model.Origin);
            var characterType = await _characterTypeBusiness.GetByIdAsync(model.CharacterType);

            var character = new Character()
            {
                ID = Guid.NewGuid(),
                Name = model.Name,
                Image = model.Image,
                Url = model.Url,
                Status = status.Result,
                Species = species.Result,
                Gender = gender.Result,
                Location = location.Result, 
                Origin = origin.Result, 
                CharacterType = characterType.Result
            };

            await _characterBusiness.SaveCharacterAsync(character);

            return View("Index");
        }


        private async Task<CharacterViewModel> generate()
        {
            var statusList = await _statusBusiness.GetAllAsync();
            var speciesList = await _speciesBusiness.GetAllAsync();
            var originList = await _originBusiness.GetAllOriginsAsync();
            var locationList = await _locationBusiness.GetAllAsync();
            var genderList = await _genderBusiness.GetAllAsync();
            var characterList = await _characterTypeBusiness.GetAllAsync(); 

            var statusItems = statusList.Result.Select(e => new SelectListItem() { Value = e.ID.ToString(), Text = e.Name }).ToList();
            var speciesItems = speciesList.Result.Select(e => new SelectListItem() { Value = e.ID.ToString(), Text = e.Name }).ToList();
            var originItems = originList.Result.Select(e => new SelectListItem() { Value = e.ID.ToString(), Text = e.Name }).ToList();
            var locationItems = locationList.Result.Select(e => new SelectListItem() { Value = e.ID.ToString(), Text = e.Name }).ToList();
            var genderItems = genderList.Result.Select(e => new SelectListItem() { Value = e.ID.ToString(), Text = e.Name }).ToList();
            var characterItems = characterList.Result.Select(e => new SelectListItem() { Value = e.ID.ToString(), Text = e.Name }).ToList();

            var model = new CharacterViewModel()
            {
                StatusList = statusItems,
                SpeciesList = speciesItems,
                OriginList = originItems,
                LocationList = locationItems,
                GenderList = genderItems,
                CharacterTypeList = characterItems
            };
            return model;
        }
    }
}
