using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Child : MonoBehaviour
{
    GameObject Waypoints;
    void Start()
    {
        Waypoints = GameObject.Find("Waypoints");
        gameObject.transform.parent = Waypoints.transform;
    }
}
