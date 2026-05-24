# CreativeCenterCRM

СRM-система для управления центром творчества — занятиями, участниками, расписанием и платежами.  
Разработано на **Blazor Server (ASP.NET Core)** с использованием **Entity Framework Core** и базы данных **SQLite**.  
Контейнеризировано с помощью **Docker** и готово к развёртыванию через **Docker Compose**.

## Структура проекта
```
CreativeCenterCRM/
│
├── wwwroot/                           # Статические файлы (CSS, изображения)
│   ├── bootstrap/                     # Стили Bootstrap
│   ├── app.css                        # Кастомные стили приложения
│   └── favicon.png                    # Иконка сайта
│
├── Components/                        # Blazor-компоненты
│   ├── Layout/                        # Компоненты макета
│   │   ├── MainLayout.razor           # Главный макет страницы (шапка, сайдбар, контент)
│   │   └── NavMenu.razor              # Навигационное меню
│   │
│   └── Pages/						   # Страницы приложения
│       ├── Clubs.razor                # Страница управления клубами
│       ├── Members.razor              # Страница управления участниками
│       ├── Payments.razor             # Страница платежей
│       ├── Schedule.razor             # Страница расписания
│       ├── Home.razor                 # Главная страница (дашборд)
│       └── Error.razor                # Страница ошибки
│
├── _Imports.razor                     # Глобальные using-директивы для всех .razor файлов
├── App.razor                          # Корневой компонент приложения (роутинг)
├── Routes.razor                       # Настройка маршрутизации
│
├── Data/                              # Слой доступа к данным
│   └── AppDbContext.cs                # Контекст Entity Framework (DbSets, настройка БД)
│
├── Migrations/                        # Миграции Entity Framework (история изменений схемы БД)
│
├── Models/                            # Модели данных (сущности)
│   ├── Club.cs                        # Модель клуба
│   ├── Member.cs                      # Модель участника
│   ├── Payment.cs                     # Модель платежа
│   ├── ScheduleItem.cs                # Модель занятия в расписании
│   └── ScheduleMember.cs              # Связующая таблица расписание-участник (M:N)
│
├── Services/                         # Бизнес-логика
│   ├── ICenterService.cs              # Интерфейс сервиса (контракт)
│   └── CenterService.cs               # Реализация сервиса (работа с данными)
│
├── Validators/                        # Валидация данных
│   └── MemberValidator.cs             # Правила валидации для участника
│
├── appsettings.json                   # Конфигурация приложения
├── crm.db                             # Файл базы данных SQLite
├── Program.cs                         # Точка входа, настройка DI и middleware
│
├── Dockerfile                         # Инструкция для сборки Docker-образа (multi-stage)
├── docker-compose.yml                 # Конфигурация развёртывания через Docker Compose
└── .gitignore                         # Исключения для Git
```

## Запуск через Docker Compose

**Требования:** Docker Desktop (или Docker Engine + Docker Compose)

```bash
# 1. Клонировать репозиторий
git clone https://github.com/GusarovaKsenia/creating-center-app.git
cd creating-center-app

# 2. Запустить контейнер в фоновом режиме
docker-compose up -d

# 3. Открыть в браузере
# http://localhost:8013

**Остановить приложение:**

docker-compose down


**Проверить статус контейнера:**

docker-compose ps


**Просмотр логов:**

docker-compose logs -f


## Локальный запуск

**Требования:** .NET 9 SDK

# Клонировать репозиторий
git clone https://github.com/GusarovaKsenia/creating-center-app.git
cd creating-center-app

# Восстановить зависимости
dotnet restore

# Применить миграции (создать/обновить базу данных)
dotnet ef database update

# Запустить приложение
dotnet run

Приложение будет доступно по адресу: `http://localhost:5000`

## API Endpoints

| Endpoint | Описание |
|---|---|
| `GET /api/clubs`   | Список всех клубов      |
| `GET /api/members` | Список всех участников  |
| `GET /api/config`  | Конфигурация приложения |

## Docker-образ

Образ опубликован на Docker Hub и доступен публично:

docker pull kgusarova/creating-center:latest


## Ссылки

**Репозиторий:** https://github.com/GusarovaKsenia/CreativeCenterCRM
**Docker Hub:** https://hub.docker.com/repository/docker/kgurasova/creativecentercrm/general
