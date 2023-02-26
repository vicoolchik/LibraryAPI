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
    public class RatingRepository : IRatingRepository
    {
        private readonly LibraryContext _context;

        public RatingRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Rating> GetRatingByIdAsync(int id)
        {
            return await _context.Ratings.FindAsync(id);
        }

        public async Task<IEnumerable<Rating>> GetAllRatingsAsync()
        {
            return await _context.Ratings.ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetRatingsByBookIdAsync(int bookId)
        {
            return await _context.Ratings.Where(r => r.BookId == bookId).ToListAsync();
        }

        public async Task AddRatingAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRatingAsync(Rating rating)
        {
            _context.Ratings.Update(rating);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRatingAsync(Rating rating)
        {
            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
        }
    }
}
