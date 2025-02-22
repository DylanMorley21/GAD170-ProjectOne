using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectOnePassTwo : MonoBehaviour
{
    public int playerHealth = 0; //Players overall health value.
    public int playerStartingHealth = 25; // Player starting health.
    public int playerFaith = 0; // Player starting stat values. 
    public int playerStrength = 0; // Player starting stat values. 
    public int playerDexterity = 0; // Player starting stat values. 
    public int playerMagicPowerLevel = 0; // The value that will calculate player magic power.
    public int playerMagicDamage = 0; // The value that will calculate player magic damage.

    public int skeletonHealth = 0; // Skeletons overall health value.
    public int skeletonStartingHealth = 25; // Skeleton starting health.
    public int skeletonFaith = 0; // Skeleton starting stat values. 
    public int skeletonStrength = 0; // Skeleton starting stat values. 
    public int skeletonDexterity = 0; // Skeleton starting stat values. 
    public int skeletonMagicPowerLevel = 0; // The value that will calculate skeleton magic power.
    public int skeletonMagicDamage = 0; // The value that will calculate skeleton magic damage.


    // Start is called before the first frame update
    void Start()
    {
        GameStartButton();
    }

    // Update is called once per frame
    void Update()
    {
        // IsPLayerLevelFive(); Make this a check for player level, incase game is over.
    }

    void GameStartButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerHealth == 0)
        {
            SetPlayerStats();
            SetSkeletonStats();
        }
    }

    void SetPlayerStats()
    {
        playerHealth = playerStartingHealth; // Set players health to the starting health value.
        // Debug.Log("Player health has been set.");
        playerFaith = 5; // Set the players starting faith, randomize later.
        // Debug.Log("Player faith has been set.");
        playerStrength = 5; // Set the players starting strength, randomize later.
        // Debug.Log("Player strength has been set.");
        playerDexterity = 5; // Set the players starting dexterity, randomize later. 
        // Debug.Log("Player dexterity has been set.");
        Debug.Log("Player Starting stats have been set, as follows: Player Health = " + playerHealth + ". Player Faith = " + playerFaith + ". Player Strength = " + playerStrength + ". Player Dexterity = " + playerDexterity + ".");
    }

    void SetSkeletonStats()
    {
        skeletonHealth = skeletonStartingHealth; // Set skeletons health to the starting health value.
        // Debug.Log("Skeleton health has been set.");
        skeletonFaith = 5; // Set the skeletons starting faith, randomize later.
        // Debug.Log("Skeleton faith has been set.");
        skeletonStrength = 5; // Set the skeletons starting strength, randomize later.
        // Debug.Log("Skeleton strength has been set.");
        skeletonDexterity = 5; // Set the skeletons starting dexterity, randomize later. 
        // Debug.Log("Skeleton dexterity has been set.");
    }

    // void IsPlayerLevelFive()
    // {
    //      If player level is equal to five, end the game.
    // }
}
