using UnityEngine;

namespace RockClimber
{
    [CreateAssetMenu(fileName = "PlayerConfigSO", menuName = "ScriptableObjects/PlayerConfigSO")]
    public class PlayerConfigSO : ScriptableObject
    {
        [Header("Movement Config")]
        [Range(10000, 25000)] public float MoveSpeed = 12500;
    }
}