﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Entities;
using HMS.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMS.Areas.Dashboard.ViewModels
{
    public class RolesListingModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }

        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }

    public class RoleActionModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        
    }
}