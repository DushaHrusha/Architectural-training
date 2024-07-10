using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface IPersistenProgressServies : ISercies
    {
         PlayerProgress Progress{ get; set; }
    }
}