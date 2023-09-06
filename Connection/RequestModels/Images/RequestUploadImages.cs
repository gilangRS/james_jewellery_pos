using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.Images
{
    public class RequestUploadImages
    {
        public string Path { get; set; }
        public IFormFile File { get; set; }
    }
}
