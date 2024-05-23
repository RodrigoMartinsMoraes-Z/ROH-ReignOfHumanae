﻿using Moq;

using ROH.Domain.Accounts;
using ROH.Interfaces.Services.Account;
using ROH.Interfaces.Services.ExceptionService;
using ROH.Services.Account;
using ROH.StandardModels.Account;
using ROH.StandardModels.Response;
using ROH.Validations.Account;

using System.Net;

namespace ROH.Test.Account;
public class LoginServiceTest
{
    [Fact]
    public async Task Login_WithEmptyCredentials_ShouldReturnError()
    {
        // Arrange
        LoginModelValidator validator = new();

        Mock<IExceptionHandler> mockExceptionHandler = new();
        Mock<IUserService> mockUserService = new();

        LoginService service = new(mockExceptionHandler.Object, validator, mockUserService.Object);

        // Act
        DefaultResponse result = await service.Login(new LoginModel());

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, result.HttpStatus);
        Assert.False(string.IsNullOrWhiteSpace(result.Message));
    }

    [Fact]
    public async Task Login_WithNotFoundCredentials_ShouldReturnNotFound()
    {
        // Arrange
        LoginModelValidator validator = new();

        Mock<IExceptionHandler> mockExceptionHandler = new();

        Mock<IUserService> mockUserService = new();
        _ = mockUserService.Setup(x => x.FindUserByEmail(It.IsAny<string>())).ReturnsAsync(() => null);
        _ = mockUserService.Setup(x => x.FindUserByUserName(It.IsAny<string>())).ReturnsAsync(() => null);

        LoginService service = new(mockExceptionHandler.Object, validator, mockUserService.Object);

        LoginModel loginModel = new()
        {
            Login = "test",
            Password = "test"
        };

        // Act
        DefaultResponse result = await service.Login(loginModel);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, result.HttpStatus);
        Assert.False(string.IsNullOrWhiteSpace(result.Message));
    }

    [Fact]
    public async Task Login_WithInvalidPassword_ShouldReturnError()
    {
        // Arrange
        User user = new(1, 1, Guid.NewGuid(), "test", "test");
        user.SetPassword("test");

        LoginModel loginModel = new()
        {
            Login = "test",
            Password = "testwrong"
        };

        LoginModelValidator validator = new();

        Mock<IExceptionHandler> mockExceptionHandler = new();

        Mock<IUserService> mockUserService = new();
        _ = mockUserService.Setup(x => x.FindUserByEmail(It.IsAny<string>())).ReturnsAsync(user);
        _ = mockUserService.Setup(x => x.FindUserByUserName(It.IsAny<string>())).ReturnsAsync(user);

        LoginService service = new(mockExceptionHandler.Object, validator, mockUserService.Object);

        DefaultResponse expected = new(httpStatus: HttpStatusCode.Unauthorized, message: "Invalid password!");

        // Act
        DefaultResponse result = await service.Login(loginModel);

        // Assert
        Assert.Equivalent(expected, result);
    }

    [Fact]
    public async Task Login_WithValidCredentials_ShouldReturnUserModel()
    {
        // Arrange
        string pass = "test";
        User user = new(1, 1, Guid.NewGuid(), "test", "test");
        user.SetPassword(pass);

        LoginModel loginModel = new()
        {
            Login = "test",
            Password = pass
        };

        LoginModelValidator validator = new();

        Mock<IExceptionHandler> mockExceptionHandler = new();

        Mock<IUserService> mockUserService = new();
        _ = mockUserService.Setup(x => x.FindUserByEmail(It.IsAny<string>())).ReturnsAsync(user);
        _ = mockUserService.Setup(x => x.FindUserByUserName(It.IsAny<string>())).ReturnsAsync(user);

        LoginService service = new(mockExceptionHandler.Object, validator, mockUserService.Object);

        DefaultResponse expected = new(objectResponse: new UserModel() { Email = user.Email, UserName = user.UserName, Guid = user.Guid });

        // Act
        DefaultResponse result = await service.Login(loginModel);

        // Assert
        Assert.Equivalent(expected, result);
    }
}