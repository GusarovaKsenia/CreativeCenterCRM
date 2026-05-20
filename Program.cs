using CreativeCenterCRM.Components;
using CreativeCenterCRM.Data;
using CreativeCenterCRM.Models;
using CreativeCenterCRM.Services;
using CreativeCenterCRM.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=crm.db"));

builder.Services.AddScoped<ICenterService, CenterService>();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.EnsureCreated();

    if (!db.Clubs.Any())
    {
        var clubs = new List<Club>
        {
            new Club {
                Name = "Батик",
                Description = "Роспись по ткани",
                TeacherName = "Иванова А.А."
            },
            new Club {
                Name = "Витраж",
                Description = "Создание витражей из стекла",
                TeacherName = "Петрова В.В."
            },
            new Club {
                Name = "Живопись маслом",
                Description = "Классическая масляная живопись",
                TeacherName = "Сидорова Е.Е."
            },
            new Club {
                Name = "Акварельная живопись",
                Description = "Работа с акварельными красками",
                TeacherName = "Козлова И.И."
            },
            new Club {
                Name = "Вышивание",
                Description = "Вышивка крестом и гладью",
                TeacherName = "Новикова М.М."
            },
            new Club {
                Name = "Бисероплетение",
                Description = "Создание украшений из бисера",
                TeacherName = "Васильева О.О."
            },
            new Club {
                Name = "Скрапбукинг",
                Description = "Оформление фотоальбомов",
                TeacherName = "Морозова Д.Д."
            },
            new Club {
                Name = "Кастомизация элементов одежды и аксессуаров",
                Description = "Творческий апсайлинг одежды",
                TeacherName = "Попова А.А."
            },
            new Club {
                Name = "Мыловарение",
                Description = "Создание натурального мыла",
                TeacherName = "Лебедева С.С."
            },
            new Club {
                Name = "Свечеварение",
                Description = "Изготовление декоративных свечей",
                TeacherName = "Кузнецов П.П."
            },
            new Club {
                Name = "Гончарное дело",
                Description = "Работа с глиной на гончарном круге",
                TeacherName = "Соколов И.И."
            },
            new Club {
                Name = "3D-моделирование",
                Description = "Создание 3D-моделей",
                TeacherName = "Волков А.А."
            },
            new Club {
                Name = "Конструирование",
                Description = "Разработка конструкций и механизмов",
                TeacherName = "Семенов В.В."
            },
            new Club {
                Name = "Работа с деревом и металлом",
                Description = "Художественная обработка материалов",
                TeacherName = "Федоров Н.Н."
            }
        };

        db.Clubs.AddRange(clubs);
        await db.SaveChangesAsync();
    }

    if (!db.Members.Any())
    {
        var batikClub = db.Clubs.First(c => c.Name == "Батик");
        var vitrazhClub = db.Clubs.First(c => c.Name == "Витраж");
        var живописьClub = db.Clubs.First(c => c.Name == "Живопись маслом");
        var акварельClub = db.Clubs.First(c => c.Name == "Акварельная живопись");
        var вышиваниеClub = db.Clubs.First(c => c.Name == "Вышивание");
        var бисероплетениеClub = db.Clubs.First(c => c.Name == "Бисероплетение");
        var скрапбукингClub = db.Clubs.First(c => c.Name == "Скрапбукинг");
        var кастомизацияClub = db.Clubs.First(c => c.Name == "Кастомизация элементов одежды и аксессуаров");
        var мыловарениеClub = db.Clubs.First(c => c.Name == "Мыловарение");
        var свечеварениеClub = db.Clubs.First(c => c.Name == "Свечеварение");
        var гончарноеClub = db.Clubs.First(c => c.Name == "Гончарное дело");
        var modeling3DClub = db.Clubs.First(c => c.Name == "3D-моделирование");
        var конструированиеClub = db.Clubs.First(c => c.Name == "Конструирование");
        var деревометаллClub = db.Clubs.First(c => c.Name == "Работа с деревом и металлом");

        var members = new List<Member>
        {
            new Member {
                FirstName = "Мария",
                LastName = "Киселёва",
                Age = 12,
                Phone = "89001112233",
                Comment = "Любит рисовать акварелью",
                ClubId = акварельClub.Id
            },
            new Member {
                FirstName = "Алина",
                LastName = "Грибанова",
                Age = 10,
                Phone = "89002223344",
                Comment = "Увлекается вышивкой",
                ClubId = вышиваниеClub.Id
            },
            new Member {
                FirstName = "Анастасия",
                LastName = "Филипчук",
                Age = 14,
                Phone = "89003334455",
                Comment = "Интересуется 3D-моделированием",
                ClubId = modeling3DClub.Id
            },
            new Member {
                FirstName = "София",
                LastName = "Анисимова",
                Age = 9,
                Phone = "89004445566",
                Comment = "Творческая и внимательная",
                ClubId = batikClub.Id
            },
            new Member {
                FirstName = "Виктория",
                LastName = "Ипатова",
                Age = 11,
                Phone = "89005556677",
                Comment = "Любит работать с глиной",
                ClubId = гончарноеClub.Id
            },
            new Member {
                FirstName = "Александр",
                LastName = "Петров",
                Age = 13,
                Phone = "89006667788",
                Comment = "Увлекается программированием",
                ClubId = modeling3DClub.Id
            },
            new Member {
                FirstName = "Екатерина",
                LastName = "Смирнова",
                Age = 8,
                Phone = "89007778899",
                Comment = "Начинающий художник",
                ClubId = живописьClub.Id
            },
            new Member {
                FirstName = "Дмитрий",
                LastName = "Волков",
                Age = 15,
                Phone = "89008889900",
                Comment = "Интересуется работой с металлом",
                ClubId = деревометаллClub.Id
            },
            new Member {
                FirstName = "Анна",
                LastName = "Кузнецова",
                Age = 10,
                Phone = "89009990011",
                Comment = "Любит создавать украшения из бисера",
                ClubId = бисероплетениеClub.Id
            },
            new Member {
                FirstName = "Михаил",
                LastName = "Соколов",
                Age = 12,
                Phone = "89010001122",
                Comment = "Увлекается конструированием",
                ClubId = конструированиеClub.Id
            },
            new Member {
                FirstName = "Полина",
                LastName = "Лебедева",
                Age = 9,
                Phone = "89011112233",
                Comment = "Творческая личность",
                ClubId = скрапбукингClub.Id
            },
            new Member {
                FirstName = "Артем",
                LastName = "Козлов",
                Age = 14,
                Phone = "89012223344",
                Comment = "Интересуется витражами",
                ClubId = vitrazhClub.Id
            },
            new Member {
                FirstName = "Варвара",
                LastName = "Новикова",
                Age = 11,
                Phone = "89013334455",
                Comment = "Любит мыловарение",
                ClubId = мыловарениеClub.Id
            },
            new Member {
                FirstName = "Иван",
                LastName = "Морозов",
                Age = 13,
                Phone = "89014445566",
                Comment = "Увлекается свечеварением",
                ClubId = свечеварениеClub.Id
            },
            new Member {
                FirstName = "Дарья",
                LastName = "Попова",
                Age = 10,
                Phone = "89015556677",
                Comment = "Любит кастомизацию одежды",
                ClubId = кастомизацияClub.Id
            },
            new Member {
                FirstName = "Никита",
                LastName = "Васильев",
                Age = 15,
                Phone = "89016667788",
                Comment = "Интересуется 3D-печатью",
                ClubId = modeling3DClub.Id
            },
            new Member {
                FirstName = "Алиса",
                LastName = "Семенова",
                Age = 8,
                Phone = "89017778899",
                Comment = "Начинает изучать живопись",
                ClubId = акварельClub.Id
            },
            new Member {
                FirstName = "Максим",
                LastName = "Голубев",
                Age = 12,
                Phone = "89018889900",
                Comment = "Увлекается работой с деревом",
                ClubId = деревометаллClub.Id
            },
            new Member {
                FirstName = "Елизавета",
                LastName = "Виноградова",
                Age = 11,
                Phone = "89019990011",
                Comment = "Любит батик",
                ClubId = batikClub.Id
            },
            new Member {
                FirstName = "Кирилл",
                LastName = "Богданов",
                Age = 14,
                Phone = "89020001122",
                Comment = "Интересуется гончарным делом",
                ClubId = гончарноеClub.Id
            },
            new Member {
                FirstName = "Маргарита",
                LastName = "Орлова",
                Age = 9,
                Phone = "89021112233",
                Comment = "Творческая и аккуратная",
                ClubId = вышиваниеClub.Id
            },
            new Member {
                FirstName = "Павел",
                LastName = "Киселев",
                Age = 13,
                Phone = "89022223344",
                Comment = "Увлекается конструированием роботов",
                ClubId = конструированиеClub.Id
            },
            new Member {
                FirstName = "Арина",
                LastName = "Андреева",
                Age = 10,
                Phone = "89023334455",
                Comment = "Любит скрапбукинг",
                ClubId = скрапбукингClub.Id
            },
            new Member {
                FirstName = "Роман",
                LastName = "Ковалев",
                Age = 15,
                Phone = "89024445566",
                Comment = "Интересуется масляной живописью",
                ClubId = живописьClub.Id
            },
            new Member {
                FirstName = "Ксения",
                LastName = "Ильина",
                Age = 11,
                Phone = "89025556677",
                Comment = "Увлекается бисероплетением",
                ClubId = бисероплетениеClub.Id
            }
        };

        db.Members.AddRange(members);
        await db.SaveChangesAsync();
    }

    if (!db.Schedules.Any())
    {
        var batikClub = db.Clubs.First(c => c.Name == "Батик");
        var живописьClub = db.Clubs.First(c => c.Name == "Живопись маслом");
        var акварельClub = db.Clubs.First(c => c.Name == "Акварельная живопись");
        var гончарноеClub = db.Clubs.First(c => c.Name == "Гончарное дело");

        var schedules = new List<ScheduleItem>
        {
            new ScheduleItem {
                DayOfWeek = "Понедельник",
                StartTime = new TimeSpan(14, 0, 0),
                EndTime = new TimeSpan(15, 30, 0),
                ClubId = batikClub.Id,
                Room = "101",
                MaxSeats = 10,
                CurrentSeats = 1
            },
            new ScheduleItem {
                DayOfWeek = "Вторник",
                StartTime = new TimeSpan(15, 0, 0),
                EndTime = new TimeSpan(16, 30, 0),
                ClubId = акварельClub.Id,
                Room = "102",
                MaxSeats = 12,
                CurrentSeats = 1
            },
            new ScheduleItem {
                DayOfWeek = "Среда",
                StartTime = new TimeSpan(15, 0, 0),
                EndTime = new TimeSpan(16, 30, 0),
                ClubId = живописьClub.Id,
                Room = "205",
                MaxSeats = 12,
                CurrentSeats = 1
            },
            new ScheduleItem {
                DayOfWeek = "Пятница",
                StartTime = new TimeSpan(16, 0, 0),
                EndTime = new TimeSpan(17, 30, 0),
                ClubId = гончарноеClub.Id,
                Room = "301",
                MaxSeats = 8,
                CurrentSeats = 0
            }
        };

        db.Schedules.AddRange(schedules);
        await db.SaveChangesAsync();
    }
}

app.Run();