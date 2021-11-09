using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    private Vector3 target;
    private int waypointindex = 0;


    void Start()
    {

        GetNextWaypoint();
    }
    void Update()
    {
        Vector3 dir = target - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target) <= 0.04f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        
        if (waypointindex > Waypoints.current.transform.childCount)
        {

            Destroy(gameObject);
            return;
        }
        else if(waypointindex == Waypoints.current.transform.childCount)
        {
            target = new Vector3(Waypoints.current.LastWaypoint().x, this.transform.position.y, Waypoints.current.LastWaypoint().z);
            waypointindex++;
        }
        else
        {
            
            Debug.Log(Waypoints.current.getPoints());

            target = new Vector3(Waypoints.current.getList(waypointindex).position.x, this.transform.position.y, Waypoints.current.getList(waypointindex).position.z);
            waypointindex++;

        }

    }
}