using UnityEngine;

namespace RockClimber
{
    public abstract class ObstacleBase : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerColliderLayerMask;

        [SerializeField] protected ObstacleConfigSO _obstacleConfig;

        private void Awake()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (RockClimberUtils.IsInLayerMask(other.gameObject.layer,
                                               _playerColliderLayerMask))
            {
                MessageBus.Publish(new OnLevelFinished(false));
            }
        }

        protected virtual void Move()
        {
        }
    }
}