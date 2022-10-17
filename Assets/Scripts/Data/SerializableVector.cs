using UnityEngine;
using System;

namespace Chernov.Test.Data
{
    /// <summary>
    /// Class defines a vector object which may be serialized
    /// </summary>
    [Serializable]
    public class SerializableVector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3 ToUnityVector()
        {
            return new Vector3(x, y, z);
        }

        public SerializableVector3(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }
}