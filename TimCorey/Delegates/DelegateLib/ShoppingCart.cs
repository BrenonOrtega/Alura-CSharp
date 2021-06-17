using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DelegateLib
{
    public class ShoppingCart
    {
        public delegate void MentionDiscount(decimal subTotal);
        public List<ProductModel> products { get; set; }
        public ShoppingCart()
        {
            products = new();
        }

        public decimal GeneterateTotal( MentionDiscount mentionDiscount,
                                        Func<List<ProductModel>, decimal, decimal> discountValue,
                                        Action<string> alertUser) {
            decimal subTotal = products.Sum(products => products.Price);
            alertUser($"We Are apllying your discount");
            mentionDiscount?.Invoke(subTotal);
            return discountValue.Invoke(products, subTotal);
        }
    }
}