using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
    [SerializeField] private GameBootstrapper gameBootstrapperPrefab;
    void Awake()
    {
        var bootstrapper = FindObjectOfType<GameBootstrapper>();
        if (bootstrapper == null)
        {
            Instantiate(gameBootstrapperPrefab);
        }
    }
    }
}
