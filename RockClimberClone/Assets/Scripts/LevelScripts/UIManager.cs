using UniRx;
using UnityEngine;

namespace RockClimber
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _startUI;
        [SerializeField] private GameObject _successUI;
        [SerializeField] private GameObject _failUI;

        private System.IDisposable _d1;
        private System.IDisposable _d2;

        private void Awake()
        {
            _d1 = MessageBus.Receive<OnLevelStarted>().Subscribe(ge =>
            {
                _startUI.SetActive(false);
                _d1.Dispose();
            });

            _d2 = MessageBus.Receive<OnLevelFinished>().Subscribe(ge =>
            {
                if (ge.IsLevelSuccessful)
                {
                    _successUI.SetActive(true);
                }
                else
                {
                    _failUI.SetActive(true);
                }

                _d2.Dispose();
            });
        }
    }
}