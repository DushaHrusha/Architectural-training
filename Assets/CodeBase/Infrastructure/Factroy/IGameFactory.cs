using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public interface IGameFactory : ISercies
    {
        void CreateHud();
        GameObject CreateHero(GameObject at);
        GameObject HeroGameObject {get;}
        event Action HeroCreated;
        List<ISavedProgressReader> progressReaders {get;}
        List<ISaveProgress> progressWriters {get;}
        void CleanUp();
    }
}