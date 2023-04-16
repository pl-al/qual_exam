using Microsoft.CodeAnalysis;

namespace AuthTest;
using exam;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void AuthTest()
    {
        string login;
        string password;
        
        // Успешная авторизация
        login = "123";
        password = "123";
        
        Assert.AreEqual(0, AuthWindow.Auth(login, password));

        // Пустые поля
        login = "";
        password = "";
        
        Assert.AreEqual(1, AuthWindow.Auth(login, password));

        // Пользователя не существует
        login = "Филипп";
        password = "Крикоров";
        
        Assert.AreEqual(2, AuthWindow.Auth(login, password));
    }

    [TestMethod]
    public void RegTest()
    {
        string lname;
        string fname;
        string login;
        string password;
        
        // Успешная регистрация
        lname = "Плотникова";
        fname = "Алёна";
        login = "gr692_pav";
        password = "692";
        
        Assert.AreEqual(0, RegWindow.Reg(lname, fname, login, password));

        // Пустые поля
        lname = "";
        fname = "";
        login = "";
        password = "";
        
        Assert.AreEqual(1, RegWindow.Reg(lname, fname, login, password));

        // Логин уже занят
        lname = "123";
        fname = "123";
        login = "123";
        password = "123";
        
        Assert.AreEqual(2, RegWindow.Reg(lname, fname, login, password));
    }
}