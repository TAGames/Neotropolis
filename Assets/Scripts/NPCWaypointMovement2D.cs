using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWaypointMovement2D : MonoBehaviour {

    public Transform[] waypoints;
    public Transform goal;
    public float speed;
    public float range;
    private int index = 0;
    private Transform npcTransform;
	// Use this for initialization
	void Start () {
        npcTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}
    void Move()
    {
        Debug.Log("0");
        if (index < waypoints.Length)
        {
            Debug.Log("1");

            if (npcTransform.position.x > waypoints[index].position.x +  range || npcTransform.position.y > waypoints[index].position.y + range)
            {
                GoToWaypoint(waypoints[index]);
                Debug.Log("lol");
            }
            else if (npcTransform.position.x < waypoints[index].position.y - range || npcTransform.position.y < waypoints[index].position.y - range)
            {
                GoToWaypoint(waypoints[index]);
                Debug.Log("lol");
            }
            else
            {
                index++;
            }
        }
        else
        {
            Debug.Log("2");
            GoToWaypoint(goal);
        }
    }
    void GoToWaypoint(Transform waypoint)
    {
        if(npcTransform.position.x < waypoint.position.x - range)
        {
            npcTransform.position += new Vector3(speed, 0, 0); 
        }
        else if (npcTransform.position.x > waypoint.position.x)
        {
            npcTransform.position -= new Vector3(speed, 0, 0 + range);
        }
        else if(npcTransform.position.y < waypoint.position.y - range)
        {
            npcTransform.position += new Vector3(0, speed, 0);
        }
        else if (npcTransform.position.y > waypoint.position.y + range)
        {
            npcTransform.position -= new Vector3(0, speed, 0);
        }
    }
    void AddWaypoint(Transform waypoint)
    {
        waypoints[index] = waypoint;
    }
}
