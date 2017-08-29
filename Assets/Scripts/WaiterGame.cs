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

    List<string> guestList = new List<string>();
    string[] foodArray = { "Kartoffel Ramus", "Käse"};
    public Transform[] chairArray;
    // Use this for initialization
    void Start()
    {
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character3DController>().enabled = false;
        DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Character3DController>().enabled = true;
    }
}