using TheLockedDoor;

Console.WriteLine("Please privide a new passcode");
var passcode = Convert.ToInt32(Console.ReadLine());
Door door = new Door(passcode);

while (true)
{
    Console.WriteLine($"The door is currently {door.State}.  What do you want to do?");
    Console.WriteLine($"1. Open\n2. Close\n3. Lock\n4. Unlock\n5. Change Passcode");
    var choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            door.OpenDoor();
            break;
        case 2:
            door.CloseDoor();
            break;
        case 3:
            door.LockDoor();
            break;
        case 4:
            int code = GetInt("What is the passcode?");
            door.UnlockDoor(code);
            break;
        case 5:
            var currentCode = GetInt("What is the current passcode?");
            var newCode = GetInt("What is the new passcode?");
            door.ChangePasscode(currentCode, newCode);
            break;
    }
}

int GetInt(string text)
{
    Console.WriteLine(text + " ");
    return Convert.ToInt32(Console.ReadLine());
}