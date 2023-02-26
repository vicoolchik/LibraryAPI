using LibraryApplication.DTOs;
using LibraryInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//namespace LibraryApplication.Interfaces
//{
//    public interface IBookService
//    {
//        Task<IEnumerable<Book>> GetAllBooksAsync(string orderBy);
//        Task<IEnumerable<Book>> GetTopRatedBooksAsync(string genre);
//        Task<Book> GetBookDetailsAsync(int id);
//        Task<bool> DeleteBookAsync(int id, string secretKey);
//        Task<int> SaveBookAsync(Book book);
//        Task<int> AddReviewAsync(int bookId, Review review);
//        Task<int> AddRatingAsync(int bookId, int score);
//    }
//}

namespace LibraryApplication.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync(string orderBy);
        Task<IEnumerable<BookDTO>> GetTopRatedBooksAsync(string genre);
        Task<BookDetailsDTO> GetBookDetailsAsync(int id);
        Task<bool> DeleteBookAsync(int id, string secretKey);
        Task<int> SaveBookAsync(SaveBookDTO book);
        Task<int> AddReviewAsync(int bookId, ReviewDTO review);
        Task<int> AddRatingAsync(int bookId, int score);
    }
}
