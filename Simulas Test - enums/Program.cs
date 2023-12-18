using SimulasTestEnums;
using System.ComponentModel.Design;

ChestState chestState = new ChestState();
chestState = ChestState.Locked;



while (true)
{
    Console.Write($"The chest is {chestState.ToString().ToLower()}. What do you want to do? ");
    var action = Console.ReadLine().ToLower();

    if (chestState == ChestState.Locked && action == "unlock") chestState = ChestState.Closed;
    else if (chestState == ChestState.Closed && action == "open") chestState = ChestState.Open;
    else if (chestState == ChestState.Open && action == "close") chestState = ChestState.Closed;
    else if (chestState == ChestState.Closed && action == "lock") chestState = ChestState.Locked;


}