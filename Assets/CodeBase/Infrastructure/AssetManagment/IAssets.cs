using Architectural_training.Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace Architectural_training.Assets.CodeBase.Infrastructure.AssetManagment
{
    public interface IAssets : ISercies
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}