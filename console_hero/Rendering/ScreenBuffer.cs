namespace console_hero;

public class ScreenBuffer
{
    private string[] _previousFrame;
    private int _height;

    public ScreenBuffer(int height)
    {
        _height = height;
        _previousFrame = new string[height];
        Array.Fill(_previousFrame, "");
    }
    
    public void Draw(string[] newFrame)
    {
        for (int y = 0; y < _height; y++)
        {
            if (_previousFrame[y] != newFrame[y])
            {
                Console.SetCursorPosition(0, y);
            
                string lineToDraw = newFrame[y];
            
                int currentVisibleLen = lineToDraw.GetVisibleLength();
                int previousVisibleLen = _previousFrame[y].GetVisibleLength();
            
                if (currentVisibleLen < previousVisibleLen)
                {
                    lineToDraw = lineToDraw.PadRightVisible(previousVisibleLen + 2); 
                }
            
                Console.Write(lineToDraw);
            
                _previousFrame[y] = newFrame[y]; 
            }
        }
    }
}