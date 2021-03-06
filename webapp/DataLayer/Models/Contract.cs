﻿using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public List<ConstructionSiteManager> SiteManagers{ get; set; }
    }
}
