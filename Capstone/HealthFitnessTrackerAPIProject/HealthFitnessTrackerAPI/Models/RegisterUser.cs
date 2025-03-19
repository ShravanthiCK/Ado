using System.ComponentModel.DataAnnotations;

public class RegisterUser
{
    [Required]
    public string Name { get; set; }  // Ensure Name is included

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, MinLength(6)]
    public string Password { get; set; }
}
