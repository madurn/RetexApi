﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetexApi.Models
{
    public class GameConsole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Condition { get; set; }
        public string ImageLocation { get; set; }
    }
}
