using System;
using System.Collections.Generic;
using Chernov.Test.Abstractions;

namespace Chernov.Test.Data
{
    /// <summary>
    /// Class defines data which used for describing GameObject movement
    /// </summary>
    [Serializable]
    public class LocationRecordData : ARecordData
    {
        public IList<LocationPoint> Points { get; set; }
    }
}