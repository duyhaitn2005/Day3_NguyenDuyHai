using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models; // Thay đổi nếu Model Category của bạn nằm ở namespace khác

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = WebApplication1.Data.SeedData.Categories;
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = WebApplication1.Data.SeedData.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Tự động sinh ID mới dựa trên ID lớn nhất hiện tại
                    int maxId = WebApplication1.Data.SeedData.Categories.Any()
                        ? WebApplication1.Data.SeedData.Categories.Max(c => c.Id)
                        : 0;
                    category.Id = maxId + 1;

                    // Thêm vào danh sách tĩnh
                    WebApplication1.Data.SeedData.Categories.Add(category);
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = WebApplication1.Data.SeedData.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                var existingCategory = WebApplication1.Data.SeedData.Categories.FirstOrDefault(c => c.Id == id);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    // Cập nhật thông tin (ví dụ cập nhật Name)
                    existingCategory.Name = category.Name;
                    existingCategory.description = category.description;

                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = WebApplication1.Data.SeedData.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = WebApplication1.Data.SeedData.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                WebApplication1.Data.SeedData.Categories.Remove(category);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}