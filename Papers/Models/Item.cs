using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Papers.Models
{
    // This class is used t display items in the cart, as well as their subtotals
    public class Item
    {
        // the product being added to the car
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal _Subtotal;

        // subtotal is caculated by multiplying the price and the quantity.
        //  _Subtotal returns calculates the cost and then assigned to  Subtotal. 
        // Subtotal will be display in the View

        [DataType(DataType.Currency)]
        public decimal Subtotal { get { return _Subtotal; }
        set { _Subtotal = Product.Price * Quantity; }
        }
    }
}
