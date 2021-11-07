using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;
    public int health = 100;

    public int moneyGained = 50;

    public GameObject deathEffect;

    private Vector3 target;
    private int waypointindex = 0;


    void Start()
    {

        GetNextWaypoint();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }

        void Die()
        {

            PlayerStats.Money += moneyGained;

            GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            
            Destroy(gameObject);
        }
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
        
        if (waypointindex > Waypoints.current.transform.childCount - 1)
        {
            PlayerStats.Lives--;
            Destroy(gameObject);
            return;
        }
        else if(waypointindex == Waypoints.current.transform.childCount - 1)
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