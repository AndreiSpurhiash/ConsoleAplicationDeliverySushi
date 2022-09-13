using Final_project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Domain.Entity
{
    public class Order : IEntity
    {
        public Guid Guid { get; set; }
        public DateTime _DateOrder { get; set; }
        public decimal _Price { get; set; }
        public Client Client { get; set; }

        public Guid ClientGuid { get; set; }

        public ICollection<Basket> Basket { get; set; } = new List<Basket>();

        public Order()
        {
            Guid = Guid.NewGuid();
            _DateOrder = DateTime.Now;
        }
    }
}
