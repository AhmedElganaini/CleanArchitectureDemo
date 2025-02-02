using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateProducDto(int Id, string Name, decimal Price): EntityDto<int>;
}
