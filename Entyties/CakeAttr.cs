﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakes.Entyties
{
    public class CakeAttr
    {
        public int Id { get; set; }

        public string AttrName { get; set; }

        public List<CakeProp> ListProp { get; set; }
    }
}
