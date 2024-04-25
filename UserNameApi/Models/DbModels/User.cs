using System.Security.Cryptography;
namespace UserNameApi.Models.DbModels;

public class User : BaseModel
{
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}