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
        List<ISavedProgressReader> progressReaders {get;}
        List<ISaveProgress> progressWriters {get;}
        void CleanUp();
    }
}