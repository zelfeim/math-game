namespace Game.Misc
{
    public enum Lane
    {
        Left,
        Middle,
        Right
    }
    
    public static class LaneExtensions
    {
        public static float GetXCoordinate(this Lane lane)
        {
            return lane switch
            {
                Lane.Left => -5.0f,
                Lane.Middle => 0.0f,
                Lane.Right => 5.0f,
                _ => 0.0f
            };
        }
    }
}