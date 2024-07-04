using UnityEngine;

namespace CodeBase.Infrastructure
{
    public interface IGameFactory
    {
        void CreateHud();
        GameObject CreateHero(GameObject at);
    }
}