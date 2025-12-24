using System;
using UnityEngine;

public class Tagged : MonoBehaviour {
    [Flags]
    public enum Tags {
        NONE = 0,
        PROJECTILE = 1 << 0,
        HITTABLE = 1 << 1,
        COLLECTABLE = 1 << 2,
    }

    [field: SerializeField] public Tags TagList { get; private set; }

    public bool CheckIntersection(Tags tagList) => (TagList & tagList) != 0;
}
