using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace calendar;

public partial class News : Window
{
    public List<NewsItems> newsItems = new List<NewsItems>();
    public News()
    {
        InitializeComponent();
        DataContext = this;
        LoadNews();
    }

    public async void LoadNews()
    {
        string jsonNews = await File.ReadAllTextAsync("news_response.json");

        var inputNews = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        List<NewsItems> testNews = JsonSerializer.Deserialize<List<NewsItems>>(jsonNews, inputNews);
        if (testNews == null)
        {
            newsItems = new List<NewsItems>();
        }
        else
        {
            newsItems = testNews;
        }

        newsControls.ItemsSource = newsItems;



    }

    public void UpdateNews()
    {
        LoadNews();
    }

    public void Update_Click(object? sender, RoutedEventArgs e)
    {
        UpdateNews();
    }

    public void exitClick(object? sender, RoutedEventArgs e)
    {
        MainWindow main = new MainWindow();
        main.Show();
        Close();
    }
}