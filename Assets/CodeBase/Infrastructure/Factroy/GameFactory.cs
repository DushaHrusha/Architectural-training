using System.Collections.Generic;
using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Services.PersistentProgress;                                                                          
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameFactory: IGameFactory
    {   
        private readonly IAssets _assetses;
        public List<ISavedProgressReader> progressReaders {get;} = new List<ISavedProgressReader>();
        public List<ISaveProgress> progressWriters {get;} = new List<ISaveProgress>();

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

        public void CleanUp()
        {
            progressReaders.Clear();
            progressWriters.Clear();
        }
    }
}