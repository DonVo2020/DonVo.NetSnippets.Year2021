using DonVo.gRPC_Service.Year2021.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DonVo.gRPC_Client_Console.Year2021
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Waiting for server is running.");
            Thread.Sleep(3000);

            using var channel = GrpcChannel.ForAddress("https://localhost:5008");
            var client = new BookProtoService.BookProtoServiceClient(channel);

            await GetBookAsync(client);
            await GetAllBooks(client);
            //await AddBookAsync(client);

            await UpdateBookAsync(client);
            //await DeleteBookAsync(client);
            //await InsertBulkBookAsync(client);

            Console.Read();
        }

        private static async Task GetAllBooks(BookProtoService.BookProtoServiceClient client)
        {
            Console.WriteLine("GetAllBooks started...");
            using var clientData = client.GetAllBooks(new GetAllBooksRequest());
            await foreach (var responseData in clientData.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine(responseData);
            }
        }

        private static async Task GetBookAsync(BookProtoService.BookProtoServiceClient client)
        {
            Console.WriteLine("GetBookAsync started...");
            var response = await client.GetBookAsync(new GetBookRequest
            {
                BookId = 1
            });

            Console.WriteLine("GetBookAsync response: " + response.ToString());
        }

        private static async Task AddBookAsync(BookProtoService.BookProtoServiceClient client)
        {
            Console.WriteLine("AddBookAsync started...");
            var response = await client.AddBookAsync(new AddBookRequest
            {
                Book = new BookModel
                {
                    Title = "NEW DON TITLE, BRO",
                    Description = "WHATEVER COME TODAY",
                    Price = 699,
                    EditionType = EditionType.Normal,
                    AuthorId = 5,
                    Copies = 11,
                    //ReleaseDate = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            });

            Console.WriteLine("AddBookAsync response: " + response.ToString());
        }

        private static async Task UpdateBookAsync(BookProtoService.BookProtoServiceClient client)
        {
            Console.WriteLine("UpdateBookAsync started...");

            var response = await client.UpdateBookAsync(new UpdateBookRequest
            {
                Book = new BookModel
                {
                    BookId = 1,
                    Title = "DON TITLE REPLACE",
                    Description = "New Red Phone Mi10T",
                    Price = 699,
                    EditionType = EditionType.Promo,
                    AuthorId = 1,
                    Copies = 111,
                    //ReleaseDate = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            });

            Console.WriteLine("UpdateBookAsync response: " + response.ToString());
        }

        private static async Task DeleteBookAsync(BookProtoService.BookProtoServiceClient client)
        {
            Console.WriteLine("DeleteBookAsync started...");
            var response = await client.DeleteBookAsync(new DeleteBookRequest
            {
                BookId = 40
            });

            Console.WriteLine("DeleteBookAsync response: " + response.ToString());
        }

        private static async Task InsertBulkBookAsync(BookProtoService.BookProtoServiceClient client)
        {
            Console.WriteLine("InsertBulkBookAsync started...");

            using var clientBulk = client.InsertBulkBook();

            for (int i = 0; i < 3; i++)
            {
                var book = new BookModel
                {
                    Title = $"Title{i}",
                    Description = "Bulk inserted book.",
                    Price = 399,
                    EditionType = EditionType.Gold,
                    AuthorId = 2,
                    Copies = 3,
                    //ReleaseDate = Timestamp.FromDateTime(DateTime.UtcNow)
                };

                await clientBulk.RequestStream.WriteAsync(book);
            }

            await clientBulk.RequestStream.CompleteAsync();
            InsertBulkBookResponse response = await clientBulk;
            Console.WriteLine($"Status: {response.Success}. Insert count: {response.InsertCount}");
        }
    }
}
