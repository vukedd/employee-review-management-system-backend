using Domain.Enums.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs
{
    public class ResponseDto
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public ResponseType Type { get; set; }
    }
}
