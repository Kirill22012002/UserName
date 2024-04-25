using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using UserNameApi.Models.DbModels;
using UserNameApi.Models.Models;

namespace UserNameApi.Services;

public class UserService
{
    private readonly WorkoutDbContext _dbContext;

    public UserService(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool IsUsernameTaken(string userName)
    {
        return _dbContext.Users.Any(u => u.UserName == userName);
    }

    public void Register(RegisterModel model)
    {
        var salt = GenerateSalt();
        var user = new User
        {
            UserName = model.UserName,
            PasswordHash = GenerateHash(model.Password, salt),
            PasswordSalt = salt
        };

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public User Authenticate(string userName, string password)
    {
        var user = _dbContext.Users.SingleOrDefault(x => x.UserName == userName);

        var isCorrectlyPass = VerifyPassword(password, user.PasswordSalt, user.PasswordHash);

        if (isCorrectlyPass)
        {
            return user;
        }

        return null;
    }

    public User GetById(long id)
    {
        return _dbContext.Users.SingleOrDefault(x => x.Id == id);
    }

    public bool VerifyPassword(string password, byte[] passwordSalt, byte[] passwordHash)
    {
        byte[] testHash = GenerateHash(password, passwordSalt);
        return CompareByteArrays(testHash, passwordHash);
    }

    private static byte[] GenerateHash(string password, byte[] salt)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + salt.Length];

            for (int i = 0; i < passwordBytes.Length; i++)
            {
                passwordWithSaltBytes[i] = passwordBytes[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                passwordWithSaltBytes[passwordBytes.Length + i] = salt[i];
            }

            return sha256.ComputeHash(passwordWithSaltBytes);
        }
    }

    private static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private static bool CompareByteArrays(byte[] array1, byte[] array2)
    {
        if (array1 == null || array2 == null || array1.Length != array2.Length)
        {
            return false;
        }
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
            {
                return false;
            }
        }
        return true;
    }
}
