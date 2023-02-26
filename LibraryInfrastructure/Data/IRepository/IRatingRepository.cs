using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Data.IRepository
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingByIdAsync(int id);
        Task<IEnumerable<Rating>> GetAllRatingsAsync();
        Task<IEnumerable<Rating>> GetRatingsByBookIdAsync(int bookId);
        Task AddRatingAsync(Rating rating);
        Task UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(Rating rating);
    }
}
