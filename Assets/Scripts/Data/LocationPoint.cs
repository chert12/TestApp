namespace Chernov.Test.Data
{
    /// <summary>
    /// Class defines data which used for describing GameObject movement at a moment of the time
    /// </summary>
    public class LocationPoint
    {
        public long Id { get; set; }
        public SerializableVector3 Position { get; set; }
        public SerializableVector3 Rotation { get; set; }
    }
}