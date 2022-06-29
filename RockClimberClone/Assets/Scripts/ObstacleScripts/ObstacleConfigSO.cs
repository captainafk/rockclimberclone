using UnityEngine;

namespace RockClimber
{
    [CreateAssetMenu(fileName = "ObstacleConfig", menuName = "ScriptableObjects/ObstacleConfigSO")]
    public class ObstacleConfigSO : ScriptableObject
    {
        [Header("Movement Config")]
        [Tooltip("Spin speed is in degrees per second.")]
        [Range(0, 720)] public float SpinSpeed = 360;

        [Tooltip("Move speed is in units per second.")]
        [Range(0, 5)] public float MoveSpeed = 1;
    }
}