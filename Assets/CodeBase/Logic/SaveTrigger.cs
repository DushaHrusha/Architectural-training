using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(BoxCollider))]
    public class SaveTrigger : MonoBehaviour
    {
        [SerializeField] private BoxCollider collider;
        private ISaveLoadServies _saveLoadServies;
        private void Awake()
        {
            _saveLoadServies = AllSerices.Container.Single<ISaveLoadServies>();
        }
        private void OnTriggerEnter(Collider other)
        {
            _saveLoadServies.SaveProgress();
            Debug.Log("Progress saved");
            gameObject.SetActive(false);
        }
        
        private void DrawGizmo()
        {
            if (!collider)
                return;
            Gizmos.color = new Color32(30, 200, 30,130);
            Gizmos.DrawCube(transform.position + collider.center, collider.size);
        }
    }
}