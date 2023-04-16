using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using exam.Models;

namespace exam;

public partial class RegWindow : Window
{
    public RegWindow()
    {
        InitializeComponent();
        CountryComboBox.SelectedIndex = 1;
    }

    public static int Reg(string lname, string fname, string login, string password)
    {
        if (String.IsNullOrWhiteSpace(lname) || String.IsNullOrWhiteSpace(fname) || String.IsNullOrWhiteSpace(login)
            || String.IsNullOrWhiteSpace(password))
        {
            return 1;
        }
        
        int countUsers = dbService.GetContext().Users.Where(u=> u.Loginuser == login).Count();
        if (countUsers != 0)
        {
            return 2;
        }

        return 0;
    }

    private void RegButton_OnClick(object? sender, RoutedEventArgs e)
    {
        // получение данных, введённых пользователем
        string lname = LastNameTextBox.Text;
        string fname = FirstNameTextBox.Text;
        string login = LoginTextBox.Text;
        string password = PasswordTextBox.Text;
        int countryIndex = CountryComboBox.SelectedIndex;
        
        int errorCode = Reg(lname, fname, login, password);
        
        // проверка заполненности полей
        if (errorCode == 1)
        {
            ErrorTextBlock.IsVisible = true;
            ErrorTextBlock.Text = "все поля должны быть заполнены";
            return;
        }
        
        // получение id страны
        int idCountry;
        if (countryIndex == 0)
            idCountry = 1;
        else
            idCountry = 2;
        
        // проверка существования пользователя
        if (errorCode == 2)
        {
            ErrorTextBlock.IsVisible = true;
            ErrorTextBlock.Text = "введите другой логин";
            return;
        }
        
        // добавление пользователя
        User user = new User();
        user.Lastname = lname;
        user.Firstname = fname;
        user.Loginuser = login;
        user.Passworsuser = password;
        user.Idcountry = idCountry;
        dbService.GetContext().Users.Add(user);
        dbService.GetContext().SaveChanges();

        ErrorTextBlock.IsVisible = false;

        UsersWindow usersWindow = new UsersWindow();
        usersWindow.Show();
        Close();
    }

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {
        AuthWindow authWindow = new AuthWindow();
        authWindow.Show();
        Close();
    }
}