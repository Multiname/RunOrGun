using System;
using UnityEngine;

public class Tagged : MonoBehaviour {
    [Flags]
    public enum Tags {
        NONE = 0,
        FIRST_PLAYER_PROJECTILE = 1 << 0,
        SECOND_PLAYER_PROJECTILE = 1 << 1,
        HITTABLE = 1 << 2,
        COLLECTABLE = 1 << 3,
    }

    [field: SerializeField] public Tags TagList { get; private set; }

    public bool CheckIntersection(Tags tagList) => (TagList & tagList) != 0;
}
