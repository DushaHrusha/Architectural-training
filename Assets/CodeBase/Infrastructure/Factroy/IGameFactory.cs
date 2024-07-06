using Architectural_training.Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public interface IGameFactory : ISercies
    {
        void CreateHud();
        GameObject CreateHero(GameObject at);
    }
}