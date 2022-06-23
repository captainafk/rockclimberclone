using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace RockClimber
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<LevelBase> _levels;

        private LevelBase _activeLevel;

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
                Destroy(_activeLevel);

                if (ge.IsLevelSuccessful)
                {
                    ActiveLevelIndex = (ActiveLevelIndex + 1) % _levels.Count;
                }

                _activeLevel = Instantiate(_levels[ActiveLevelIndex]);
            });
        }
    }
}