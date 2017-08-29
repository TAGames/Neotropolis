using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GuestBehaviour : Interactable {

    GameObject waiterGame;
    GameObject speechBubble;
    Text text;
    Transform chair;
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
    void SetBubble(GameObject speechBubble)
    {
        this.speechBubble = speechBubble;
        text = speechBubble.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public override void Interact()
    {
        base.Interact();
        Talk();
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
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance && (state == State.Order))
            {
                string[] talking = new string[] { "Einmal " + food + ", bitte" };
                DialogueSystem.Instance.AddNewDialogue(talking, "Guest");
                state = State.WaitFood;
            }
        }
            
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
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
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
            Debug.Log("Angry Guest2");
        }
    }
    void Exit()
    {
        agent.SetDestination(exitPos);
    }
}
