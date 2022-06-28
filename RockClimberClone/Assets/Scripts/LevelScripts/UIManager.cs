using UniRx;
using UnityEngine;

namespace RockClimber
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _startUI;
        [SerializeField] private GameObject _successUI;
        [SerializeField] private GameObject _failUI;

        private void Awake()
        {
            MessageBus.Receive<OnLevelStarted>().Subscribe(ge =>
            {
                _startUI.SetActive(false);
            });

            MessageBus.Receive<OnLevelFinished>().Subscribe(ge =>
            {
                if (ge.IsLevelSuccessful)
                {
                    _successUI.SetActive(true);
                }
                else
                {
                    _failUI.SetActive(true);
                }
            });
        }
    }
}