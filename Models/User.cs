namespace Mod5Act1UserManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; } = 0;

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Department is required")]
    [RegularExpression("^(HR|IT)$", ErrorMessage = "Department must be either 'HR' or 'IT'")]
    public string Department { get; set; }
}
