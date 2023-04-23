using BookStoreWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreWeb.Components
{
    public class TopBooksViewComponent: ViewComponent
    {
        private readonly IBookRepository _iBookRepository = null;
        public TopBooksViewComponent(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int top)
        {
            return View(await _iBookRepository.GetTopBooks(top));
        }
    }
}
