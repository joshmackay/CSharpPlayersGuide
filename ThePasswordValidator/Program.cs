using System.Net.Http.Headers;
using ThePasswordValidator;

/*while (true)
{
    Console.WriteLine("Please enter a password: ");
    string password = Console.ReadLine();
    if (password == null) break;

    if (PasswordValidator.Validate(password))
    {
        Console.WriteLine("Password is valid");
    }
    else Console.WriteLine("Password is invalid");
}*/

object a = new object();
object b = new Point(2, 4);

Console.WriteLine(a.GetHashCode());
Console.WriteLine(b.GetHashCode());

Console.WriteLine(typeof(Point) == a.GetType());

public class Point
{
    public float X { get; }
    public float Y { get; }
    public Point(float x, float y)
    {
        X = x; Y = y;
    }
}