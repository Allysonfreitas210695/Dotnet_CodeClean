using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoryService.GetCategories();
            return View(categorias);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoriyDto = await _categoryService.GetById(id);

            if (categoriyDto == null) return NotFound();

            return View(categoriyDto);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(category);
                }catch(Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoriyDto = await _categoryService.GetById(id);

            if (categoriyDto == null) return NotFound();

            return View(categoriyDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetById(id);
            if (category == null) return NotFound();

            await _categoryService.Remove(category.Id);

            return RedirectToAction("Index");
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoriyDto = await _categoryService.GetById(id);

            if (categoriyDto == null) return NotFound();

            return View(categoriyDto);
        }
    }
}
