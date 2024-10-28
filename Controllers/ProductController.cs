using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;
    private const int PageSize = 10; // Set the number of items per page

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        // Calculate the total number of pages
        int totalProducts = await _context.Products.CountAsync();
        int totalPages = (int)System.Math.Ceiling((double)totalProducts / PageSize);

        // Get only the products needed for the current page
        var products = await _context.Products
            .Include(p => p.Category) // Include Category to display category name
            .OrderBy(p => p.ProductId) // Order products by ProductId (or any other field)
            .Skip((page - 1) * PageSize) // Skip the records of previous pages
            .Take(PageSize) // Take only the records needed for the current page
            .ToListAsync();

        // Pass the products and pagination data to the view
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;

        return View(products);
    }
}
