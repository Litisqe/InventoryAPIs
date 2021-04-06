using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.BAL.Models
{
    public class InventoryVM
    {
        public int Id { get; set; }
        public string InvId { get; set; }
        public string BrandId { get; set; }
        public string InvName { get; set; }
        public string InvDescription { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
    }
}
