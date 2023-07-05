
namespace BurberDinner.Domain.entities;


public class User {

  public Guid Id {get; private set; } = Guid.NewGuid();

  public String FirstName { get; private set; } = null!;
  public String LastName { get; private set; } = null!;
  public String Email { get; private set; } = null!;
  public String Password { get; private set; } = null!;

  public User(String FirstName, String LastName, String Email, String Password) {

    this.Id = new Guid();
    this.FirstName = FirstName;
    this.LastName = LastName;
    this.Email = Email;
    this.Password = Password;
  }
  
}