using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PossitionOnLevel
    {
        public Vector3Data Possition;
        public string Level;
        public PossitionOnLevel(string initialLevel)
        {
           Level = initialLevel;
        }

        public PossitionOnLevel(string level, Vector3Data possition)
        {
            Possition = possition;
            Level = level;
        }

    }
}