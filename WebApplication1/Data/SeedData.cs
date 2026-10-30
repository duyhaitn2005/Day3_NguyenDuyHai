using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class SeedData
    {
        public static List<Category> Categories = new List<Category>
        {

                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Clothing" }
            };
    }
}

