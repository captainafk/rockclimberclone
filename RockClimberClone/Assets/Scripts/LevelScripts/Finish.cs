using UnityEngine;

namespace RockClimber
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerColliderLayerMask;

        private bool _hasPlayerReachedFinish = false;

        private void OnTriggerEnter(Collider other)
        {
            if (RockClimberUtils.IsInLayerMask(other.gameObject.layer,
                                               _playerColliderLayerMask) &&
                !_hasPlayerReachedFinish)
            {
                _hasPlayerReachedFinish = true;

                MessageBus.Publish(new OnLevelFinished(true));
            }
        }
    }
}