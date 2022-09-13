using Final_project.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace Final_project.Domain.Entity
{
    public class Basket : IEntity
    {
        public Guid Guid { get; set; }

        public Order Order { get; set; }
        public Guid GuidOrder { get; set; }
        public Sushi Sushi { get; set; }
        public int Count { get; set; }

        public Basket()
        {
            Guid = Guid.NewGuid();
        }

    }
}
