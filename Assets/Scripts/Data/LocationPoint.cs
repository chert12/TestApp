using Chernov.Test.Views.Data;

namespace Chernov.Test.Data
{
    public class LocationPoint
    {
        public long Id { get; set; }
        public SerializableVector3 Position { get; set; }
        public SerializableVector3 Rotation { get; set; }
    }
}