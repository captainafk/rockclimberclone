using System;
using System.Collections;
using UnityEngine;

namespace RockClimber
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Rigidbody _handRB;
        private IEnumerator _moveRoutine;
        private int _lastUsedHandIndex = 0;

        public void Move(Vector3 target, Action onComplete = null)
        {
            _handRB = _player.Hands[_lastUsedHandIndex].GetComponent<Rigidbody>();
            _lastUsedHandIndex = (_lastUsedHandIndex + 1) % _player.Hands.Count;

            if (_moveRoutine != null)
            {
                StopCoroutine(_moveRoutine);
            }

            _moveRoutine = MovePlayer(target, onComplete);
            StartCoroutine(_moveRoutine);
        }

        private IEnumerator MovePlayer(Vector3 target, Action onComplete = null)
        {
            var isCompleted = false;

            while (true)
            {
                var direction = target - _handRB.transform.position;
                var sqrDistance = direction.sqrMagnitude;

                _handRB.AddForce(_player.Config.MoveSpeed *
                                    Time.fixedDeltaTime *
                                    direction.normalized,
                                 ForceMode.Acceleration);

                if (!isCompleted && sqrDistance <= 0.1f)
                {
                    isCompleted = true;
                    onComplete?.Invoke();
                }

                yield return new WaitForFixedUpdate();
            }
        }
    }
}