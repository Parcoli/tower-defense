using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public Transform[] points;
    // Start is called before the first frame update
    void Start()
    {
        points = new Transform[transform.childCount];
        for (int i = 0;i < points.Length;i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
