using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Data.IRepository
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync(string orderBy);
        Task<IEnumerable<Book>> GetTopRatedBooksAsync(string genre);
        Task<Book> GetBookDetailsAsync(int id);
        Task<bool> DeleteBookAsync(int id, string secretKey);
        Task<int> SaveBookAsync(Book book);
        Task<int> AddReviewAsync(int bookId, Review review);
        Task<int> AddRatingAsync(int bookId, int score);
    }
}
