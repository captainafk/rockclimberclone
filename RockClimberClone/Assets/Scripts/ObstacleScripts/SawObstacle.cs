using DG.Tweening;
using UnityEngine;

namespace RockClimber
{
    [SelectionBase]
    public class SawObstacle : ObstacleBase
    {
        [SerializeField] private Transform _sawTarget;

        private Tween _spinTween;
        private Tween _moveTween;

        protected override void Move()
        {
            _spinTween = transform.DORotate(Vector3.up * 360,
                                            _obstacleConfig.SpinSpeed,
                                            RotateMode.FastBeyond360)
                                  .SetEase(Ease.Linear)
                                  .SetSpeedBased()
                                  .SetLoops(-1, LoopType.Incremental);

            if (_obstacleConfig.MoveSpeed != 0)
            {
                _moveTween = transform.DOMove(_sawTarget.position,
                                              _obstacleConfig.MoveSpeed)
                                      .SetEase(Ease.Linear)
                                      .SetSpeedBased()
                                      .SetLoops(-1, LoopType.Yoyo);
            }
        }

        private void OnDestroy()
        {
            _spinTween?.Kill();
            _moveTween?.Kill();
        }
    }
}