using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    public class MyModel
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }

        public int? Age { get; set; }

        public DateTime? BirthDate { get; set; }

    }
}
