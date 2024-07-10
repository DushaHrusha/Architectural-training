using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class SaveLoadServies : ISaveLoadServies
    {
        private const string ProgressKey = "Progress";
        private readonly IPersistenProgressServies progressServies;
        private readonly IGameFactory _gameFactory;

        public SaveLoadServies(IPersistenProgressServies progressServies, IGameFactory gameFactory)
        {
            this.progressServies = progressServies;
            this._gameFactory = gameFactory;
        }
     
        public PlayerProgress LoadProgress() => PlayerPrefs.GetString(ProgressKey)?
                .ToDeserealized<PlayerProgress>();

        public void SaveProgress() 
        {
            foreach (var progressWriter in _gameFactory.ProgressWriters)
            {
                progressWriter.UpdateProgress(progressServies);
            }

            PlayerPrefs.SetString(ProgressKey, progressServies.Progress.ToJson());
        }
    }
}