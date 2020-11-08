using System;
using System.Collections.Generic;
using System.Data;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management!");
            List<ProductReview> reviews = new List<ProductReview>()
            {
                new ProductReview(){ ProductID = 1, UserID = 1, Ratings = 8, Review = "Good", IsLike = true},
                new ProductReview(){ ProductID = 2, UserID = 2, Ratings = 7, Review = "Good", IsLike = true},
                new ProductReview(){ ProductID = 3, UserID = 3, Ratings = 5, Review = "Good", IsLike = true},
                new ProductReview(){ ProductID = 20, UserID = 4, Ratings = 10, Review = "Good", IsLike = true},
                new ProductReview(){ ProductID = 23, UserID = 5, Ratings = 6, Review = "Nice", IsLike = false},
                new ProductReview(){ ProductID = 6, UserID = 6, Ratings = 3, Review = "Nice", IsLike = false},
                new ProductReview(){ ProductID = 20, UserID = 7, Ratings = 2, Review = "Bad", IsLike = false},
                new ProductReview(){ ProductID = 8, UserID = 8, Ratings = 1, Review = "Bad", IsLike = false},
                new ProductReview(){ ProductID = 20, UserID = 20, Ratings = 9, Review = "Good", IsLike = true},
                new ProductReview(){ ProductID = 21, UserID = 21, Ratings = 3, Review = "Nice", IsLike = false},
                new ProductReview(){ ProductID = 11, UserID = 11, Ratings = 3, Review = "Nice", IsLike = false},
                new ProductReview(){ ProductID = 14, UserID = 14, Ratings = 10, Review = "Good", IsLike = true},
                new ProductReview(){ ProductID = 23, UserID = 23, Ratings = 4, Review = "Good", IsLike = true}
            };

            Console.WriteLine();
            Console.WriteLine("UC1");

            foreach(ProductReview review in reviews)
            {
                Console.WriteLine("ProductID: "+review.ProductID+ ", UserID: "+review.UserID+ ", Ratings: "+review.Ratings+ " , Review: "+review.Review+ " , IsLike: "+review.IsLike);
            }

            Console.WriteLine();
            Console.WriteLine("UC2");
            Management.RetrieveTop3(reviews);

            Console.WriteLine();
            Console.WriteLine("UC3");
            Management.RetrieveProductwithRating1or4or9(reviews);

            Console.WriteLine();
            Console.WriteLine("UC4");
            Management.RetrieveCountOfProductReviewsForEachID(reviews);

            Console.WriteLine();
            Console.WriteLine("UC5");
            Management.RetrieveProductIDAndReviews(reviews);

            Console.WriteLine();
            Console.WriteLine("UC6");
            Management.SkipTop5Records(reviews);

            Console.WriteLine();
            Console.WriteLine("UC8(Fetch records from DataTable)");
            Management.CreateDataTableUC8();

            Console.WriteLine();
            Console.WriteLine("UC9");
            Management.RetrieveRowByIsLikeUC9();
        }

    }
}
