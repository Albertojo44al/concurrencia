using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistributedLibrary.Gateway.Model
{
    public class BookDto
    {
        public Guid isbn { get; set; }

        public string title { get; set; }

        public string subtitle { get; set; }

        public string published { get; set; }

        public string publisher { get; set; }

        public string pages { get; set; }

        public string description { get; set; }

        public string website { get; set; }

        public string authorId { get; set; }
    }
}
