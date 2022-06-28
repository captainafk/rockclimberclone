using System.Collections.Generic;
using UnityEngine;

namespace RockClimber
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfigSO _config;
        [SerializeField] private List<Transform> _hands;

        public PlayerConfigSO Config => _config;
        public List<Transform> Hands => _hands;
    }
}