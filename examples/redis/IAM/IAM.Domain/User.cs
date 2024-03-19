namespace IAM.Domain;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Phone { get; private set; }
    public string Password { get; private set; }
    public bool IsVerified { get; private set; }
    
    public static User Create(string firstName, string lastName, string phone, string password)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            Password = password,
            IsVerified = false
        };
    }
    
    public void Verify()
    {
        IsVerified = true;
    }
}