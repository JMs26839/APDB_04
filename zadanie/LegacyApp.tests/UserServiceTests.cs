namespace LegacyApp.tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        //Arange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            null, "Smith", "smith@page.com", DateTime.Parse("2000-01-01"), 1);

        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        //Arange
        var userService = new UserService();

        //Act
        Action action =()=> userService.AddUser(
            "Joe",
            "Smith",
            "smith@page.com",
            DateTime.Parse("2000-01-01"), 
            100);

        //Assert
        Assert.Throws<ArgumentException>(action);
    }
}