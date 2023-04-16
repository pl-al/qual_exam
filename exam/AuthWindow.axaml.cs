using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using exam.Models;

namespace exam;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
    }

    public static int Auth(string login, string password)
    {
        if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
        {
            return 1;
        }
        
        int countUsers = dbService.GetContext().Users.Where(u => u.Loginuser == login && u.Passworsuser == password).Count();
        if (countUsers == 0)
        {
            return 2;
        }

        return 0;
    }
    
    private void AuthButton_OnClick(object? sender, RoutedEventArgs e)
    {
        int errorCode = Auth(LoginTextBox.Text, PasswordTextBox.Text);

        // проверка заполненности полей
        if (errorCode == 1)
        {
            ErrorTextBlock.IsVisible = true;
            ErrorTextBlock.Text = "все поля должны быть заполнены";
            return;
        }
        
        // проверка существования пользователя
        if (errorCode == 2)
        {
            ErrorTextBlock.IsVisible = true;
            ErrorTextBlock.Text = "пользователь не найден";
            return;
        }

        UsersWindow usersWindow = new UsersWindow();
        usersWindow.Show();
        this.Close();
    }

    private void RegButton_OnClick(object? sender, RoutedEventArgs e)
    {
        RegWindow regWindow = new RegWindow();
        regWindow.Show();
        Close();
    }
}