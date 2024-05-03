
SetUp();

void SetUp()
{
    Coordinate a = new Coordinate(0, 1);
    Coordinate b = new Coordinate(1, 1);
    Coordinate c = new Coordinate(1, 2);
    Coordinate d = new Coordinate(4, 6);

    Console.WriteLine(a.Row); //true
    Console.WriteLine(IsAdjacent(a, b)); //false
    Console.WriteLine(IsAdjacent(b, c)); //false
    Console.WriteLine(IsAdjacent(c, d)); //true
    Console.WriteLine(IsAdjacent(a, d)); //false
    Console.WriteLine(IsAdjacent(a, a)); //false

    Console.ReadLine();

}

bool IsAdjacent(Coordinate X, Coordinate Y)
{

    int rowChange = Math.Abs(X.Row - Y.Row);
    int columnChange = Math.Abs(X.Column - Y.Column);

    if (Math.Abs(rowChange) == 1 && Math.Abs(columnChange) == 0) return true;
    if (Math.Abs(rowChange) == 0 && Math.Abs(columnChange) == 1) return true;

    return false;
}

struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }
}