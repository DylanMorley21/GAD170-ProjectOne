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
    public bool isSkeletonDead = false;
    public bool isPlayerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("<b>~~WELCOME!~~</b>"); // Game instructions and keybinds.
        Debug.Log("Press Space to Start.");
        Debug.Log("Press I to Review Instructions.");
        Debug.Log("Press R to Restart on Defeat.");
        Debug.Log("Press A to Attack.");
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

        if (Input.GetKeyDown(KeyCode.A) && isSkeletonSpawned)
        {
            DamageCoinToss();            
        }
    }

    void GameInstructions()
    {
        Debug.Log("Controls as Follows: Space to Start. I for Instruction. R to Restart on Defeat.");
        // I need this to not interfere with the game running, just to be able to display it at any time, and then continue the game.
    }

    void InitializeNewGame()
    {
        // Debug.Log("Welcome! Controls as follows: Space to Start. ");

        
    }

    void SetPlayerStats() // I am pretty sure this is finished, besides randomizing values.
    {
        playerHealth = playerStartingHealth; // Set players health to the starting health value, used for level up health value.
        playerMagicDamage = 5; // This will need to change according to playerMagicPowerLevel.
        Debug.Log("Player Health: " + playerHealth + ". Player Damage is Currently: " + playerMagicDamage + ".");
        playerMagicPowerLevel = 1; // Not sure if this should be 0 or 1, in this specific situation, setting the starting magic level.
        // Debug.Log("Player magic power level has been set");
        // Debug.Log("Player magic damage has been set");
    }

    void SetSkeletonStats() // I am pretty sure this is finished, besides randomizing values.
    {
        isSkeletonSpawned = true;
        skeletonHealth = skeletonStartingHealth; // Set skeletons health to the starting health value.
        skeletonMagicDamage = Random.Range(0, (3 * playerMagicPowerLevel));
        Debug.Log("Skeleton Health: " + skeletonHealth + ". Skeleton Damage is Currently: " + skeletonMagicDamage + "."); 
    }  
    
    void DamageCoinToss()
    {
        int coinToss = Random.Range(0, 1); // Player is 0, skeleton is 1.

        if (coinToss == 0) // This works mostly, need to do some tweaks but im not sure what.
        {            
            float inSkeleHealth = skeletonHealth - playerMagicDamage;
            skeletonHealth = Mathf.CeilToInt(inSkeleHealth);

            if (skeletonHealth <= 0)
            {
                Debug.Log("Skeleton Has Died!");
                isSkeletonDead = true;
            }
            else
            {
                Debug.Log("Skeleton has taken " + playerMagicDamage + " Damage.");
            }
                        
            if(isSkeletonDead)
            {
                if(!isPlayerDead)
                {
                    PlayerExperienceReward();
                    isSkeletonDead = false;
                }
            }
        }
        else if (coinToss == 1) // I know this is wrong, don't really know what goes here instead.
        {
            if (playerHealth <= 0)
            {
                Debug.Log("Player Has Died");
                isPlayerDead = true;
                GameRestart();
            }
            else
            {
                Debug.Log("PLayer Has Taken " + skeletonMagicDamage + " Damage.");
            }
        }
    }

    void GameRestart() 
    {
        Debug.Log("The Game Has Ended. Press R to Restart.");
        
        if(Input.GetKeyDown(KeyCode.R) && isPlayerDead) // I think this is right for my restart code, may need revision.
        {
            SetPlayerStats();
            SetSkeletonStats();
            Debug.Log("The Game Has Been Restarted.");
        }
    }

    void PlayerExperienceReward() // Definetily need more help here, not really understanding how to link XP, level and stat increases.
    {
        playerExperienceAmount = playerExperienceAmount + Random.Range(45, 50);
        Debug.Log("Player Has Been Awarded " + playerExperienceAmount + " Experience.");
    }

    // void IsPlayerLevelFive() // This needs to check the player level, then end the game once playerMagicPowerLevel = 5
    // {
    //     
    // }
}
