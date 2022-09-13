using Final_project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Domain.Respons
{
    internal class BaseResponse<T> : IBaseResponse<T>
    {
        public string Discription { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }

    }

    public interface IBaseResponse<T>
    { 
        T Data { get; set; }
    }
}
