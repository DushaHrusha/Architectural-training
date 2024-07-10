using CodeBase.Data;
using CodeBase.Hero;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface ISaveProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);

    }
}