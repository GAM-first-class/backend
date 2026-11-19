namespace ModShop.Entities;

public class User
{

    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime CreateDate{ get; set; }
    public DateTime UpdateDate{ get; set; }
    


    public static User Create(string userName, string firstName, string lastName, string email, string phoneNumber, string password)
    {
        return new User
        {
            Id = Guid.CreateVersion7(),
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Password = password,
            CreateDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow
        };
    }
    public void Update(string userName, string firstName, string lastName, string email, string phoneNumber, string password)
    {

        Id = this.Id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        UpdateDate = DateTime.UtcNow;

    }
    public void CompleteRegistration(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UpdateDate = DateTime.UtcNow;
    }
}
