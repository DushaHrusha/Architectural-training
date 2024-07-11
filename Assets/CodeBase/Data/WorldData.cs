using System;

namespace CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        public PossitionOnLevel PossitionOnLevel;
        public WorldData(string initialLevel)
        {
            PossitionOnLevel = new PossitionOnLevel(initialLevel);
        }
    }
}