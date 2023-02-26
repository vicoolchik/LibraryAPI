using LibraryInfrastructure.Context;
using LibraryInfrastructure.Data.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(string orderBy)
        {
            switch (orderBy)
            {
                case "author":
                    return await _context.Books.Include(b => b.Ratings).Include(b => b.Reviews).OrderBy(b => b.Author).ToListAsync();
                case "title":
                default:
                    return await _context.Books.Include(b => b.Ratings).Include(b => b.Reviews).OrderBy(b => b.Title).ToListAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetTopRatedBooksAsync(string genre)
        {
            return await _context.Books
                .Include(b => b.Ratings)
                .Include(b => b.Reviews)
                .Where(b => b.Genre == genre && b.Reviews.Count >= 0)
                .OrderByDescending(b => b.Ratings.Average(r => r.Score))
                .Take(10)
                .ToListAsync();
        }

        public async Task<Book> GetBookDetailsAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Ratings)
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> DeleteBookAsync(int id, string secretKey)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null && secretKey == "qwerty")
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<int> SaveBookAsync(Book book)
        {
            if (book.Id == 0)
            {
                await _context.Books.AddAsync(book);
            }
            else
            {
                _context.Books.Update(book);
            }
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int> AddReviewAsync(int bookId, Review review)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            if (book != null)
            {
                book.Reviews ??= new List<Review>();
                book.Reviews.Add(review);
                await _context.SaveChangesAsync();
                return review.Id;
            }
            return 0;
        }

        public async Task<int> AddRatingAsync(int bookId, int score)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.Ratings ??= new List<Rating>();
                book.Ratings.Add(new Rating { Score = score });
                await _context.SaveChangesAsync();
                return book.Ratings.Count;
            }
            return 0;
        }
    }
}
