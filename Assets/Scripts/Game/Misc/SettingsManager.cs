namespace Game.Misc
{
    public class SettingsManager
    {
        public static Notation CurrentNotation { get; set; } = Notation.Postfix;
    }

    public enum Notation
    {
        Infix,
        Postfix
    }
}