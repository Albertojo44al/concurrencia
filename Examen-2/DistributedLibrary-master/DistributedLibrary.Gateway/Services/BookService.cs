using DistributedLibrary.Gateway.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DistributedLibrary.Gateway.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;
        public async Task<IEnumerable<BookDto>> GetBookById(Guid isdn)
        {
            var books = 0;
            return JsonConvert.DeserializeObject<IEnumerable<BookDto>>(books);
        }
    }
}
