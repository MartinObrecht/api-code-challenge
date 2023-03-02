using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeChallenge.Application.Handlers.V1.Partners.Create.Dtos
{
    public class AddressDto
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
    }
}