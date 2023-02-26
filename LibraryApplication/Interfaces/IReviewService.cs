using LibraryApplication.DTOs;
using LibraryInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LibraryApplication.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDTO> GetReviewByIdAsync(int id);
        Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync();
        Task<IEnumerable<ReviewDTO>> GetReviewsByBookIdAsync(int bookId);
        Task<int> AddReviewAsync(int bookId, ReviewDTO review);
        Task<int> UpdateReviewAsync(ReviewDTO review);
        Task<int> DeleteReviewAsync(int id);
    }
}