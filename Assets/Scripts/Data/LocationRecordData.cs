using System;
using System.Collections.Generic;
using Chernov.Test.Abstractions;
using Chernov.Test.Data;
using UnityEngine;

namespace Chernov.Test.Data
{
    [Serializable]
    public class LocationRecordData : ARecordData
    {
        public IList<LocationPoint> Points { get; set; }
    }
}