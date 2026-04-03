namespace console_hero;

public interface IProfession
{
    string Name { get; }
    IReadOnlyDictionary<StatType, int> InitialStats { get; }
}