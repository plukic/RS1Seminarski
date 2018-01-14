using DataLayer.Models;
using System.Collections.Generic;

namespace ConstructionDiary.ViewModels
{

    public class EquipmentListViewModel
    {
        public List<Equipment> Equipment { get; set; }

        public string NameFilter { get; set; }
    }
}
