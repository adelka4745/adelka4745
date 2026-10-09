using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace adelka4745Toolkit;

public sealed class MainForm : Form
{
    private readonly Dictionary<string, SectionData> _sections = new();
    private readonly FlowLayoutPanel _contentPanel = new();
    private readonly Label _titleLabel = new();
    private readonly Label _subtitleLabel = new();

    public MainForm()
    {
        PrepareSections();
        InitializeForm();
        LoadSection("Home");
    }

    private void PrepareSections()
    {
        _sections["Home"] = new SectionData(
            "Главная",
            "Личное портфолио, проекты, идеи и помощник разработчика",
            new List<TileItem>
            {
                new("adelka4745", "Личное портфолио и идеи для будущих продуктов.", "Бренд"),
                new("ShellOS", "Концепция собственной OS и архитектуры.", "OS"),
                new("Unity & VR", "Игры, VR и эксперименты.", "VR"),
                new("Мои проекты", "Пакет идей с планами и статусом.", "Проекты"),
                new("Помощь", "Шпаргалки и шаблоны для разработки.", "Dev")
            });

        _sections["Projects"] = new SectionData(
            "Проекты",
            "Список активных, планируемых и завершённых направлений",
            new List<TileItem>
            {
                new("ShellOS", "Разработка собственной ОС и архитектуры ядра.", "В разработке"),
                new("Unity VR Hub", "VR-проекты, механики и эксперименты.", "VR"),
                new("Toolkit", "Desktop-приложение для портфолио, заметок и справки.", "Desktop"),
                new("Code Library", "Шаблоны, заметки, примеры и решения.", "Patterns"),
                new("Идеи", "Планы и концепции будущих продуктов.", "Future")
            });

        _sections["Categories"] = new SectionData(
            "Категории",
            "Разделение контента по технологиям и идеям",
            new List<TileItem>
            {
                new("Программирование", "C#, C++, Python, JS, TS, SQL и др.", "Code"),
                new("Игры", "Игровая логика, механики и геймдизайн.", "Games"),
                new("VR / AR", "Виртуальная реальность и интерфейсы.", "XR"),
                new("ОС и ядро", "Системное программирование и архитектура.", "Kernel"),
                new("Идеи", "Концепции и долгосрочные эксперименты.", "Brain")
            });

        _sections["Languages"] = new SectionData(
            "Языки",
            "Справка и шпаргалки по языкам программирования",
            new List<TileItem>
            {
                new("C#", "Универсальный язык для .NET и приложений.", "Core"),
                new("C++", "Мощный язык системного программирования.", "System"),
                new("Python", "Автоматизация, скрипты и AI.", "Script"),
                new("JavaScript", "Frontend, backend и веб.", "Web"),
                new("TypeScript", "Типизированный JavaScript.", "Typed"),
                new("Rust", "Безопасность и производительность.", "Safe"),
                new("Go", "Быстрые сервисы и CLI.", "Backend")
            });

        _sections["Help"] = new SectionData(
            "Помощь",
            "Шаблоны, заметки и справочные материалы по разработке",
            new List<TileItem>
            {
                new("Шаблоны", "Каркасы для приложений и сервисов.", "Templates"),
                new("Git", "Ветки, коммиты, merge и pull request.", "Git"),
                new("C# / .NET", "Классы, LINQ, async/await.", "C#"),
                new("Python", "Функции, структуры и работа с файлами.", "Python"),
                new("SQL", "SELECT, JOIN, GROUP BY и индексы.", "SQL"),
                new("Архитектура", "SOLID и паттерны проектирования.", "Design")
            });

        _sections["Notes"] = new SectionData(
            "Заметки",
            "Личные мысли, идеи и записи",
            new List<TileItem>
            {
                new("Идея 1", "Сделать справочник по языкам и шаблонам.", "Idea"),
                new("Идея 2", "Хранить заметки и решения локально.", "Tool"),
                new("Третья мысль", "Поддерживать структуру в коде.", "Plan"),
                new("Дневник", "Подводить итоги задач и прогресса.", "Diary")
            });

        _sections["Settings"] = new SectionData(
            "Настройки",
            "Параметры темы и интерфейса",
            new List<TileItem>
            {
                new("Тема", "Dark mode и стиль интерфейса.", "Theme"),
                new("Язык", "Русский, English и локальные настройки.", "Lang"),
                new("Сохранение", "Локальные заметки и настройки.", "Storage"),
                new("Оповещения", "Напоминания и задачи.", "Alerts")
            });
    }

    private void InitializeForm()
    {
        Text = "adelka4745 Toolkit";
        Size = new Size(1280, 760);
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(980, 620);
        BackColor = ColorTranslator.FromHtml("#0B0B12");
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var sidebar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 260,
            BackColor = ColorTranslator.FromHtml("#121A2A"),
            BorderStyle = BorderStyle.None
        };

        var brand = new Label
        {
            Text = "adelka4745",
            Font = new Font("Segoe UI", 28, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml("#F3F7FF"),
            AutoSize = true,
            Location = new Point(20, 24)
        };

        var accent = new Label
        {
            Text = "PORTFOLIO / HELP",
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml("#67D2FF"),
            AutoSize = true,
            Location = new Point(22, 80)
        };

        var navPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            AutoScroll = false,
            WrapContents = false,
            Dock = DockStyle.Fill,
            Padding = new Padding(18, 120, 18, 18)
        };

        string[] menuItems = ["Home", "Projects", "Categories", "Languages", "Help", "Notes", "Settings"];
        string[] menuText = ["Главная", "Проекты", "Категории", "Языки", "Помощь", "Заметки", "Настройки"];

        for (int i = 0; i < menuItems.Length; i++)
        {
            var button = new Button
            {
                Text = menuText[i],
                Tag = menuItems[i],
                Size = new Size(200, 42),
                BackColor = ColorTranslator.FromHtml("#1C2333"),
                ForeColor = ColorTranslator.FromHtml("#EAF2FF"),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Margin = new Padding(0, 0, 0, 10),
                TextAlign = ContentAlignment.MiddleCenter,
                FlatAppearance = { BorderColor = ColorTranslator.FromHtml("#2B364A"), BorderSize = 1 }
            };

            button.Click += OnNavClick;
            navPanel.Controls.Add(button);
        }

        var content = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(24, 24, 24, 18)
        };

        _titleLabel.Font = new Font("Segoe UI", 32, FontStyle.Bold);
        _titleLabel.ForeColor = ColorTranslator.FromHtml("#F7FAFF");
        _titleLabel.AutoSize = true;
        _titleLabel.Location = new Point(0, 0);

        _subtitleLabel.Font = new Font("Segoe UI", 15, FontStyle.Regular);
        _subtitleLabel.ForeColor = ColorTranslator.FromHtml("#A7B8D3");
        _subtitleLabel.AutoSize = true;
        _subtitleLabel.Location = new Point(0, 52);

        _contentPanel.Dock = DockStyle.Fill;
        _contentPanel.AutoScroll = true;
        _contentPanel.BackColor = ColorTranslator.FromHtml("#0B0B12");
        _contentPanel.Padding = new Padding(0, 92, 0, 0);
        _contentPanel.FlowDirection = FlowDirection.LeftToRight;
        _contentPanel.WrapContents = true;

        content.Controls.Add(_contentPanel);
        content.Controls.Add(_subtitleLabel);
        content.Controls.Add(_titleLabel);

        sidebar.Controls.Add(brand);
        sidebar.Controls.Add(accent);
        sidebar.Controls.Add(navPanel);

        Controls.Add(sidebar);
        Controls.Add(content);
    }

    private void OnNavClick(object? sender, EventArgs e)
    {
        if (sender is Button button && button.Tag is string tag)
        {
            LoadSection(tag);
        }
    }

    private void LoadSection(string sectionName)
    {
        if (!_sections.TryGetValue(sectionName, out var section))
        {
            section = _sections["Home"];
        }

        _titleLabel.Text = section.Title;
        _subtitleLabel.Text = section.Description;

        _contentPanel.Controls.Clear();

        foreach (var item in section.Items)
        {
            var panel = new Panel
            {
                Width = 240,
                Height = 180,
                Margin = new Padding(0, 0, 18, 18),
                BackColor = ColorTranslator.FromHtml("#1C2333"),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(16)
            };

            var title = new Label
            {
                Text = item.Title,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#F5F7FF"),
                AutoSize = false,
                Width = 200,
                Height = 28,
                Location = new Point(16, 16)
            };

            var description = new Label
            {
                Text = item.Description,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Regular),
                ForeColor = ColorTranslator.FromHtml("#AAB8D3"),
                AutoSize = false,
                Width = 200,
                Height = 74,
                Location = new Point(16, 54),
                MaximumSize = new Size(200, 74)
            };

            var tagPanel = new Panel
            {
                Width = 88,
                Height = 28,
                BackColor = ColorTranslator.FromHtml("#67D2FF"),
                Location = new Point(16, 137)
            };

            var tagLabel = new Label
            {
                Text = item.Tag,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#111419"),
                AutoSize = true,
                Location = new Point(10, 6),
                ForeColor = ColorTranslator.FromHtml("#0C1016")
            };

            tagPanel.Controls.Add(tagLabel);
            panel.Controls.Add(title);
            panel.Controls.Add(description);
            panel.Controls.Add(tagPanel);
            _contentPanel.Controls.Add(panel);
        }
    }
}

public sealed record TileItem(string Title, string Description, string Tag);
public sealed record SectionData(string Title, string Description, List<TileItem> Items);
