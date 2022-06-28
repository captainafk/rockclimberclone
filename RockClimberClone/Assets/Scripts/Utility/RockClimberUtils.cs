using System.Collections.Generic;
using UnityEngine;

namespace RockClimber
{
    public static class RockClimberUtils
    {
        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}