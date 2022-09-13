using Final_project.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Final_project.DAL.Repositories
{
    internal class BasketRepository : BaseRepository<Basket>
    {
        public BasketRepository(DbContext context) : base(context)
        {
        }
    }
}
