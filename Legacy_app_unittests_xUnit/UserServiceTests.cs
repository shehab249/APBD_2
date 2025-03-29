using LegacyApp;

namespace Legacy_app_unittests_xUnit;


public class UserServiceTests
{   
    private readonly UserService _userService;
    public UserServiceTests()
    {
        _userService = new UserService();
    }
    
    [Fact]
    public void AddUser_ShouldReturnFalse_WhenNameIsInvalid()
    {
        var result = _userService.AddUser("", "Doe", "test@example.com", DateTime.Now.AddYears(-20), 1);
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ShouldReturnFalse_WhenEmailIsInvalid()
    {
        var result = _userService.AddUser("John", "Doe", "invalid-email", DateTime.Now.AddYears(-20), 1);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ShouldReturnFalse_WhenUserIsUnder18()
    {
        var result = _userService.AddUser("John", "Doe", "test@example.com", DateTime.Now.AddYears(-17), 1);
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ShouldSetNoCreditLimit_ForVeryImportantClient()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "test@example.com", DateTime.Now.AddYears(-25), 1);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ShouldDoubleCreditLimit_ForImportantClient()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "test@example.com", DateTime.Now.AddYears(-25), 1);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ShouldReturnTrue_WhenCreditLimitIsAbove500()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "test@example.com", DateTime.Now.AddYears(-25), 1);
        Assert.True(result);
    }

}