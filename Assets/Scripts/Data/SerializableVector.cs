using UnityEngine;

namespace Chernov.Test.Views.Data
{
    [System.Serializable]
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