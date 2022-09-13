using Final_project.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Design;

namespace Final_project.DAL
{
    public class SushinContext : DbContext
    {
        
        public virtual DbSet<Sushi> Sushis { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Client> Clients{ get; set; }

        public virtual DbSet<Basket> Baskets { get; set; }

        public SushinContext() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=pilot_project;Username=postgres;Password=1234;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients");
                entity.HasKey(x => x.Guid).HasName("Id1");
                entity.Property(x => x.Guid).HasColumnName(@"Guid").HasColumnType("uuid").IsRequired();
                entity.Property(x => x._NameClient).HasColumnName(@"Name").HasColumnType("text").IsRequired();
                entity.Property(x => x._NumberPhone).HasColumnName(@"Phone").HasColumnType("text").IsRequired();
                entity.Property(x => x._AdresClient).HasColumnName(@"Adres").HasColumnType("text").IsRequired();
                entity.Property(x => x._MailClient).HasColumnName(@"Email").HasColumnType("text").IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(x => x.Guid).HasName("Id2");
                entity.Property(x => x.Guid).HasColumnName(@"Guid").HasColumnType("uuid").IsRequired();
                entity.Property(x => x._DateOrder).HasColumnName(@"DateOrder").HasColumnType("timestamp").IsRequired();
                entity.Property(x => x._Price).HasColumnName(@"Price").HasColumnType("numeric").IsRequired();
                entity.Property(x => x.ClientGuid).HasColumnName(@"ClientGuid").HasColumnType("uuid").IsRequired();

                entity.HasOne(a => a.Client).WithMany(b => b.Order).HasForeignKey(c => c.ClientGuid).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Sushi>(entity =>
            {
                entity.ToTable("Sushi");
                entity.HasKey(x => x.Guid).HasName("Key");
                entity.Property(x => x.Guid).HasColumnName(@"Guid").HasColumnType("uuid").IsRequired();
                entity.Property(x => x._Number).HasColumnName(@"Number").HasColumnType("int").IsRequired();
                entity.Property(x => x._Name).HasColumnName(@"Name").HasColumnType("text").IsRequired();
                entity.Property(x => x._Coast).HasColumnName(@"Coast").HasColumnType("numeric").IsRequired();
                entity.Property(x => x._Description).HasColumnName(@"Description").HasColumnType("text").IsRequired();
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("Basket");
                entity.HasKey(x => x.Guid).HasName("Id3");

                entity.Property(x => x.Guid).HasColumnName(@"Guid").HasColumnType("uuid").IsRequired();
                entity.Property(x => x.GuidOrder).HasColumnName(@"GuidOrder").HasColumnType("uuid").IsRequired();
                entity.Property(x => x.Count).HasColumnName(@"Count").HasColumnType("int").IsRequired();

                entity.HasOne(a => a.Order).WithMany(b => b.Basket).HasForeignKey(c => c.GuidOrder).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Sushi>().HasData(
                new Sushi[]
                {
                    new Sushi(1, "Суши с авокадо(Авокадо Нигири)", 1.2,
                     "Ломтики кремообразного авокадо отлично сочетаются со свежесмолотым черным перцем"),

                    new Sushi(2, "Суши с гребешком (Хотатэгай Нигири)", 1.5,
                     "Гребешок морской, рис, васаби"),

                    new Sushi(3, "Суши с копченым лососем (Сяке гурме Нигири)", 2.5,
                     "Лосось копченый, рис, васаби"),

                    new Sushi(4, "Суши с лакедрой желтохвостой (Хамачи Нигири)", 3.5,
                      "Суши нигири с желтохвостой лакедрой, богатой жирными кислотами и полезными микроэлементами"),

                    new Sushi(5, "Суши с лососем (Сяке Нигири)", 1.9,
                      "Ролл с лососем, сливочным сыром и огурцом в оранжевой икре капеллана Масаго"),

                    new Sushi(6, "Суши с моллюском Хоккигай (Хоккигай Нигири)", 4.6,
                      "Лепные суши с моллюском хоккигаем"),

                    new Sushi(7, "Суши с окунем (Идзуми тай Нигири)", 2.1,
                     "Острые суши гункан с морским окунем, приправленные специальным острым соусом спайси"),

                    new Sushi(8, "Суши с омлетом (Тамаго Нигири)", 2.2,
                     "Суши нигири со специальным японским слоистым омлетом тамаго, приправленным соусом унаги"),

                    new Sushi(9, "Суши с осьминогом (Тако Нигири)", 4.9,
                     "Острые суши гункан с мясом осьминога, приправленным специальным острым соусом спайси"),

                    new Sushi(10, "Суши с тигровой креветкой (Эби Нигири)", 3.0,
                     "Запеченые острые суши с крупной креветкой, под икорно-сырным острым соусом"),

                    new Sushi(11, "Суши с тигровой креветкой (Эби Нигири)", 3.0,
                     "Запеченые острые суши с крупной креветкой, под икорно-сырным острым соусом"),

                    new Sushi(12, "Суши с тунцом (Магуро Нигири)", 3.1,
                     "Оригинальный ролл с тунцом, японским омлетом, помидором и майонезом в оранжевой икре"),

                    new Sushi(13, "Суши со сладкой креветкой (Ама Эби Нигири)", 3.9,
                     "Суши гункан с нарезанным мясом крупной креветки, приправленным специальным сладким соусом"),

                    new Sushi(14, "Суши с икрой летучей рыбы в огурце", 3.3,
                     "Суши гункан, заполненные икрой тобико летучей рыбы"),

                    new Sushi(15, "Суши с мидиями в огурце", 4.2,
                     "Запеченые острые суши с мидиями в огурце, под икорно сырным острым соусом"),

                    new Sushi(16, "Суши с салатными креветками в огурце", 3.5,
                     "Суши гункан, заполненные салатом из морских водорослей вакамэ, приправленным орехово-кунжутным соусом"),

                    new Sushi(17, "Суши с цыпленком в огурце", 3.6,
                     "Любимый ролл японского водяного Каппа - ролл с огурцом цыпленком и кунжутом"),

                    new Sushi(18, "Ролл Урамаки Острый гребешок", 4.0,
                     "Гребешок, огурец, тобико, творожный сыр"),

                    new Sushi(19, "Ролл Урамаки Острый кальмар", 4.9,
                     "Ролл с кальмаром, японским омлетом, икрой летучей рыбы и стружкой тунца"),

                    new Sushi(20, "Ролл Урамаки Острый копченый угорь", 4.2,
                     "Рис, нори, угорь, огурец, лосось, кимчи соус, лук зелёный"),

                    new Sushi(21, "Ролл Урамаки Острый морской окунь", 4.3,
                     "Теплый ролл с окунем, огурцом и соусом спайс"),

                   new Sushi(22, "Ролл Урамаки Острый тунец", 4.4,
                    "Ролл с окунем, японским омлетом, икрой летучей рыбы и стружкой тунца"),

                   new Sushi(23, "Ролл Урамаки Острый цыпленок", 4.5,
                    "Оригинальный ролл, необычное сочетание копченой курицы и бекона со свежими овощами и спайси-соусом"),

                   new Sushi(24, "Запеченный ролл Калифорния с крабом", 5.9,
                    "Аппетитный запеченный ролл с салатным крабом, огурцом и сыром сливочным, под шапкой и соуса спайс"),

                   new Sushi(25, "Запеченный ролл Калифорния с лососем", 5.9,
                    "Аппетитный запеченный ролл с нежным лососем, огурцом и сыром сливочным, под шапкой и майонеза"),

                   new Sushi(26, "Запеченный ролл с копченым угрем и омлетом", 5.2,
                    "Аппетитный запечённый ролл с копчёным угрём, японским омлетом, огурцом, мидиями, майонезом, икрой капеллана и сыром Пармезан"),

                   new Sushi(27, "Запеченный ролл с острым гребешком", 5.3,
                    "Рис, нори, лосось, гребешок, крем-сыр, авокадо, спайси соус, унаги соус"),

                   new Sushi(28, "Запеченный ролл с острым кальмаром", 5.4,
                     "Кальмар, фирменная сырная шапка, соус Унаги, кунжут, рис, нори"),

                   new Sushi(29, "Запеченный ролл с острым лососем", 5.5,
                    "Жгучий запеченный ролл с омлетом и творожным сыром под шапочкой из нежного лосося в остром соусе"),

                    new Sushi(30, "Запеченный ролл с острым тунцом", 5.5,
                     "Рис, водоросли нори, авокадо, огурец, сыр творожный, тунец, соус спайси, кунжут жареный, зелень, сыр пармезан, соус калифорния"),
                });
        }
    }
}
