using System.Net.Http.Headers;
using ThePasswordValidator;

while (true)
{
    Console.WriteLine("Please enter a password: ");
    string password = Console.ReadLine();
    if (password == null) break;

    if (PasswordValidator.Validate(password))
    {
        Console.WriteLine("Password is valid");
    }
    else Console.WriteLine("Password is invalid");
}