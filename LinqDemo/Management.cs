using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public class Management
    {
        public static DataTable table = new DataTable();

        public static void RetrieveTop3(List<ProductReview> reviews)
        {
            var list = (from products in reviews orderby products.Ratings descending select products).Take(3).ToList();

            foreach (var review in list)
            {
                Console.WriteLine("ProductID: " + review.ProductID + ", UserID: " + review.UserID + ", Ratings: " + review.Ratings + " , Review: " + review.Review + " , IsLike: " + review.IsLike);
            }
        }

        public static void RetrieveProductwithRating1or4or9(List<ProductReview> reviews)
        {
            var list = (from products in reviews where products.Ratings > 3 && (products.ProductID == 1 || products.ProductID == 4 || products.ProductID == 9) select products);

            foreach (ProductReview product in list)
            {
                Console.WriteLine("ProductID: " + product.ProductID + ", UserID: " + product.UserID + ", Ratings: " + product.Ratings + " , Review: " + product.Review + " , IsLike: " + product.IsLike);
            }
        }

        public static void RetrieveCountOfProductReviewsForEachID(List<ProductReview> reviews)
        {
            var resultData = reviews.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() }).OrderBy(x => x.ProductID);

            foreach (var res in resultData)
            {
                Console.WriteLine("Product ID: " + res.ProductID + " Count: " + res.Count);
            }
        }

        public static void RetrieveProductIDAndReviews(List<ProductReview> reviews)
        {
            //In Query Synatx
            var qlist = from product in reviews select new { product.ProductID, product.Review };

            //In Method Syntax
            var mlist = reviews.Select(x => new { x.ProductID, x.Review });

            foreach (var product in qlist)
            {
                Console.WriteLine("Product ID: " + product.ProductID + " Review: " + product.Review);
            }
        }

        public static void SkipTop5Records(List<ProductReview> reviews)
        {
            //In Method Syntax
            var mlist = reviews.OrderByDescending(x => x.Ratings).Skip(5);

            foreach (var review in mlist)
            {
                Console.WriteLine("ProductID: " + review.ProductID + ", UserID: " + review.UserID + ", Ratings: " + review.Ratings + " , Review: " + review.Review + " , IsLike: " + review.IsLike);
            }
        }

    }
}
