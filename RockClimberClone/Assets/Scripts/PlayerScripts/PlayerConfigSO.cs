using UnityEngine;

namespace RockClimber
{
    [CreateAssetMenu(fileName = "PlayerConfigSO", menuName = "ScriptableObjects/PlayerConfigSO")]
    public class PlayerConfigSO : ScriptableObject
    {
        [Range(10000, 20000)]
        public float MoveSpeed = 12500;
    }
}