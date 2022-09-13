using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_project.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "text", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id1", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Sushi",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Coast = table.Column<decimal>(type: "numeric(38,17)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Key", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOrder = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ClientGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id2", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientGuid",
                        column: x => x.ClientGuid,
                        principalTable: "Clients",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    GuidOrder = table.Column<Guid>(type: "uuid", nullable: false),
                    SushiGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id3", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Basket_Orders_GuidOrder",
                        column: x => x.GuidOrder,
                        principalTable: "Orders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basket_Sushi_SushiGuid",
                        column: x => x.SushiGuid,
                        principalTable: "Sushi",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Sushi",
                columns: new[] { "Guid", "Coast", "Description", "Name", "Number" },
                values: new object[,]
                {
                    { new Guid("8d4d48cb-5caf-48d9-8838-d78e475f72bb"), 1.2m, "Ломтики кремообразного авокадо отлично сочетаются со свежесмолотым черным перцем", "Суши с авокадо(Авокадо Нигири)", 1 },
                    { new Guid("611b0e2b-98f6-414a-84f8-5664b52b2324"), 5.4m, "Кальмар, фирменная сырная шапка, соус Унаги, кунжут, рис, нори", "Запеченный ролл с острым кальмаром", 28 },
                    { new Guid("208ebcbc-86de-45aa-8bfe-72986e094e17"), 5.3m, "Рис, нори, лосось, гребешок, крем-сыр, авокадо, спайси соус, унаги соус", "Запеченный ролл с острым гребешком", 27 },
                    { new Guid("c997fc8b-a862-4bc1-a5a4-1135c708f400"), 5.2m, "Аппетитный запечённый ролл с копчёным угрём, японским омлетом, огурцом, мидиями, майонезом, икрой капеллана и сыром Пармезан", "Запеченный ролл с копченым угрем и омлетом", 26 },
                    { new Guid("61ae9c5a-8e8f-44c0-ad9b-95d3d8fd819c"), 5.9m, "Аппетитный запеченный ролл с нежным лососем, огурцом и сыром сливочным, под шапкой и майонеза", "Запеченный ролл Калифорния с лососем", 25 },
                    { new Guid("978eccdb-209e-40e7-980f-b2df1ecdae76"), 5.9m, "Аппетитный запеченный ролл с салатным крабом, огурцом и сыром сливочным, под шапкой и соуса спайс", "Запеченный ролл Калифорния с крабом", 24 },
                    { new Guid("8eb2ca02-ed53-445a-b071-29a40752b62a"), 4.5m, "Оригинальный ролл, необычное сочетание копченой курицы и бекона со свежими овощами и спайси-соусом", "Ролл Урамаки Острый цыпленок", 23 },
                    { new Guid("47cae744-620a-43c6-982f-857248ce8dcf"), 4.4m, "Ролл с окунем, японским омлетом, икрой летучей рыбы и стружкой тунца", "Ролл Урамаки Острый тунец", 22 },
                    { new Guid("64a5e578-8243-44a4-93f8-30f09cf88ac2"), 4.3m, "Теплый ролл с окунем, огурцом и соусом спайс", "Ролл Урамаки Острый морской окунь", 21 },
                    { new Guid("d7ec489a-d877-4ecd-8295-74cff0ea95f2"), 4.2m, "Рис, нори, угорь, огурец, лосось, кимчи соус, лук зелёный", "Ролл Урамаки Острый копченый угорь", 20 },
                    { new Guid("2fb01260-5519-431b-9d15-5590b860d001"), 4.9m, "Ролл с кальмаром, японским омлетом, икрой летучей рыбы и стружкой тунца", "Ролл Урамаки Острый кальмар", 19 },
                    { new Guid("05e621e7-6371-4b58-bcd1-7591441a0ebc"), 4m, "Гребешок, огурец, тобико, творожный сыр", "Ролл Урамаки Острый гребешок", 18 },
                    { new Guid("c7ad6b95-971c-4059-8eba-86d3d50ab50c"), 3.6m, "Любимый ролл японского водяного Каппа - ролл с огурцом цыпленком и кунжутом", "Суши с цыпленком в огурце", 17 },
                    { new Guid("b7976852-b3d1-40a1-a89f-2d12425eed4a"), 3.5m, "Суши гункан, заполненные салатом из морских водорослей вакамэ, приправленным орехово-кунжутным соусом", "Суши с салатными креветками в огурце", 16 },
                    { new Guid("c165c3ad-1ab7-4923-a161-fd23817a9411"), 4.2m, "Запеченые острые суши с мидиями в огурце, под икорно сырным острым соусом", "Суши с мидиями в огурце", 15 },
                    { new Guid("190390e3-f258-4099-a8da-c1158c0303d9"), 3.3m, "Суши гункан, заполненные икрой тобико летучей рыбы", "Суши с икрой летучей рыбы в огурце", 14 },
                    { new Guid("7c81d427-47f0-4021-87d1-1b5dc9467e7f"), 3.9m, "Суши гункан с нарезанным мясом крупной креветки, приправленным специальным сладким соусом", "Суши со сладкой креветкой (Ама Эби Нигири)", 13 },
                    { new Guid("458accbc-4807-4217-978b-1a914ebfd12d"), 3.1m, "Оригинальный ролл с тунцом, японским омлетом, помидором и майонезом в оранжевой икре", "Суши с тунцом (Магуро Нигири)", 12 },
                    { new Guid("d61a3153-9b40-4dbb-a3ad-2041108f1f30"), 3m, "Запеченые острые суши с крупной креветкой, под икорно-сырным острым соусом", "Суши с тигровой креветкой (Эби Нигири)", 11 },
                    { new Guid("b93ef713-cb81-4510-ae0c-e357cb2035d9"), 3m, "Запеченые острые суши с крупной креветкой, под икорно-сырным острым соусом", "Суши с тигровой креветкой (Эби Нигири)", 10 },
                    { new Guid("6f1f0d8e-24d1-46ef-b3b1-80ffe9c6a0f4"), 4.9m, "Острые суши гункан с мясом осьминога, приправленным специальным острым соусом спайси", "Суши с осьминогом (Тако Нигири)", 9 },
                    { new Guid("fbea56c8-87cb-4068-ba7b-a89f1676f9bf"), 2.2m, "Суши нигири со специальным японским слоистым омлетом тамаго, приправленным соусом унаги", "Суши с омлетом (Тамаго Нигири)", 8 },
                    { new Guid("6ab21210-5e84-48b6-ac0e-74ad65d4b1dd"), 2.1m, "Острые суши гункан с морским окунем, приправленные специальным острым соусом спайси", "Суши с окунем (Идзуми тай Нигири)", 7 },
                    { new Guid("2554a973-4c97-4212-a540-f104c3050a55"), 4.6m, "Лепные суши с моллюском хоккигаем", "Суши с моллюском Хоккигай (Хоккигай Нигири)", 6 },
                    { new Guid("7e0224f9-d7f9-455f-8510-c00555d64feb"), 1.9m, "Ролл с лососем, сливочным сыром и огурцом в оранжевой икре капеллана Масаго", "Суши с лососем (Сяке Нигири)", 5 },
                    { new Guid("258804e6-6b1c-45a0-8d4c-87e10aa1a8be"), 3.5m, "Суши нигири с желтохвостой лакедрой, богатой жирными кислотами и полезными микроэлементами", "Суши с лакедрой желтохвостой (Хамачи Нигири)", 4 },
                    { new Guid("2d3ddb51-5878-4217-84eb-3267882064cb"), 2.5m, "Лосось копченый, рис, васаби", "Суши с копченым лососем (Сяке гурме Нигири)", 3 },
                    { new Guid("ecaca885-22d0-404a-b489-d3369e9482bf"), 1.5m, "Гребешок морской, рис, васаби", "Суши с гребешком (Хотатэгай Нигири)", 2 },
                    { new Guid("1ffb09aa-e78b-4509-b99d-599c14a70fb9"), 5.5m, "Жгучий запеченный ролл с омлетом и творожным сыром под шапочкой из нежного лосося в остром соусе", "Запеченный ролл с острым лососем", 29 },
                    { new Guid("35cc8ea3-1173-4ec0-b224-350b8fbfd2e8"), 5.5m, "Рис, водоросли нори, авокадо, огурец, сыр творожный, тунец, соус спайси, кунжут жареный, зелень, сыр пармезан, соус калифорния", "Запеченный ролл с острым тунцом", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_GuidOrder",
                table: "Basket",
                column: "GuidOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_SushiGuid",
                table: "Basket",
                column: "SushiGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientGuid",
                table: "Orders",
                column: "ClientGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sushi");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
