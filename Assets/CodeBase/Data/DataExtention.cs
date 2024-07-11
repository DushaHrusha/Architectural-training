using UnityEngine;

namespace CodeBase.Data
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

        public static T ToDeserealized<T>(this string json) => 
            JsonUtility.FromJson<T>(json);
        
        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }
         public static Vector3 AddY(this Vector3 vector, float characterHight )
         {
            vector.y += characterHight;
            return vector;
         }
    }
}