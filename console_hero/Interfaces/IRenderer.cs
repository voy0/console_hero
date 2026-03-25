namespace console_hero;

public interface IRenderer
{
    void Render();
}

public interface IModuleRenderer : IRenderer
{
    int Height { get; set; }
    string GetLine(int y);
}