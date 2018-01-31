using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels
{
    public class AddMaterialVM
    {
        public int MaterialId { get; set; }
        public List<SelectListItem> Materials{ get; set; }

    }
}
