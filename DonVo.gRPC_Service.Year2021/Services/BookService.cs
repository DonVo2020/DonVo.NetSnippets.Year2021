using AutoMapper;
using EfLinqQuerySnippets._03.AdvancedQuerying.Data;
using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DonVo.gRPC_Service.Year2021.Protos;
using System;
using System.Threading.Tasks;

namespace DonVo.gRPC_Service.Year2021.Services
{
    public class BookService : BookProtoService.BookProtoServiceBase
    {
        private readonly BookShopContext _bookContext;
        private readonly ILogger<BookService> _logger;
        private readonly IMapper _mapper;

        public BookService(BookShopContext bookContext, ILogger<BookService> logger, IMapper mapper)
        {
            _bookContext = bookContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override Task<Empty> Test(Empty request, ServerCallContext context)
        {
            return base.Test(request, context);
        }

        public override async Task<BookModel> GetBook(GetBookRequest request, ServerCallContext context)
        {
            var book = await _bookContext.Books.FindAsync(request.BookId);
            if (book == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Book with Id = {request.BookId} is not found."));

            return _mapper.Map<BookModel>(book);
        }

        public override async Task GetAllBooks(GetAllBooksRequest request, IServerStreamWriter<BookModel> responseStream, ServerCallContext context)
        {
            var books = await _bookContext.Books.ToListAsync();

            foreach (var book in books)
            {
                var bookModel = _mapper.Map<BookModel>(book);
                await responseStream.WriteAsync(bookModel);
            }
        }

        public override async Task<BookModel> AddBook(AddBookRequest request, ServerCallContext context)
        {
            var book = _mapper.Map<Book>(request.Book);

            await _bookContext.Books.AddAsync(book);
            await _bookContext.SaveChangesAsync();

            _logger.LogInformation("Book successfully added : {bookId}_{bookTitle}", book.BookId, book.Title);
            return _mapper.Map<BookModel>(book);
        }

        public override async Task<BookModel> UpdateBook(UpdateBookRequest request, ServerCallContext context)
        {
            var book = _mapper.Map<Book>(request.Book);

            bool isExist = await _bookContext.Books.AnyAsync(p => p.BookId == book.BookId);
            if (!isExist)
                throw new RpcException(new Status(StatusCode.NotFound, $"Book with Id = {request.Book.BookId} is not found."));

            _bookContext.Entry(book).State = EntityState.Modified;

            try
            {
                await _bookContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return _mapper.Map<BookModel>(book);
        }

        public override async Task<DeleteBookResponse> DeleteBook(DeleteBookRequest request, ServerCallContext context)
        {
            Book book = await _bookContext.Books.FindAsync(request.BookId);
            if (book == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Book with Id = {request.BookId} is not found."));

            _bookContext.Books.Remove(book);
            int deleteCount = await _bookContext.SaveChangesAsync();

            return new DeleteBookResponse
            {
                Success = deleteCount > 0
            };
        }

        public override async Task<InsertBulkBookResponse> InsertBulkBook(IAsyncStreamReader<BookModel> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                Book book = _mapper.Map<Book>(requestStream.Current);
                _bookContext.Books.Add(book);
            }

            int insertCount = await _bookContext.SaveChangesAsync();
            var response = new InsertBulkBookResponse
            {
                InsertCount = insertCount,
                Success = insertCount > 0
            };

            return response;
        }

    }
}
