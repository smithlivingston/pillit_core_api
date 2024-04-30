using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static pillit.lib.Constants.Enums;

namespace pillit.lib.Entities
{
    public class ApiStatusResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;
        public ResponseStatus StatusMessage { get; set; }

    }
}
