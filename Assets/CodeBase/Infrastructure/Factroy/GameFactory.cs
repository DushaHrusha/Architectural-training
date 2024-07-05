using Architectural_training.Assets.CodeBase.Infrastructure.AssetManagment;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameFactory:IGameFactory
    {
        
        private readonly IAssets _assetses;
        public GameFactory(IAssets assetses)
        {
            _assetses = assetses;
        }

        public GameObject CreateHero(GameObject at)
        {
            return _assetses.Instantiate(AssetPath.HeroPath, at.transform.position);
        }
        public void CreateHud()
        {
            _assetses.Instantiate(AssetPath.HudPath);
        }
    }
}