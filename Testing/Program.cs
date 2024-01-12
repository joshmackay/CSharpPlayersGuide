
GameObject obj = new Asteroid();

//Asteroid? asteroid = obj as Asteroid;

if (obj is Asteroid asteroid)
{
    Console.WriteLine("in");

}



public class GameObject
{
    public int X { get; set; }
    public int Y { get; set; }

    public GameObject()
    {
    }
}

public class Asteroid : GameObject
{
    public int Size { get; set; }

    public Asteroid()
    {

    }
}