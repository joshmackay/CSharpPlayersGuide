using TheOldRobot;


Robot robot = new Robot();

for (int i = 0; i < robot.Commands.Count(); i++)
{
    string? input = Console.ReadLine();
    robot.Commands[i] = input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "North" => new NorthCommand(),
        "South" => new SouthCommand(),
        "East" => new EastCommand(),
        "West" => new WestCommand(),
    };
}

Console.WriteLine();
robot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.Y += 1;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.Y -= 1;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.X += 1;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.X -= 1;
    }
}