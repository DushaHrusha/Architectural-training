using CodeBase.Data;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure
{
    public interface ISaveLoadServies : ISercies
    {
        PlayerProgress LoadProgress();
        void SaveProgress();

    }
}