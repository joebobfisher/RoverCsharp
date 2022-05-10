namespace RoverCsharp;

public class Rover
{
    private int _position;
    private const int SizeOfArea = 10;
    
    public string Execute(string commands)
    {
        foreach (var unused in commands.Where(command => command == 'M'))
        {
            _position++;
            _position %= SizeOfArea;
        }

        return "0:" + _position + ":N";
    }
}