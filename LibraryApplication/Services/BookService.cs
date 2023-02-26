using AutoMapper;
using LibraryApplication.DTOs;
using LibraryApplication.Interfaces;
using LibraryInfrastructure.Data;
using LibraryInfrastructure.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync(string orderBy)
        {
            var books = await _bookRepository.GetAllBooksAsync(orderBy);
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<IEnumerable<BookDTO>> GetTopRatedBooksAsync(string genre)
        {
            var books = await _bookRepository.GetTopRatedBooksAsync(genre);
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDetailsDTO> GetBookDetailsAsync(int id)
        {
            var book = await _bookRepository.GetBookDetailsAsync(id);
            return _mapper.Map<BookDetailsDTO>(book);
        }

        public async Task<bool> DeleteBookAsync(int id, string secretKey)
        {
            return await _bookRepository.DeleteBookAsync(id, secretKey);
        }

        public async Task<int> SaveBookAsync(SaveBookDTO book)
        {
            var mappedBook = _mapper.Map<Book>(book);
            return await _bookRepository.SaveBookAsync(mappedBook);
        }

        public async Task<int> AddReviewAsync(int bookId, ReviewDTO review)
        {
            var mappedReview = _mapper.Map<Review>(review);
            return await _bookRepository.AddReviewAsync(bookId, mappedReview);
        }

        public async Task<int> AddRatingAsync(int bookId, int score)
        {
            return await _bookRepository.AddRatingAsync(bookId, score);
        }
    }
}
