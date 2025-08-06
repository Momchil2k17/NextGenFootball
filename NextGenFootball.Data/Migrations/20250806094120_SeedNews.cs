using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Author", "Content", "ImageUrl", "PublishedOn", "Title" },
                values: new object[,]
                {
                    { 1, "Асен Митков", "Дисциплинарната комисия към БФС взе решение да накаже за 3 мача таланта на Лудогорец Ивайло Тодоров за провинение по време на шампионатния двубой срещу Септември от първенството на елитната юношеска група до 17 години. Това стана след сезиране на комисията от страна на софиянци.\r\n\r\n\"Дисциплинарна комисия\r\n\r\nРешения  -  22.11.2024 г.\r\n13-ти кръг U – 17\r\n\r\nОтложен за разглеждане инцидент от срещата ПФК „Лудогорец“ гр. Разград – ПФК „Септември“ гр. София по сезиране на ПФК „Септември“. По сезиране на ПФК „Септември“ гр. София и Експертно становище на СК при БФС на основание чл.22, ал.2, б. Г, колонка 3 от ДП /2024/2025/ – ДК наказва Ивайло Иванов Тодоров – състезател на ПФК „Лудогорец“ гр. Разград със спиране на състезателни права за 3 срещи. Решението е окончателно и не подлежащи на обжалване\", гласи съобщението от БФС.", "https://sportal365images.com/process/smp-images-production/sportal.bg/18112024/0bcc1a75-e211-409b-83ec-b6fc5625c4f7.jpg?operations=crop(21:87:1050:666),fit(968:545)&format=webp", new DateTime(2025, 8, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "БФС наказа играч на Лудогорец за 3 мача" },
                    { 2, "Кирил Бойчев", "С исторически успех се поздравиха младите надежди на Миньор (Перник), родени 2008/2009 година. Водени от треньора Георги Рошилков, те постигнаха нещо, което досега никой юношески отбор от миньорския град не беше успявал - класиране в Елитната юношеска група до 18 години за сезон 2025/2026.\r\n\r\nПътят към елита не беше лек. Младите \"чукове\" първо спечелиха Зоналната група до 17 години, след което изиграха оспорван бараж срещу представителя на София-град - Локомотив (София). В този двубой момчетата на Рошилков показаха характер, дисциплина и силна воля за победа.", "https://sportal365images.com/process/smp-images-production/sportal.bg/15062025/3a45141d-8242-4863-9d42-02d2cd472a50.jpg?operations=crop(0:0:677:381),fit(968:545)&format=webp", new DateTime(2025, 8, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), "Юношите на Миньор (Перник) за първи път ще играят в Елитна група" },
                    { 3, "Иван Димитров", "Левски продължава с отличното си представяне в Елитната юношеска група до 17 години. Възпитаниците на треньора Георги Тодоров записаха нова победа, този път срещу ЦСКА-София с 3:1 в дербито на кръга.\r\n\r\nСрещата се игра на стадион \"Георги Аспарухов\" и привлече вниманието на много фенове, които подкрепяха младите таланти на Левски. Головете за домакините бяха дело на Иван Петров, Димитър Георгиев и Александър Николов, докато за ЦСКА-София точен беше Георги Иванов.", "https://sportal365images.com/process/smp-images-production/sportal.bg/19062025/ee556893-0afb-44fe-a922-d41c39268d1c.jpg?operations=crop(0:166:1600:1066),fit(968:545)&format=webp", new DateTime(2025, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Левски с нова победа в Елитната юношеска група" },
                    { 4, "Иван Петров", "Новият сезон на младежката футболна лига стартира с оспорвани срещи и ентусиазирани фенове.", "https://sportal365images.com/process/smp-images-production/sportal.bg/15042024/837e5415-642f-4bf7-ba6a-1062d0675e12.jpg?operations=autocrop(968:545)&format=webp", new DateTime(2025, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), "Младежката лига започва с вълнуващи мачове" },
                    { 5, "Мария Георгиева", "Няколко водещи млади играчи преминаха в нови отбори, което обещава интересен сезон.", "https://sportal365images.com/process/smp-images-production/sportal.bg/11062023/51a41da2-ca85-4809-8bc2-7031fda25a36.jpg?operations=autocrop(968:545)&format=webp", new DateTime(2025, 8, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Трансфери на млади таланти" },
                    { 6, "Георги Иванов", "Основните детски стадиони са обновени за по-добро преживяване на младите футболисти и фенове.", "https://sportal365images.com/process/smp-images-production/sportal.bg/21042023/02296461-c6f2-4413-b880-53a414e82524.jpg?operations=crop(0:0:4437:2495),fit(968:545)&format=webp", new DateTime(2025, 8, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), "Ремонт на детските стадиони приключи" },
                    { 7, "Стефан Димитров", "Голям бранд става основен спонсор на младежката лига през този сезон.", "https://sportal365images.com/process/smp-images-production/sportal.bg/17092022/b19e1f92-c16d-4259-a572-983f4b7a81df.jpeg?operations=crop(0:85:637:443),fit(968:545)&format=webp", new DateTime(2025, 8, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), "Нов спонсор подкрепя младежкия футбол" },
                    { 8, "Елена Костова", "Отборите се готвят усилено в тренировъчни лагери преди началото на мачовете.", "https://sportal365images.com/process/smp-images-production/sportal.bg/29032021/1617022055331.png?operations=autocrop(968:545)&format=webp", new DateTime(2025, 8, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Подготовка за сезона в младежките лагери" },
                    { 9, "Петър Тодоров", "Няколко нови играчи показаха отлични умения по време на тренировките.", "https://sportal365images.com/process/smp-images-production/sportal.bg/25062025/d53a3e3d-405a-46d5-9beb-b56d745b4b66.jpg?operations=crop(0:102:1000:665),fit(968:545)&format=webp", new DateTime(2025, 8, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), "Млади таланти впечатляват треньорите" },
                    { 10, "Кристина Василева", "Пълният график за сезона на младежите вече е достъпен за всички.", "https://sportal365images.com/process/smp-images-production/sportal.bg/21112024/34e93f30-7489-4fa1-909f-2dfc049c36a0.png?operations=crop(59:3:1813:990),fit(968:545)&format=webp", new DateTime(2025, 8, 6, 16, 0, 0, 0, DateTimeKind.Unspecified), "Графикът на младежката лига е публикуван" },
                    { 11, "Николай Николов", "Предсезонните турнири при младежите приключиха с изненадващи резултати.", "https://sportal365images.com/process/smp-images-production/sportal.bg/19082024/657cbbea-f2e9-4632-92f4-a41ff388c5a5.jpg?operations=crop(0:31:800:481),fit(968:545)&format=webp", new DateTime(2025, 8, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), "Резултати от предсезонните турнири" },
                    { 12, "Виктория Димитрова", "Въведени са нови правила и регулации за честна игра в младежките първенства.", "https://sportal365images.com/process/smp-images-production/sportal.bg/14082024/11d21dbc-b36d-48bc-aaee-393af48ddfc8.jpg?operations=crop(0:59:1999:1184),fit(968:545)&format=webp", new DateTime(2025, 8, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), "Новите правила за младежкия футбол" },
                    { 13, "Александър Михайлов", "Планирани са различни събития за ангажиране на феновете през целия сезон.", "https://sportal365images.com/process/smp-images-production/sportal.bg/30052024/96b347af-2670-40df-b809-43162bc7ef6f.jpeg?operations=crop(0:59:800:509),fit(968:545)&format=webp", new DateTime(2025, 8, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), "Специални събития за феновете на младежкия футбол" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
