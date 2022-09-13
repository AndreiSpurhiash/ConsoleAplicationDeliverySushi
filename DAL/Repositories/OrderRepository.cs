using Final_project.DAL.Interfaces;
using Final_project.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_project.DAL.Interfaces;

namespace Final_project.DAL.Repositories
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        readonly DbContext db;
        public OrderRepository(DbContext context) : base(context)
        {
            db = context;
        }

        public override async Task<IEnumerable<Order>> GetListAsync()
        {
            return await db.Set<Order>().Include(p => p.Client).ToListAsync().ConfigureAwait(false);
        }
    }
}
