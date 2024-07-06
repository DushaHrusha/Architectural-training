using Architectural_training.Assets.CodeBase.Data;
using CodeBase.Hero;

namespace Architectural_training.Assets.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface ISaveProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);

    }
}