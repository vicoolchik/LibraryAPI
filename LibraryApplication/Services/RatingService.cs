using AutoMapper;
using LibraryApplication.DTOs;
using LibraryApplication.Interfaces;
using LibraryInfrastructure.Data;
using LibraryInfrastructure.Data.IRepository;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RatingDTO>> GetAllRatingsAsync()
        {
            var ratings = await _ratingRepository.GetAllRatingsAsync();
            return _mapper.Map<IEnumerable<RatingDTO>>(ratings);
        }

        public async Task<RatingDTO> GetRatingByIdAsync(int id)
        {
            var rating = await _ratingRepository.GetRatingByIdAsync(id);
            if (rating == null)
            {
                throw new NotFoundException($"Rating with id {id} not found.");
            }

            return _mapper.Map<RatingDTO>(rating);
        }

        public async Task<IEnumerable<RatingDTO>> GetRatingsByBookIdAsync(int bookId)
        {
            CheckIfNull((object)bookId);

            var ratings = await _ratingRepository.GetRatingsByBookIdAsync(bookId);
            return _mapper.Map<IEnumerable<RatingDTO>>(ratings);
        }

        public async Task<bool> AddRatingAsync(RatingDTO ratingDTO)
        {
            CheckIfNull(ratingDTO);

            var rating = _mapper.Map<Rating>(ratingDTO);
            await _ratingRepository.AddRatingAsync(rating);
            return true;
        }

        public async Task<bool> UpdateRatingAsync(RatingDTO ratingDTO)
        {
            CheckIfNull(ratingDTO);

            var rating = await _ratingRepository.GetRatingByIdAsync(ratingDTO.Id);
            if (rating == null)
            {
                throw new NotFoundException($"Rating with id {ratingDTO.Id} not found.");
            }

            _mapper.Map(ratingDTO, rating);
            await _ratingRepository.UpdateRatingAsync(rating);
            return true;
        }

        public async Task<bool> DeleteRatingAsync(RatingDTO ratingDTO)
        {
            CheckIfNull(ratingDTO);

            var rating = await _ratingRepository.GetRatingByIdAsync(ratingDTO.Id);
            if (rating == null)
            {
                throw new NotFoundException($"Rating with id {ratingDTO.Id} not found.");
            }

            await _ratingRepository.DeleteRatingAsync(rating);
            return true;
        }

        private void CheckIfNull<T>(T obj) where T : class
        {
            if (obj == default(T))
            {
                throw new NotFoundException($"Object of type {typeof(T).Name} not found.");
            }
        }
    }
}




