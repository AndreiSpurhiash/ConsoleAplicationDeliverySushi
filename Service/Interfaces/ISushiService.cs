using Final_project.Domain.Entity;
using Final_project.Domain.Respons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Service.Interfaces
{
    internal interface ISushiService
    {
        public Task<IBaseResponse<IEnumerable<Sushi>>> GetSushiAsync();
    }
}
