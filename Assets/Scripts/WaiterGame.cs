using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterGame : MonoBehaviour
{
    public GameObject GuestPrefab;
    public Transform Spawnpoint;
    List<string> guestList = new List<string>();
    string[] FoodArray = { "Kartoffel Ramus", "Käse"};
    public Transform[] chairArray;
    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, 0, -0.1f);
        spawnGuest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnGuest()
    {
       GameObject Guest = Instantiate(GuestPrefab, Spawnpoint);
        Guest.SendMessage("SetFood", FoodArray[(int)Random.Range(0, FoodArray.Length)]);
        Guest.SendMessage("SetChair", chairArray[0]);
    }

}