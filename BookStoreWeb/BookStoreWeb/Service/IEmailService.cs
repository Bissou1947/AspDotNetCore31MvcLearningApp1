using BookStoreWeb.Models;
using System.Threading.Tasks;

namespace BookStoreWeb.Service
{
    public interface IEmailService
    {
        Task SendTestMail(TestMailOptionsVM testMailOptionsVM);
    }
}