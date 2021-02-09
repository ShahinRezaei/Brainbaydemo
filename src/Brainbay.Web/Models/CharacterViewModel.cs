using Brainbay.Common.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brainbay.Web.Models
{
    public class CharacterViewModel
    {

        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Url { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public Guid Status { get; set; }
        [Required]
        public Guid Species { get; set; }
        [Required]
        public Guid CharacterType { get; set; }
        [Required]
        public Guid Gender { get; set; }
        [Required]
        public Guid Origin { get; set; }
        [Required]
        public Guid Location { get; set; }


        public IList<SelectListItem> StatusList { get; set; }
        public IList<SelectListItem> SpeciesList { get; set; }
        public IList<SelectListItem> CharacterTypeList { get; set; }
        public IList<SelectListItem> GenderList { get; set; }
        public IList<SelectListItem> OriginList { get; set; }
        public IList<SelectListItem> LocationList { get; set; }

    }
}
