using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace RockClimber
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float _levelLoadDelay = 3;
        [SerializeField] private List<LevelBase> _levels;

        private LevelBase _activeLevel;
        private bool _isLevelLoading = false;

        public int ActiveLevelIndex
        {
            get
            {
                return PlayerPrefs.GetInt(nameof(ActiveLevelIndex), 0);
            }

            set
            {
                PlayerPrefs.SetInt(nameof(ActiveLevelIndex), value);
            }
        }

        private void Awake()
        {
            _activeLevel = Instantiate(_levels[ActiveLevelIndex]);

            MessageBus.Receive<OnLevelFinished>().Subscribe(ge =>
            {
                if (!_isLevelLoading)
                {
                    _isLevelLoading = true;

                    Observable.Timer(System.TimeSpan.FromSeconds(_levelLoadDelay))
                              .Subscribe(_ =>
                    {
                        Destroy(_activeLevel.gameObject);

                        if (ge.IsLevelSuccessful)
                        {
                            ActiveLevelIndex = (ActiveLevelIndex + 1) % _levels.Count;
                        }

                        _activeLevel = Instantiate(_levels[ActiveLevelIndex]);

                        _isLevelLoading = false;
                    });
                }
            });
        }
    }
}