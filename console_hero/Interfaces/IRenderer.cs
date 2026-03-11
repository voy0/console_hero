namespace console_hero;

public interface IRenderer
{
    void Render();
}

public interface IRenderable : IRenderer
{
    string GetLine(int y);
}