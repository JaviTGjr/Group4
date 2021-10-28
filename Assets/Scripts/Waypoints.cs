using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Waypoints current;
    public static List<Transform> points;
    public static int Length;
    public GameObject last;



    void Awake()
    {
        points = new List<Transform>();
        current = this;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            points.Add(transform.GetChild(i));
        }
    }
    public void AddWaypoint(Transform objectchild)
    {
        points.Add(objectchild);
        Debug.Log(points.Count);
    }
    public Transform getList(int number)
    {
        return points[number];


    }

    public int getPoints()
    {
        return points.Count;
    }

    public Vector3 LastWaypoint()
    {
        return last.transform.position;
    }
}