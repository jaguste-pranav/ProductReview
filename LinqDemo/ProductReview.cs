using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemo
{
    public class ProductReview
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public decimal Ratings { get; set; }
        public string Review { get; set; }
        public bool IsLike { get; set; }
    }
}
