
recursionLoop(10);

void recursionLoop(int num)
{
    if (num == 0) return;
    Console.WriteLine(num);
    recursionLoop(num - 1);
}