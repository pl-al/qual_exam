using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using exam.Models;
using Microsoft.EntityFrameworkCore;

namespace exam;

public partial class UsersWindow : Window
{
    public UsersWindow()
    {
        InitializeComponent();
        UsersDataGrid.Items = dbService.GetContext().Users.Include(c => c.IdcountryNavigation).ToList();
    }
}