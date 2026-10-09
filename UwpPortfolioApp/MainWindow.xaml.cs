using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace UwpPortfolioApp;

public sealed partial class MainWindow : Window
{
    private readonly PortfolioViewModel _viewModel = new();

    public MainWindow()
    {
        InitializeComponent();
        LoadSection("Home");
    }

    private void RootNavigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItem is NavigationViewItem item && item.Tag is string tag)
        {
            LoadSection(tag);
        }
    }

    private void LoadSection(string section)
    {
        var info = _viewModel.GetSection(section);
        HeaderText.Text = info.Title;
        SubHeaderText.Text = info.Description;
        CardsRepeater.ItemsSource = info.Cards;
    }
}

public sealed class InfoCard
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
}

public sealed class SectionInfo
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ObservableCollection<InfoCard> Cards { get; set; } = new();
}

public sealed class PortfolioViewModel
{
    public SectionInfo GetSection(string section)
    {
        return section switch
        {
            "Home" => new SectionInfo
            {
                Title = "Главная",
                Description = "Личное портфолио, проекты, идеи и помощник разработчика.",
                Cards = new ObservableCollection<InfoCard>
                {
                    new() { Title = "adelka4745", Description = "Портфолио разработчика и идеи для будущих продуктов.", Tag = "Бренд" },
                    new() { Title = "ShellOS", Description = "Собственная OS-идея с концепцией разработки и архитектурой.", Tag = "OS" },
                    new() { Title = "Unity & VR", Description = "Контент, эксперименты и разработка VR-решений.", Tag = "VR" },
                    new() { Title = "Мои проекты", Description = "Пакет идей с планами, функциями и статусом реализации.", Tag = "Проекты" },
                    new() { Title = "Помощь по программированию", Description = "Шпора по языкам, шаблонам, Git и проектам.", Tag = "Dev" }
                }
            },

            "Projects" => new SectionInfo
            {
                Title = "Проекты",
                Description = "Список активных, планируемых и завершённых направлений.",
                Cards = new ObservableCollection<InfoCard>
                {
                    new() { Title = "ShellOS", Description = "Разработка собственной операционной системы с идеей архитектуры и интерфейса.", Tag = "В разработке" },
                    new() { Title = "Unity VR Hub", Description = "VR-проекты, эксперименты и игровые механики с Meta Quest.", Tag = "VR" },
                    new() { Title = "Portfolio App", Description = "Десктопное приложение для портфолио, заметок и справочника.", Tag = "Desktop" },
                    new() { Title = "Code Library", Description = "Библиотека полезных шаблонов, заметок и кода.", Tag = "Patterns" },
                    new() { Title = "Идеи", Description = "Список концептов и будущих решений для развития.", Tag = "Future" }
                }
            },

            "Categories" => new SectionInfo
            {
                Title = "Категории",
                Description = "Разделение контента по технологиям, темам и направлениям.",
                Cards = new ObservableCollection<InfoCard>
                {
                    new() { Title = "Программирование", Description = "C#, C++, Python, JavaScript, Rust, Go и многое другое.", Tag = "Code" },
                    new() { Title = "Игры", Description = "Разработка механик, уровней, архитектуры и игровых систем.", Tag = "Games" },
                    new() { Title = "VR / AR", Description = "Гарнитуры, взаимодействия, пространственные интерфейсы и эксп��рименты.", Tag = "XR" },
                    new() { Title = "ОС и ядро", Description = "Системное программирование, идеи компонентов и архитектуры.", Tag = "Kernel" },
                    new() { Title = "Идеи", Description = "Концепции будущих проектов и экспериментальные мысли.", Tag = "Brain" }
                }
            },

            "Languages" => new SectionInfo
            {
                Title = "Языки программирования",
                Description = "Шпаргалки и краткая справка по языкам разработки.",
                Cards = new ObservableCollection<InfoCard>
                {
                    new() { Title = "C#", Description = "Универсальный язык для .NET, UWP, Unity и приложений Windows.", Tag = "Core" },
                    new() { Title = "C++", Description = "Низкоуровневый и мощный язык для системного и игрового программирования.", Tag = "System" },
                    new() { Title = "Python", Description = "Быстрая разработка, скрипты, AI и автоматизация задач.", Tag = "Scripting" },
                    new() { Title = "JavaScript", Description = "Frontend, backend и веб-экосистема.", Tag = "Web" },
                    new() { Title = "TypeScript", Description = "Статическая типизация для масштабируемых проектов.", Tag = "Typed" },
                    new() { Title = "Rust", Description = "Безопасность и производительность для системных проектов.", Tag = "Safe" },
                    new() { Title = "Go", Description = "Простой язык для сервисов и инструментов.", Tag = "Backend" },
                    new() { Title = "Java", Description = "Корпоративная разработка и кроссплатформенные сервисы.", Tag = "Enterprise" },
                    new() { Title = "SQL", Description = "Работа с данными, запросами и схемами хранения.", Tag = "Data" },
                    new() { Title = "HTML / CSS", Description = "Разметка, стили и б��зовые интерфейсы.", Tag = "Frontend" }
                }
            },

            "Help" => new SectionInfo
            {
                Title = "Помощь по программированию",
                Description = "Шаблоны, примеры, заметки и справочные материалы по языкам и разработке.",
                Cards = new ObservableCollection<InfoCard>
                {
                    new() { Title = "Шаблоны кода", Description = "Базовые каркасы для приложения, сервиса, консоли и веба.", Tag = "Templates" },
                    new() { Title = "Git", Description = "Команды веток, коммитов, pull request, merge и восстановления.", Tag = "Git" },
                    new() { Title = "C# / .NET", Description = "Классы, структуры, коллекции, LINQ, async/await.", Tag = "C#" },
                    new() { Title = "Python", Description = "Синтаксис, функции, модули, списки, словари и работа с файлами.", Tag = "Python" },
                    new() { Title = "JavaScript", Description = "Функции, DOM, асинхронность, объекты и события.", Tag = "JS" },
                    new() { Title = "SQL", Description = "SELECT, JOIN, WHERE, GROUP BY, индексы и запросы.", Tag = "SQL" },
                    new() { Title = "Справка по архитектуре", Description = "Модели, слои, SOLID, паттерны и проектирование.", Tag = "Design" },
                    new() { Title = "Debug Guide", Description = "Как искать баги, читать стек вызовов и отлаживать код.", Tag = "Debug" }
                }
            },

            "Notes" => new SectionInfo
            {
                Title = "Заметки",
                Description = "Личные мысли, идеи, записи и внутренние статьи разработчика.",
                Cards = new ObservableCollection<InfoCard>
                {
                    new() { Title = "Идея 1", Description = "Сделать решатель задач и справочник по языкам программирования.", Tag = "Idea" },
                    new() { Title = "Идея 2", Description = "Создать локальный инструмент для хранения уроков и заметок.", Tag = "Tool" },
                    new() { Title = "Третья мысль", Description = "Двигаться от хаоса к структурному порядку в коде и проектах.", Tag = "Plan" },
                    new() { Title = "Дневник", Description = "Подводить итоги по задачам, прогрессу и новому опыту.", Tag = "Diary" }
                }
            },

            "Settings" => new SectionInfo
            {
                Title = "Настройки",
                Description = "Тема, язык интерфейса и базовые параметры приложения.",
                Cards = new ObservableCollection<InfoCard>
                {
                    new() { Title = "Тема", Description = "Dark mode, light mode и неоновый стиль для разработчика.", Tag = "Theme" },
                    new() { Title = "Язык", Description = "Русский / English / switching support for future updates.", Tag = "Lang" },
                    new() { Title = "Сохранение", Description = "Локальные данные, заметки и быстродействие офлайн.", Tag = "Storage" },
                    new() { Title = "Уведомления", Description = "Напоминания о задачах, прогрессе и новостях проекта.", Tag = "Alerts" }
                }
            },

            _ => new SectionInfo
            {
                Title = "Главная",
                Description = "Личное портфолио и справочник разработчика.",
                Cards = new ObservableCollection<InfoCard>
                {
                    new() { Title = "Добро пожаловать", Description = "Это хранилище идей, проектов и полезной информации.", Tag = "Start" }
                }
            }
        };
    }
}
