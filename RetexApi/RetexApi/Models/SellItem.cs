using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetexApi.Models
{
    public class SellItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Console { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
    }
}
