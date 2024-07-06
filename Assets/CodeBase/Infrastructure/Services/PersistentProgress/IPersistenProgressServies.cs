using Architectural_training.Assets.CodeBase.Data;

namespace Architectural_training.Assets.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface IPersistenProgressServies : ISercies
    {
         PlayerProgress Progress{ get; set; }
    }
}