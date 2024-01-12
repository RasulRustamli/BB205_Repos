﻿using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public IEnumerable<BlogCategory> BlogCategories { get; set; }

    }
}
