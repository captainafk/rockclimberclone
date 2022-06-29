using UniRx;
using UnityEngine;

namespace RockClimber
{
    public abstract class ObstacleBase : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerColliderLayerMask;
        [SerializeField] protected ObstacleConfigSO _obstacleConfig;

        private bool _isActive = true;
        private System.IDisposable _d1;

        private void Awake()
        {
            Move();

            _d1 = MessageBus.Receive<OnLevelFinished>().Subscribe(ge =>
            {
                _isActive = false;
                _d1?.Dispose();
            });
        }

        private void OnTriggerEnter(Collider other)
        {
            if (RockClimberUtils.IsInLayerMask(other.gameObject.layer,
                                               _playerColliderLayerMask) && _isActive)
            {
                MessageBus.Publish(new OnLevelFinished(false));
            }
        }

        protected virtual void Move()
        {
        }
    }
}