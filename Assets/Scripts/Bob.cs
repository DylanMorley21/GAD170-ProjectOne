using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    public int playerHealth = 0;
    public int playerStartingHealth = 25;
    public int playerVitality = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPlayerStats()
    {
        playerHealth = playerStartingHealth; // Set players health to the starting health value.
        // Debug.Log("Health has been set.");
        playerVitality = 5; // Set the players starting vitality, change to random later.
        Debug.Log("Player vitality has been set.");
    }
}
