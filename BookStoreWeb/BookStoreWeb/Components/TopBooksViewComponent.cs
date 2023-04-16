using BookStoreWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreWeb.Components
{
    public class TopBooksViewComponent: ViewComponent
    {
        private readonly BookRepository _bookRepository = null;
        public TopBooksViewComponent(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int top)
        {
            return View(await _bookRepository.GetTopBooks(top));
        }
    }
}
