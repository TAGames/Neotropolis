using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterGame : MonoBehaviour
{
    public GameObject GuestPrefab;
    public Transform Spawnpoint;
    List<string> guestList = new List<string>();
    string[] foodArray = { "Kartoffel Ramus", "Käse"};
    public Transform[] chairArray;
    // Use this for initialization
    void Start()
    {
        spawnGuest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnGuest()
    {
       GameObject Guest = Instantiate(GuestPrefab, Spawnpoint);
        Guest.SendMessage("SetFood", foodArray[(int)Random.Range(0, foodArray.Length)]);
        Guest.SendMessage("SetChair", chairArray[(int)Random.Range(0, chairArray.Length)]);
    }

}