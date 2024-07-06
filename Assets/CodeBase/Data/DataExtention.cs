using UnityEngine;

namespace Architectural_training.Assets.CodeBase.Data
{
    public static class DataExtention
    {
        public static Vector3Data AsVectorData(this Vector3 vector)
        {
            return new Vector3Data(vector.x, vector.y, vector.z);   
        }
        public static Vector3 AsUnityVector(this Vector3Data vector )
        {
            return new Vector3(vector.X,vector.Y,vector.Z);
        }
    }
}