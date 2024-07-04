using UnityEngine;

namespace Architectural_training.Assets.CodeBase.Infrastructure.AssetManagment
{
    public interface IAssetProvder
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}