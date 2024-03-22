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
    
    // // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail
// // AddUser_ReturnsFalseWhenYoungerThen21YearsOld
// // AddUser_ReturnsTrueWhenVeryImportantClient
// // AddUser_ReturnsTrueWhenImportantClient
// // AddUser_ReturnsTrueWhenNormalClient
// // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit
// // AddUser_ThrowsExceptionWhenUserDoesNotExist
// // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser



    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        //act
        var userService = new UserService();
        //arrenge
        var res = userService.AddUser("John",
            "smith",
            "sthpl", 
                     DateTime.Parse("10-10-2024"),
            1);
        //assert
        Assert.False(res);

    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        //act
        var userService = new UserService();
        //arrenge
        var res2 = userService.AddUser("John",
            "smith",
            "st@h.pl", 
            DateTime.Parse("10-10-2024"),
            1);
        //assert
        Assert.False(res2);

    }
    
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        //act
        var userService = new UserService();
        //arrenge
        var res2 = userService.AddUser("John",
            "smith",
            "st@h.pl", 
            DateTime.Parse("10-10-2000"),
            2);
        //assert
        Assert.True(res2);

    }
    
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        //act
        var userService = new UserService();
        //arrenge
        var res2 = userService.AddUser("J",
            "Smith",
            "st@h.pl", 
            DateTime.Parse("10-10-2000"),
            3);
        //assert
        Assert.True(res2);

    }
    
    
    
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        //act
        var userService = new UserService();
        //arrenge
        var res3 = userService.AddUser("J",
            "Kwiatkowski",
            "kwiatkowski@wp.pl", 
            DateTime.Parse("10-10-2002"),
            5);
        //assert
        Assert.True(res3);

    }
    
    
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        //act
        var userService = new UserService();
        //arrenge
        var res3 = userService.AddUser("J",
            "Kwiatkowski",
            "kwiatkowski@wp.pl", 
            DateTime.Parse("10-10-2002"),
            5);
        //assert
        Assert.True(res3);

    }
    
    
    [Fact]
    public void  AddUser_ThrowsExceptionWhenUserDoesNotExist()
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