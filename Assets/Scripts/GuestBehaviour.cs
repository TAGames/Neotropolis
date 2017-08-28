using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GuestBehaviour : MonoBehaviour {

    GameObject waiterGame;
    GameObject speechBubble;
    Text text;
    Transform chair = null;
    Vector3 exitPos;
    NavMeshAgent agent;
    public string food = "I Am Error";
    int points = 10;
    float speed = 0.05f;
    private float endOfWaiting = 5;
    private float timer = 0;
    public bool alive = true;
    public State state;

    public enum State
    {
        Waiting,
        Order,
        WaitFood,
        Exit
    }

    // Use this for initialization
    void Start () {
        waiterGame = GameObject.Find("WaiterGame");
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("FSM");
        agent.SetDestination(chair.position);
        speechBubble = this.transform.GetChild(0).gameObject;
        text = speechBubble.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
    }
    void SetFood(string food) //Set At spawn by WaiterGame
    {
        this.food = food;
    }
    void SetChair(Transform destination)
    {
        chair = destination;
        exitPos = this.transform.position;
    }

    void OnTriggerStay(Collider coll)
    {
        if(coll.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (Input.GetKey(KeyCode.T))
            {
                Talk();
            }
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            speechBubble.SetActive(false);
        }
    }
    void Talk()
    {
        speechBubble.SetActive(true);
        Debug.Log("lol2");
        speechBubble.transform.LookAt(new Vector3(speechBubble.transform.position.x, speechBubble.transform.position.y + 5, this.transform.position.z - 10));
        speechBubble.transform.Rotate(new Vector3(0,180,0));
        text.text = "Einmal " + food + ", bitte";
    }

    IEnumerator FSM() //Finite State Machine
    {
        while (alive)
        {
            switch (state)
            {
                case State.Waiting:
                    Waiting();
                    break;
                case State.Order:
                    Order();
                    break;
                case State.WaitFood:
                    WaitFood();
                    break;
                case State.Exit:
                    Exit();
                    break;
            }
            yield return null;
        }
    }
    //StateMethods
    void Waiting()
    {
        timer += Time.deltaTime;
        if(timer >= endOfWaiting)
        {
            timer = 0;
            state = State.Order;
        }
    }
    void Order()
    {
        timer += Time.deltaTime;
        if(timer >= 10)
        {
            Debug.Log("Angry Guest");
        }
    }
    void WaitFood()
    {
        timer += Time.deltaTime;

        if(timer >= 20)
        {
            Debug.Log("Angry Guest");
        }
    }
    void Exit()
    {
        agent.SetDestination(exitPos);
    }
}
