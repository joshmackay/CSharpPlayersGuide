var user1Num = -1;
var user2Num = -1;
do
{
    user1Num = AskForNumber("Pilot, enter a number between 0 and 100: ");
} while (user1Num < 0 && user1Num > 100);

Console.Clear();

Console.WriteLine("Hunter, guess a number between between 0 and 100.");

while (true)
{
    user2Num = AskForNumberInRange("What is your next guess? ", 0, 100);

    if (user2Num < user1Num) Console.WriteLine($"{user2Num} is too low.");
    else if (user2Num > user1Num) Console.WriteLine($"{user2Num} is too high.");
    else break;
}
Console.WriteLine("You guessed the number!!!");
Console.WriteLine("Game Over.");

int AskForNumber(string text)
{
    var number = -1;
    while (number < 0 || number > 100)
    {
        Console.Write(text);
        number = Convert.ToInt32(Console.ReadLine());
    }
    return number;
}

int AskForNumberInRange(string text, int min, int max)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());


}