using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GuestBehaviour : Interactable {

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

    bool angry1, angry2;

    public enum State
    {
        Waiting,
        Order,
        WaitFood,
        Exit
    }

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("FSM");
        agent.SetDestination(chair.position);
        angry1 = false;
        angry2 = false;
        
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
            DialogueSystem.Instance.CloseDialogue();
        }
    }
    void Talk()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if(state == State.Order)
                {
                    string[] talking = new string[] {food + ", please" };
                    DialogueSystem.Instance.AddNewDialogue(talking, "Guest");
                    state = State.WaitFood;
                }
                else if(state == State.WaitFood)
                {
                    if (WaiterGame.Instance.playerCarriedFood == food)
                    {
                        string[] talking = new string[] {"Ah! " + food + "! Yummy!"};
                        DialogueSystem.Instance.AddNewDialogue(talking, "Guest");
                        WaiterGame.Instance.playerCarriedFood = "";
                        WaiterGame.Instance.points += ComputePoints();
                        state = State.Exit;
                    }
                    else if(WaiterGame.Instance.playerCarriedFood == "")
                    {
                        string[] talking = new string[] { "You don't carry any food" };
                        DialogueSystem.Instance.AddNewDialogue(talking, "Guest");
                    }
                    else
                    {
                        string[] talking = new string[] { "I Ordered: " + food + "!" };
                        DialogueSystem.Instance.AddNewDialogue(talking, "Guest");
                    }
                }
            }
        }
            
    }

    int ComputePoints()
    {
        if (angry1 && !angry2)
        {
            points -= 2;
        }
        else if(!angry1 && angry2)
        {
            points -= 5;
        }
        else
        {
            points -= 8;
        }
        return points;
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
            angry1 = true;
        }
    }
    void WaitFood()
    {
        timer += Time.deltaTime;

        if(timer >= 20)
        {
            angry2 = true;
        }

    }
    void Exit()
    {
        agent.SetDestination(exitPos);
    }
}
