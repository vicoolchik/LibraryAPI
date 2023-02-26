using LibraryApplication.DTOs;
using LibraryInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LibraryApplication.Interfaces
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingDTO>> GetAllRatingsAsync();
        Task<RatingDTO> GetRatingByIdAsync(int id);
        Task<IEnumerable<RatingDTO>> GetRatingsByBookIdAsync(int bookId);
        Task<bool> AddRatingAsync(RatingDTO rating);
        Task<bool> UpdateRatingAsync(RatingDTO rating);
        Task<bool> DeleteRatingAsync(RatingDTO rating);
    }
}