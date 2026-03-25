namespace console_hero;

public interface IDungeonStarter
{
    IDungeonBuilder EmptyDungeon(int? w = null, int? h = null);
    IDungeonBuilder FullDungeon(int? w = null, int? h = null);
}