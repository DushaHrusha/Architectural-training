using System;
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

        public void CreateHud() =>
            InstantiateRegistered(AssetPath.HudPath);

        public GameObject CreateHero(GameObject at) =>
            InstantiateRegistered(AssetPath.HeroPath, at.transform.position);

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assetses.Instantiate(prefabPath, at);
            RegisterProgressWatcher(gameObject);
            return gameObject;
        }

         private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assetses.Instantiate(prefabPath);
            RegisterProgressWatcher(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatcher(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISaveProgress progressWriter)
            {
                progressWriters.Add(progressWriter);
            }

            progressReaders.Add(progressReader);
        }

        public void CleanUp()
        {
            progressReaders.Clear();
            progressWriters.Clear();
        }
    }
}