using Xunit;
using Api.Password;

public class PasswordHelperTests
{
    [Fact]
    public void ValidPassword()
    {
        string password = "ValidPassword123$";
        string? err;
        Assert.True(PasswordHelper.IsValidPassword(password,out err));
        Assert.Null(err);
    }

    [Fact]
    public void InvalidPassword_Empty()
    {
        string password = "";
        string? err;
        Assert.False(PasswordHelper.IsValidPassword(password,out err));
        Assert.Equal("Password cannot be empty.",err);
    }

    [Fact]
    public void InvalidPassword_Whitespace()
    {
        string password = " ";
        string? err;
        Assert.False(PasswordHelper.IsValidPassword(password,out err));
        Assert.Equal("Password cannot be empty.",err);
    }

    [Fact]
    public void InvalidPassword_TooShort()
    {
        string password = "In123$";
        string? err;
        Assert.False(PasswordHelper.IsValidPassword(password,out err));
        Assert.Equal("Password must be at least 8 characters long.",err);
    }

    [Fact]
    public void InvalidPassword_NoCaps()
    {
        string password = "validpassword123$";
        string? err;
        Assert.False(PasswordHelper.IsValidPassword(password,out err));
        Assert.Equal("Password must contain at least one uppercase letter.",err);
    }

    [Fact]
    public void InvalidPassword_NoLowers()
    {
        string password = "VALIDPASSWORD123$";
        string? err;
        Assert.False(PasswordHelper.IsValidPassword(password,out err));
        Assert.Equal("Password must contain at least one lowercase letter.",err);
    }

    [Fact]
    public void InvalidPassword_NoNums()
    {
        string password = "ValidPassword$";
        string? err;
        Assert.False(PasswordHelper.IsValidPassword(password,out err));
        Assert.Equal("Password must contain at least one digit.", err);
    }

    [Fact]
    public void InvalidPassword_NoSpecials()
    {
        string password = "ValidPassword123";
        string? err;
        Assert.False(PasswordHelper.IsValidPassword(password,out err));
        Assert.Equal("Password must contain at least one special character.", err);
    }

    [Fact] 
    public void CorrectLoginReturnsTrue()
    {
        string password = "Hello World!";
        var (hash, salt) = PasswordHelper.CreatePasswordHash(password);
        Assert.True(PasswordHelper.VerifyPasswordHash(password, hash, salt));
    }

    [Fact]
    public void IncorrectPasswordReturnsFalse()
    {
        string password = "Hello World!";
        var (hash, salt) = PasswordHelper.CreatePasswordHash(password);
        Assert.False(PasswordHelper.VerifyPasswordHash("Goodbye World!", hash, salt));
    }

    [Fact]
    public void IncorrectSaltReturnsFalse()
    {
        string password = "Hello World!";
        var (hash, salt) = PasswordHelper.CreatePasswordHash(password);
        var (hash2, salt2) = PasswordHelper.CreatePasswordHash(password);
        Assert.False(PasswordHelper.VerifyPasswordHash(password, hash, salt2));
        Assert.False(PasswordHelper.VerifyPasswordHash(password, hash2, salt));
    }

}
