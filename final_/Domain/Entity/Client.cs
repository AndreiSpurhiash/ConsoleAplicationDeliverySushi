using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Final_project.DAL.Interfaces;

namespace Final_project.Domain.Entity
{
    public class Client : IEntity
    {
        [Required(ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidNullName")]
        [MinLength(2, ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidMinLengthName")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidMaxLengthName")]
        public string _NameClient { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidNullAdress")]
        [MinLength(10, ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidMinLengthAdress")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidMaxLengthAdress")]
        public string _AdresClient { get; set; }


        [Required(ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidNullPhone")]
        [MinLength(5, ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidMinLengthPhone")]
        [MaxLength(13, ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidMaxLengthPhone")]
        [RegularExpression(@"(\+375|80)[0-9]{9}", ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidPhone")]
        public string _NumberPhone { get; set; }
        public Guid Guid { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidNullEmail")]
        [RegularExpression(@"[a-zA-Z0-9\._\-]+@[a-zA-Z0-9\-\.]+\.[a-zA-Z0-9]{2,6}", ErrorMessageResourceType = typeof(Localization), ErrorMessageResourceName = "InvalidEmail")]
        public string _MailClient { get; set; }

        public ICollection<Order> Order { get; set; } = new List<Order>();

        public Client(string NameClient, string AdresClient, string NumberPhone, string MailClient)
        {
            Guid = Guid.NewGuid();
            _NameClient = NameClient;
            _AdresClient = AdresClient; 
            _NumberPhone = NumberPhone;
            _MailClient = MailClient;

        }
        public Client()
        {
           
        }
    }
}
