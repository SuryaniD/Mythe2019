using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationHistory : MonoBehaviour
{
    public List<Vector3> locationHistory;
    private readonly int maximum = 9;
    
    void Start()
    {
        locationHistory = new List<Vector3>();
        for (int i = (maximum - 1); i >= 0; i--)
        {
            locationHistory.Add(Vector3.zero);
        }
    }

    void Update()
    {
        locationHistory.Insert(0, transform.position);
        locationHistory.RemoveAt(maximum);
    }
}
