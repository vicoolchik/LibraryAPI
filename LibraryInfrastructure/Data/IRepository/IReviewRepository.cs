using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Data.IRepository
{
    public interface IReviewRepository
    {
        Task<Review> GetReviewByIdAsync(int id);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<IEnumerable<Review>> GetReviewsByBookIdAsync(int bookId);
        Task AddReviewAsync(Review review);
        Task UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(Review review);
    }
}
