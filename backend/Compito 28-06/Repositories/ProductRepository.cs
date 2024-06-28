using DiamaGyms.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiamaGyms.Repositories
{
    public static class ProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Dumbbell",
                Price = 25.99M,
                Description = "High-quality dumbbell for strength training.",
                CoverImageUrl = "https://contents.mediadecathlon.com/p1656855/k$9d79e3b50f10b217d8a11777382e946c/sq/manubrio-hex-dumbbell-225kg.jpg?format=auto&f=1200x1200",
                AdditionalImageUrl = "https://contents.mediadecathlon.com/p1891455/k$e295af185e32cf6d61ae7bcb7d072b26/sq/manubrio-hex-dumbbell-225kg.jpg?format=auto&f=1200x1200"
            },
            new Product
            {
                Id = 2,
                Name = "Yoga Mat",
                Price = 19.99M,
                Description = "Non-slip yoga mat for your daily yoga practice.",
                CoverImageUrl = "https://contents.mediadecathlon.com/m11131803/k$533b808fb68505ea53b5735c12bc39d3/sq/materassino-per-lo-yoga-in-pvc-con-tracolla.jpg?format=auto&f=1200x1200",
                AdditionalImageUrl = "https://contents.mediadecathlon.com/m11131797/k$33f774d27c08a13d247176a0ee93a9d9/sq/materassino-per-lo-yoga-in-pvc-con-tracolla.jpg?format=auto&f=1200x1200"
            },
            new Product
            {
                Id = 3,
                Name = "Swiss Ball",
                Price = 9.99M,
                Description = "This comfortable, robust Swiss ball enables you to vary the exercises you do during fitness, Pilates and stretching sessions. You won't be able to live without them!",
                CoverImageUrl = "https://contents.mediadecathlon.com/p1988447/k$876107ef97d8bd96a7addf04aa7f44c9/sq/fitball-taglia-1-55-cm-azzurra.jpg?format=auto&f=1200x1200",
                AdditionalImageUrl = "https://contents.mediadecathlon.com/p2067799/k$20d7cd09d9a7f32baa426cfcb4d1693e/sq/fitball-taglia-1-55-cm-azzurra.jpg?format=auto&f=1200x1200"
            },
            new Product
            {
                Id = 4,
                Name = "Smartwatch Forerunner 265S",
                Price = 429.99M,
                Description = "Shine during your workout with the Forerunner 265. Its bright AMOLED touchscreen stands above the rest, while the workout preparation feature - that allows you to know if",
                CoverImageUrl = "https://contents.mediadecathlon.com/p2487689/k$f62bf67d56ad460da8ca551f4bc99962/sq/smartwatch-gps-multisport-garmin-forerunner-265-s-music-bianco.jpg?format=auto&f=1200x1200",
                AdditionalImageUrl = "https://contents.mediadecathlon.com/p2487693/k$16edf0ade46cde87c585b70344740758/sq/smartwatch-gps-multisport-garmin-forerunner-265-s-music-bianco.jpg?format=auto&f=1200x1200"
            }
        };

        public static List<Product> GetAllProducts()
        {
            return _products;
        }

        public static Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public static void AddProduct(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
    }
}
