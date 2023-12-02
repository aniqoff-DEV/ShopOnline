using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Models.Dtos
{
    public class CartItemQuantityUpdateDto
    {
        public int CartItemId {  get; set; }

        public int Quantity { get; set;}
    }
}
