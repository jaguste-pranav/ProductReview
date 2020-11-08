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

        public static void CreateDataTableUC8()
        {
            table.Columns.Add("ProductID");
            table.Columns.Add("UserID");
            table.Columns.Add("Ratings");
            table.Columns.Add("Review");
            table.Columns.Add("IsLike");

            table.Rows.Add(1, 1, 8, "Good", true);
            table.Rows.Add(2, 2, 7, "Good", true);
            table.Rows.Add(3, 3, 5, "Good", true);
            table.Rows.Add(20, 4, 10, "Good", true);
            table.Rows.Add(23, 5, 6, "Nice", false);
            table.Rows.Add(6, 6, 3, "Nice", false);
            table.Rows.Add(20, 7, 2, "Bad", false);
            table.Rows.Add(8, 8, 1, "Nice", false);
            table.Rows.Add(20, 20, 9, "Good", true);
            table.Rows.Add(21, 21, 3, "Nice", false);
            table.Rows.Add(11, 11, 3, "Nice", false);
            table.Rows.Add(14, 14, 10, "Good", true);
            table.Rows.Add(23, 23, 4, "Good", true);

            DisplayDataTable();

        }

        public static void DisplayDataTable()
        {
            var stringTable = from product in table.AsEnumerable() select product;

            foreach (var row in stringTable)
            {
                Console.WriteLine("ProductID: " + row.Field<string>("ProductID") + ", UserID: " + row.Field<string>("UserID") + ", Ratings: " + row.Field<string>("Ratings") + " , Review: " + row.Field<string>("Review") + " , IsLike: " + row.Field<string>("IsLike"));
            }
        }

        public static void RetrieveRowByIsLike()
        {
            var rows = from product in table.AsEnumerable() where product.Field<string>("IsLike").Equals(true) select product; 

            foreach (var row in rows)
            {
                Console.WriteLine("ProductID: " + row.Field<string>("ProductID") + ", UserID: " + row.Field<string>("UserID") + ", Ratings: " + row.Field<string>("Ratings") + " , Review: " + row.Field<string>("Review") + " , IsLike: " + row.Field<string>("IsLike"));
            }
        }

        public static void FindAvgRatingsPerProductID(List<ProductReview> reviews)
        {
            var list = reviews.GroupBy(x => x.ProductID);

            //Iterating for each ProductID and Calulating Avg Ratings
            foreach (var groups in list)
            {
                Console.WriteLine("ProductID: " + groups.Key + " Average Ratings: " + groups.Average(x => x.Ratings));
            }
        }

        public static void RetrieveNiceMsg(List<ProductReview> reviews)
        {
            var list = from products in reviews where products.Review.Equals("Nice") select products;

            foreach (var review in list)
            {
                Console.WriteLine("ProductID: " + review.ProductID + ", UserID: " + review.UserID + ", Ratings: " + review.Ratings + " , Review: " + review.Review + " , IsLike: " + review.IsLike);
            }
        }

        public static void AddandRetrieveRecordOfaUserID()
        {
            table.Rows.Add(20, 10, 9, "Good", true);
            table.Rows.Add(21, 10, 3, "Nice", false);
            table.Rows.Add(11, 10, 3, "Nice", false);
            table.Rows.Add(14, 10, 10, "Good", true);
            table.Rows.Add(23, 10, 4, "Good", true);

            var list = table.AsEnumerable().Where(x => x.Field<string>("UserID") == "10").Select(x => x).OrderByDescending(x => Convert.ToInt32(x.Field<string>("Ratings")));

            foreach (var row in list)
            {
                Console.WriteLine("ProductID: " + row.Field<string>("ProductID") + ", UserID: " + row.Field<string>("UserID") + ", Ratings: " + row.Field<string>("Ratings") + " , Review: " + row.Field<string>("Review") + " , IsLike: " + row.Field<string>("IsLike"));
            }

        }
    }
}
