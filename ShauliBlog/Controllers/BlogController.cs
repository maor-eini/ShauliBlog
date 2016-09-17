

using ShauliBlog.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ShauliBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private readonly ShauliBlogDbContext _context;

        public BlogController()
        {
            _context = new ShauliBlogDbContext();
        }
        public ActionResult Index()
        {

            var posts = _context.Posts
                .Include(p => p.Comments)
                .ToList();

            return View(posts);
        }
    }
}