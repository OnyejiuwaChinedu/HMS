﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Entities;

namespace HMS.Areas.Dashboard.ViewModels
{
    public class AccomodationTypesListingModel 
    {
        public IEnumerable<AccomodationType> AccomodationTypes { get; set;}
        public object SearchTerm { get; set; }
    }
    public class AccomodationTypeActionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}