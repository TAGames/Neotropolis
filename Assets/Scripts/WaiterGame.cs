using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaiterGame : Interactable
{
    public GameObject GuestPrefab;
    public Transform Spawnpoint;
    public GameObject speechBubble;
    public GameObject selectMenu;
    Text text;

    public string[] dialogue;
    public string npcName;

    public int points = 0;

    List<string> guestList = new List<string>();
    string[] foodArray = { "Kartoffel Ramus", "Käse"};
    public Transform[] chairArray;

    public string playerCarriedFood;

    public static WaiterGame Instance { get; set; }

    // Use this for initialization
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        text = speechBubble.transform.GetChild(0).gameObject.GetComponent<Text>();
        SpawnGuest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnGuest()
    {
        GameObject Guest = Instantiate(GuestPrefab, Spawnpoint);
        Guest.SendMessage("SetFood", foodArray[(int)Random.Range(0, foodArray.Length)]);
        Guest.SendMessage("SetChair", chairArray[(int)Random.Range(0, chairArray.Length)]);
        Guest.SendMessage("SetBubble", speechBubble);
    }
    public override void Interact()
    {
        base.Interact();
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Character3DController>().enabled = false;
        DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);
        createChoices();
        DialogueSystem.Instance.DisableContinue();
        DialogueSystem.Instance.HighlightButton();
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Character3DController>().enabled = true;
    }
    void createChoices()
    {
        for(int i = 0; i < foodArray.Length; i++)
        {
            string foodname = foodArray[i];
            DialogueSystem.Instance.AddChoice(foodname, () => { GiveOrder(foodname); });
        }
    }
    void GiveOrder(string food)
    {
        playerCarriedFood = food;
        DialogueSystem.Instance.CloseDialogue();
    }
}