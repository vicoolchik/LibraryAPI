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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDTO> GetReviewByIdAsync(int id)
        {
            var review = await _reviewRepository.GetReviewByIdAsync(id);
            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllReviewsAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<IEnumerable<ReviewDTO>> GetReviewsByBookIdAsync(int bookId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                throw new NotFoundException($"Book with id {bookId} not found.");
            }

            var reviews = await _reviewRepository.GetReviewsByBookIdAsync(bookId);
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<int> AddReviewAsync(int bookId, ReviewDTO review)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                throw new NotFoundException($"Book with id {bookId} not found.");
            }

            var reviewToAdd = _mapper.Map<Review>(review);
            reviewToAdd.Book = book;

            await _reviewRepository.AddReviewAsync(reviewToAdd);
            return reviewToAdd.Id;
        }

        public async Task<int> UpdateReviewAsync(ReviewDTO review)
        {
            var reviewToUpdate = await _reviewRepository.GetReviewByIdAsync(review.Id);
            if (reviewToUpdate == null)
            {
                throw new NotFoundException($"Review with id {review.Id} not found.");
            }

            _mapper.Map(review, reviewToUpdate);

            await _reviewRepository.UpdateReviewAsync(reviewToUpdate);
            return reviewToUpdate.Id;
        }

        public async Task<int> DeleteReviewAsync(int id)
        {
            var reviewToDelete = await _reviewRepository.GetReviewByIdAsync(id);
            if (reviewToDelete == null)
            {
                throw new NotFoundException($"Review with id {id} not found.");
            }

            await _reviewRepository.DeleteReviewAsync(reviewToDelete);
            return reviewToDelete.Id;
        }
    }
}
