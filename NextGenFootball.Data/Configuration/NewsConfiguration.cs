using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using static NextGenFootball.Data.Common.EntityConstants.NewsValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> entity)
        {
            entity
                .HasKey(n => n.Id);

            entity
                .Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            entity
                .Property(n => n.Content)
                .IsRequired()
                .HasMaxLength(ContentMaxLength);

            entity
                .Property(n => n.Author)
                .IsRequired()
                .HasMaxLength(AuthorMaxLength);

            entity
                .Property(n => n.PublishedOn)
                .IsRequired();

            entity
                .Property(n => n.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);
            entity
                .HasData(this.SeedNews());
            entity
                .HasData(this.SeedNews2());

        }
        public IEnumerable<News> SeedNews()
        {
            return new List<News>
            {
                new News
                {
                    Id = 1,
                    Title = "БФС наказа играч на Лудогорец за 3 мача",
                    Content = "Дисциплинарната комисия към БФС взе решение да накаже за 3 мача таланта на Лудогорец Ивайло Тодоров за провинение по време на шампионатния двубой срещу Септември от първенството на елитната юношеска група до 17 години. Това стана след сезиране на комисията от страна на софиянци.\r\n\r\n\"Дисциплинарна комисия\r\n\r\nРешения  -  22.11.2024 г.\r\n13-ти кръг U – 17\r\n\r\nОтложен за разглеждане инцидент от срещата ПФК „Лудогорец“ гр. Разград – ПФК „Септември“ гр. София по сезиране на ПФК „Септември“. По сезиране на ПФК „Септември“ гр. София и Експертно становище на СК при БФС на основание чл.22, ал.2, б. Г, колонка 3 от ДП /2024/2025/ – ДК наказва Ивайло Иванов Тодоров – състезател на ПФК „Лудогорец“ гр. Разград със спиране на състезателни права за 3 срещи. Решението е окончателно и не подлежащи на обжалване\", гласи съобщението от БФС.",
                    Author = "Асен Митков",
                     PublishedOn = new DateTime(2025, 8, 10, 12, 0, 0),
                    ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/18112024/0bcc1a75-e211-409b-83ec-b6fc5625c4f7.jpg?operations=crop(21:87:1050:666),fit(968:545)&format=webp"
                },
                new News
                {
                    Id = 2,
                    Title = "Юношите на Миньор (Перник) за първи път ще играят в Елитна група",
                    Content = "С исторически успех се поздравиха младите надежди на Миньор (Перник), родени 2008/2009 година. Водени от треньора Георги Рошилков, те постигнаха нещо, което досега никой юношески отбор от миньорския град не беше успявал - класиране в Елитната юношеска група до 18 години за сезон 2025/2026.\r\n\r\nПътят към елита не беше лек. Младите \"чукове\" първо спечелиха Зоналната група до 17 години, след което изиграха оспорван бараж срещу представителя на София-град - Локомотив (София). В този двубой момчетата на Рошилков показаха характер, дисциплина и силна воля за победа.",
                    Author = "Кирил Бойчев",
                     PublishedOn = new DateTime(2025, 8, 10, 11, 0, 0),
                    ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/15062025/3a45141d-8242-4863-9d42-02d2cd472a50.jpg?operations=crop(0:0:677:381),fit(968:545)&format=webp"
                },
                new News
                {
                    Id= 3,
                    Title = "Левски с нова победа в Елитната юношеска група",
                    Content = "Левски продължава с отличното си представяне в Елитната юношеска група до 17 години. Възпитаниците на треньора Георги Тодоров записаха нова победа, този път срещу ЦСКА-София с 3:1 в дербито на кръга.\r\n\r\nСрещата се игра на стадион \"Георги Аспарухов\" и привлече вниманието на много фенове, които подкрепяха младите таланти на Левски. Головете за домакините бяха дело на Иван Петров, Димитър Георгиев и Александър Николов, докато за ЦСКА-София точен беше Георги Иванов.",
                    Author = "Иван Димитров",
                    PublishedOn = new DateTime(2025, 8, 10, 10, 0, 0),
                    ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/19062025/ee556893-0afb-44fe-a922-d41c39268d1c.jpg?operations=crop(0:166:1600:1066),fit(968:545)&format=webp"
                }
            };
        }
        public IEnumerable<News> SeedNews2()
        {
            return new List<News>
            {
                new News { Id = 4, Title = "Младежката лига започва с вълнуващи мачове", Content = "Новият сезон на младежката футболна лига стартира с оспорвани срещи и ентусиазирани фенове.", PublishedOn = new DateTime(2025, 8, 6, 10, 0, 0), Author = "Иван Петров", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/15042024/837e5415-642f-4bf7-ba6a-1062d0675e12.jpg?operations=autocrop(968:545)&format=webp" },
                new News { Id = 5, Title = "Трансфери на млади таланти", Content = "Няколко водещи млади играчи преминаха в нови отбори, което обещава интересен сезон.", PublishedOn = new DateTime(2025, 8, 7, 11, 0, 0), Author = "Мария Георгиева", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/11062023/51a41da2-ca85-4809-8bc2-7031fda25a36.jpg?operations=autocrop(968:545)&format=webp" },
                new News { Id = 6, Title = "Ремонт на детските стадиони приключи", Content = "Основните детски стадиони са обновени за по-добро преживяване на младите футболисти и фенове.", PublishedOn = new DateTime(2025, 8, 8, 12, 0, 0), Author = "Георги Иванов", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/21042023/02296461-c6f2-4413-b880-53a414e82524.jpg?operations=crop(0:0:4437:2495),fit(968:545)&format=webp" },
                new News { Id = 7, Title = "Нов спонсор подкрепя младежкия футбол", Content = "Голям бранд става основен спонсор на младежката лига през този сезон.", PublishedOn = new DateTime(2025, 8, 9, 13, 0, 0), Author = "Стефан Димитров", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/17092022/b19e1f92-c16d-4259-a572-983f4b7a81df.jpeg?operations=crop(0:85:637:443),fit(968:545)&format=webp" },
                new News { Id = 8, Title = "Подготовка за сезона в младежките лагери", Content = "Отборите се готвят усилено в тренировъчни лагери преди началото на мачовете.", PublishedOn = new DateTime(2025, 8, 10, 14, 0, 0), Author = "Елена Костова", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/29032021/1617022055331.png?operations=autocrop(968:545)&format=webp" },
                new News { Id = 9, Title = "Млади таланти впечатляват треньорите", Content = "Няколко нови играчи показаха отлични умения по време на тренировките.", PublishedOn = new DateTime(2025, 8, 9, 15, 0, 0), Author = "Петър Тодоров", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/25062025/d53a3e3d-405a-46d5-9beb-b56d745b4b66.jpg?operations=crop(0:102:1000:665),fit(968:545)&format=webp" },
                new News { Id = 10, Title = "Графикът на младежката лига е публикуван", Content = "Пълният график за сезона на младежите вече е достъпен за всички.", PublishedOn = new DateTime(2025, 8, 6, 16, 0, 0), Author = "Кристина Василева", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/21112024/34e93f30-7489-4fa1-909f-2dfc049c36a0.png?operations=crop(59:3:1813:990),fit(968:545)&format=webp" },
                new News { Id = 11, Title = "Резултати от предсезонните турнири", Content = "Предсезонните турнири при младежите приключиха с изненадващи резултати.", PublishedOn = new DateTime(2025, 8, 3, 17, 0, 0), Author = "Николай Николов", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/19082024/657cbbea-f2e9-4632-92f4-a41ff388c5a5.jpg?operations=crop(0:31:800:481),fit(968:545)&format=webp" },
                new News { Id = 12, Title = "Новите правила за младежкия футбол", Content = "Въведени са нови правила и регулации за честна игра в младежките първенства.", PublishedOn = new DateTime(2025, 8, 4, 18, 0, 0), Author = "Виктория Димитрова", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/14082024/11d21dbc-b36d-48bc-aaee-393af48ddfc8.jpg?operations=crop(0:59:1999:1184),fit(968:545)&format=webp" },
                new News { Id = 13, Title = "Специални събития за феновете на младежкия футбол", Content = "Планирани са различни събития за ангажиране на феновете през целия сезон.", PublishedOn = new DateTime(2025, 8, 5, 19, 0, 0), Author = "Александър Михайлов", ImageUrl = "https://sportal365images.com/process/smp-images-production/sportal.bg/30052024/96b347af-2670-40df-b809-43162bc7ef6f.jpeg?operations=crop(0:59:800:509),fit(968:545)&format=webp" }
            };
            } 
    }
}
