using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.DAL;
using Final_project.DAL.Repositories;
using Final_project.Domain.Entity;
using Final_project.Service.Implementations;
using Final_project.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Autofac;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;

public class Program
{
    public static NLog.ILogger Logger = NLog.LogManager.GetCurrentClassLogger();
    private static async Task Main(string[] args)
    {
        Logger.Info("Aplication start");

        Console.WriteLine("Здравствуйте Вас приветствует сервис по заказу суши");
        Console.WriteLine();

        Console.WriteLine("Как вас зовут?");
        Console.WriteLine();
        var client2 = new Client();

    start:
        for (; ; )
        {
            Console.WriteLine("Укажите имя :");
            Console.WriteLine();
            client2._NameClient = Console.ReadLine();

            ValidationContext context = new ValidationContext(client2)
            {
                MemberName = nameof(client2._NameClient)
            };
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(client2._NameClient, context, results))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                    goto start;
                }
            }
            else
                break;

        }
        Console.WriteLine();

    start1:
        for (; ; )
        {
            Console.WriteLine("Укажите номер телефона :");
            Console.WriteLine();
            client2._NumberPhone = Console.ReadLine();
            Logger.Info("Add Number phone client");

            ValidationContext context = new ValidationContext(client2)
            {
                MemberName = nameof(client2._NumberPhone)
            };
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(client2._NumberPhone, context, results))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                    goto start1;
                }
            }
            else
                break;
        }
        Console.WriteLine();

    start2:
        for (; ; )
        {
            Console.WriteLine("Укажите Адрес доставки :");
            Console.WriteLine();
            client2._AdresClient = Console.ReadLine();
            Logger.Info("Add Adress client");

            ValidationContext context = new ValidationContext(client2)
            {
                MemberName = nameof(client2._AdresClient)
            };
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(client2._AdresClient, context, results))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                    goto start2;
                }
            }
            else
                break;
        }
        Console.WriteLine();

    start3:
        for (; ; )
        {
            Console.WriteLine("Укажите Адрес электронной почты :");
            Console.WriteLine();
            client2._MailClient = Console.ReadLine();
            Logger.Info("Add Email client");

            ValidationContext context = new ValidationContext(client2)
            {
                MemberName = nameof(client2._MailClient)
            };
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(client2._MailClient, context, results))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                    goto start3;
                }
            }
            else
                break;
        }
        Console.WriteLine();

        var container = BuildContainer();
        var sushiRepository = container.Resolve<BaseRepository<Sushi>>();
        var clientRepository = container.Resolve<BaseRepository<Client>>();
        var orderRepository = container.Resolve<BaseRepository<Order>>();
        var basketRepository = container.Resolve<BaseRepository<Basket>>();
 
        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SushinContext>().As<DbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<SushiRepository>().As<BaseRepository<Sushi>>();
            builder.RegisterType<SushiService>().As<ISushiService>();
            builder.RegisterType<ClientRepository>().As<BaseRepository<Client>>();
            builder.RegisterType<OrderRepository>().As<BaseRepository<Order>>();
            builder.RegisterType<BasketRepository>().As<BaseRepository<Basket>>();
            return builder.Build();
        }

        var sushiService = container.Resolve<ISushiService>();

        clientRepository.Create(client2);
        clientRepository.Save();

        Console.WriteLine($"Добрый День {client2._NameClient}. Команда Sushi House работает на рынке доставки суши, роллов и других " +
            $"блюд японской кухни уже более 6 лет, и все эти годы главным для нас является любовь и признание наших Гостей.");
        Console.WriteLine();

        Console.WriteLine($"{client2._NameClient} Вы готовы приступить к заказу ???");
        Console.WriteLine();

        Console.WriteLine($"Нажмите кнопку для продолжения");
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine($"Отлично {client2._NameClient} тогда сейчас я вам покажу наше меню");
        Console.WriteLine();

        Console.WriteLine($"Нажмите кнопку для продолжения");
        Console.WriteLine();
        Console.ReadKey();

        var sushies = await sushiService.GetSushiAsync();

        Console.WriteLine($"Номер товара\t\t{"Название",-38}{"Стоимость",-50}Описание");
        Console.WriteLine();
        Console.WriteLine();


        foreach (var item in sushies.Data.OrderBy(x => x._Number))
        {
            Console.WriteLine(item.ToString());
            Console.WriteLine();
        }

        Console.WriteLine();

        Console.WriteLine($" {client2._NameClient} укажите номер товара котрый Вы хотите добавить в карзину");
        Console.WriteLine();
        int numberOrder;


        Order order = new Order();
        Basket basket = new Basket();
        order.Basket.Add(basket);

    start4:
        for (; ; )
        {
            Console.WriteLine("Номер товара :");
            numberOrder = Convert.ToInt32(Console.ReadLine());
            switch (numberOrder)
            {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                    case 30:


                    break;

                default:
                    Console.WriteLine("Введите номер товара от 1 до 30");
                    goto start4;
            }
            break;
        }
        Console.WriteLine("Количество :");
        var countOrder = Convert.ToInt32(Console.ReadLine());

        order.ClientGuid = client2.Guid;

        basket.Sushi= sushies.Data.FirstOrDefault(x => x._Number == numberOrder);
        basket.Order = order;
        basket.GuidOrder = order.Guid;
        order._Price = (decimal)(basket.Sushi._Coast * countOrder);
        basket.Count = countOrder;

        basketRepository.Create(basket);
        basketRepository.Save();
        Logger.Info("Add Order");

        Console.WriteLine("Хотите добавить еще товар?");
        Console.WriteLine();

        Console.WriteLine("Нажмите 1:");
        Console.WriteLine();

        Console.WriteLine("Хотите оформить заказ?");
        Console.WriteLine();

        Console.WriteLine("Нажмите 2:");
        Console.WriteLine();

        Console.WriteLine("Хотите отредактировать заказ?");
        Console.WriteLine();

        Console.WriteLine("Нажмите 3:");
        Console.WriteLine();

        int result;
    start5:
        for (; ; )
        {
            Console.WriteLine("Выберете действие!!");
            result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                start6:
                    for (; ; )
                    {
                        Console.WriteLine("Номер товара :");
                        numberOrder = Convert.ToInt32(Console.ReadLine());
                        switch (numberOrder)
                        {    
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                                break;

                            default:
                                Console.WriteLine("Введите номер товара от 1 до 30");
                                goto start4;
                        }
                        break;
                    }
                    Console.WriteLine("Количество :");
                    countOrder = Convert.ToInt32(Console.ReadLine());

                    Basket basket1 = new Basket();
                    order.Basket.Add(basket1);
                    basket1.Sushi = sushies.Data.FirstOrDefault(x => x._Number == numberOrder);
                    basket1.Order = order;
                    basket1.GuidOrder = order.Guid;
                    order._Price = (decimal)(basket1.Sushi._Coast * countOrder);
                    basket1.Count = countOrder;

                    
                    basketRepository.Create(basket1);
                    basketRepository.Save();
                    orderRepository.Save();
                    Logger.Info("Add Order 2");
                    break;
                    

                case 2:

                    Console.WriteLine("Ваш заказ успешно оформлен!!! ");
                    Console.ReadLine();
                    break;

                case 3:
                start7:
                    for (; ; )
                    {
                        Console.WriteLine("Номер товара :");
                        numberOrder = Convert.ToInt32(Console.ReadLine());
                        switch (numberOrder)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                                break;

                            default:
                                Console.WriteLine("Введите номер товара от 1 до 30");
                                goto start4;
                        }
                        break;
                    }

                    var baskets = await basketRepository.GetListAsync();

                    var basket2 = baskets.FirstOrDefault(x => x.Sushi._Number == numberOrder && x.GuidOrder == order.Guid);

                    if (basket2 == null)
                    {
                        Console.WriteLine("Данного товара нет в корзине! Выберите другой товар");
                        goto start7;
                    }

                    Console.WriteLine("Количество :");
                    countOrder = Convert.ToInt32(Console.ReadLine());

                    basket2.Count = countOrder;

                    basketRepository.Update(basket2);

                    if (countOrder == 0)
                    {
                        basketRepository.Delete(basket2);
                    }

                    basketRepository.Save();
                    break;

                default:
                    Console.WriteLine("Укажите 1, 2 или 3!!");
                    goto start6;
            }
            break;
        }

        var orders = await orderRepository.GetListAsync();
        var actualOrder = orders.FirstOrDefault(x => x.Guid == order.Guid);

        MailAddress from = new MailAddress("spy.dru@gmail.com", $"Sushi House заказ номер - {order.Guid}");
        MailAddress to = new MailAddress($"{client2._MailClient}");
        MailMessage m = new MailMessage(from, to);
        m.Subject = $"Sushi House заказ номер - {order.Guid}";
        m.Body = $"Благодорим за оформление заказа!! " +
            $"\nВаш заказ номер - {order.Guid} успешно оформлен и будкт доставлен в течении 30 мин. \r\n" +
            $"\n1 - {order.Basket.First().Sushi._Name} - {order.Basket.First().Count} \r\n" +
            $"\n1 - {order.Basket.FirstOrDefault(x => x.Sushi._Number == numberOrder).Sushi._Name} - {order.Basket.FirstOrDefault(x => x.Sushi._Number == numberOrder).Count} \r\n" +
            $"\nстоимость -  {order._Price}";
        m.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new NetworkCredential("spy.dru@gmail.com", "oqakoizditfoujbz");
        smtp.EnableSsl = true;
        smtp.Send(m);
        Console.Read();

        Console.WriteLine("Детали вашего заказа высланы на почту!!");
        Console.WriteLine();

        Console.WriteLine("Спасибо");
        Console.ReadLine();
        Logger.Info("Aplication finish");
    }
}