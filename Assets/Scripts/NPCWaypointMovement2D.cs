using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWaypointMovement2D : MonoBehaviour {

    public Transform[] waypoints;
    public Transform goal;
    public float speed;
    public float range;
    public int index = 0;
    private Transform npcTransform;
    public bool firstX;
    public bool atGoal;
	// Use this for initialization
	void Start () {
        npcTransform = GetComponent<Transform>();
        firstX = true;
        atGoal = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}
    void Move()
    {
        if (index < waypoints.Length)
        {

            if (npcTransform.position.x > waypoints[index].position.x +  range || npcTransform.position.y > waypoints[index].position.y + range)
            {
                GoToWaypoint(waypoints[index]);
            }
            else if (npcTransform.position.x < waypoints[index].position.x - range || npcTransform.position.y < waypoints[index].position.y - range)
            {
                GoToWaypoint(waypoints[index]);
            }
            else
            {
                index++;
            }
        }
        else
        {
            GoToWaypoint(goal);
            if(npcTransform.position.x < goal.position.x +  range && npcTransform.position.x > goal.position.x - range &&
                npcTransform.position.y < goal.position.y + range && npcTransform.position.y > goal.position.y - range)
            {
                atGoal = true;
            }
        }
    }
    void GoToWaypoint(Transform waypoint)
    {
        if (firstX)
        {
            if (npcTransform.position.x < waypoint.position.x - range)
            {
                npcTransform.position += new Vector3(speed, 0, 0);
            }
            else if (npcTransform.position.x > waypoint.position.x + range)
            {
                npcTransform.position -= new Vector3(speed, 0, 0);
            }
            else if (npcTransform.position.y < waypoint.position.y - range)
            {
                npcTransform.position += new Vector3(0, speed, 0);
            }
            else if (npcTransform.position.y > waypoint.position.y + range)
            {
                npcTransform.position -= new Vector3(0, speed, 0);
            }
        }
        else
        {
            if (npcTransform.position.y < waypoint.position.y - range)
            {
                npcTransform.position += new Vector3(0, speed, 0);
            }
            else if (npcTransform.position.y > waypoint.position.y + range)
            {
                npcTransform.position -= new Vector3(0, speed, 0);
            }
            else if (npcTransform.position.x < waypoint.position.x - range)
            {
                npcTransform.position += new Vector3(speed, 0, 0);
            }
            else if (npcTransform.position.x > waypoint.position.x + range)
            {
                npcTransform.position -= new Vector3(speed, 0, 0);

            }
        }
    }
    void AddWaypoint(Transform waypoint)
    {
        waypoints[index] = waypoint;
    }
}
