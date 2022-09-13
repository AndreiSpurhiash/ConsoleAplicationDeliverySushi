using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_project.Domain.Entity;


namespace Final_project.DAL.Interfaces
{
    internal interface ISushiRepository : IBaseRepository<Sushi>
    {
        Sushi GetNumer(int number);

       
    }
}
