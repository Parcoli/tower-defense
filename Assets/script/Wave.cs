using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject mobNormal;
    public GameObject mobFast;
    public GameObject mobSlow;
    public GameObject fireMob;
    public GameObject iceMob;
    [HideInInspector]
    public int count;
    public float rate;
}
