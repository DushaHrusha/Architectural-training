using Architectural_training.Assets.CodeBase.Infrastructure.AssetManagment;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameFactory:IGameFactory
    {
        
        private readonly IAssetProvder _assets;
        public GameFactory(IAssetProvder assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at)
        {
            return _assets.Instantiate(AssetPath.HeroPath, at.transform.position);
        }
        public void CreateHud()
        {
            _assets.Instantiate(AssetPath.HudPath);
        }
    }
}