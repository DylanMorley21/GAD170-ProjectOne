using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectOnePassTwo : MonoBehaviour
{
    public int playerHealth = 0; //Players overall health value.
    public int playerStartingHealth = 25; // Player starting health.
    // public int playerFaith = 0; // Player starting stat values. 
    // public int playerStrength = 0; // Player starting stat values. 
    // public int playerDexterity = 0; // Player starting stat values. 
    public int playerMagicPowerLevel = 0; // The value that will calculate player magic power.
    public int playerExperienceAmount = 0; // The amount of experience the player starts with.
    public float playerMagicDamage = 0; // The value that will calculate player magic damage.

    public int skeletonHealth = 0; // Skeletons overall health value.
    public int skeletonStartingHealth = 25; // Skeleton starting health.
    // public int skeletonFaith = 0; // Skeleton starting stat values. 
    // public int skeletonStrength = 0; // Skeleton starting stat values. 
    // public int skeletonDexterity = 0; // Skeleton starting stat values. 
    // public int skeletonMagicPowerLevel = 0; // The value that will calculate skeleton magic power.
    public int skeletonMagicDamage = 0; // The value that will calculate skeleton magic damage.

    public bool isGameStarted = false;
    public bool isSkeletonSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("<b>MWUAHAHAHA.</b>"); // Game instructions and keybinds.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameInstructions();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGameStarted == false)
        {
            SetPlayerStats();
            SetSkeletonStats();

            isGameStarted = true;
        }

        if (isSkeletonSpawned)
        {

            int coinToss = Random.Range(0, 1); // Player is 0, skeleton is 1.

            if(coinToss == 0)
            {
                float inSkeleHealth = skeletonHealth;
                inSkeleHealth = skeletonHealth - playerMagicDamage;
                skeletonHealth = Mathf.CeilToInt(inSkeleHealth);

                if(skeletonHealth <= 0)
                {
                    Debug.Log("Skeleton Has Died!");
                }
                else
                {
                    Debug.Log("Skeleton has taken " + playerMagicDamage + " damage.");

                }

            }
        }
    }

    void GameInstructions()
    {
        Debug.Log("Welcome! Controls as follows: Space to Start. ");
    }

    void InitializeNewGame()
    {
        // Debug.Log("Welcome! Controls as follows: Space to Start. ");

        
    }

    void SetPlayerStats()
    {
        playerHealth = playerStartingHealth; // Set players health to the starting health value.
        Debug.Log("Player Starting stats have been set, as follows: " + "Player Health = " + playerHealth);
        playerMagicPowerLevel = 1; // Not sure if this should be 0 or 1, in this specific situation, setting the starting magic level.
        // Debug.Log("Player magic power level has been set");
        playerMagicDamage = 5; // This will need to change according to playerMagicPowerLevel.
        // Debug.Log("Player magic damage has been set");
    }

    void SetSkeletonStats()
    {
        skeletonHealth = skeletonStartingHealth; // Set skeletons health to the starting health value.
        skeletonMagicDamage = Random.Range(0, (3 * playerMagicPowerLevel));
        Debug.Log("Skeleton Health: " + skeletonHealth + ". Skeleton Damage: " + skeletonMagicDamage); 
    }  
    
    void DeterminePLayerPower()
    {
        
    }



    // void IsPlayerLevelFive()
    // {
    //      If player level is equal to five, end the game.
    // }
}
