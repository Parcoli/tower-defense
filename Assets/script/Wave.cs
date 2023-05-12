using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject mobNormal;
    public GameObject mobFast;
    public GameObject mobSlow;
    [HideInInspector]
    public int count;
    public float rate;
}
