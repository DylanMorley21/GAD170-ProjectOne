using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectOne : MonoBehaviour
{
    public int playerHealth = 0;
    public int playerStartingHealth = 25;
    public int playerFaith = 0;
    public int playerStrength = 0;
    public int playerDexterity = 0;
    public int playerMagicPowerLevel = 0;
    public int playerLevel = 1;
    public int playerExperience = 15;
    public int experienceThreshold = 100;

    public int skeletonHealth = 0;
    public int skeletonFaith = 0;
    public int skeletonStrength = 0; 
    public int skeletonDexterity = 0;
    public int skeletonMagicPowerLevel = 0;
    public int skeletonLevel = 1;

    public bool gameOver = false;
    // public bool isPlayerLeveledUp = false;
    public bool skeletonDefeat = false;

    // Start is called before the first frame update
    void Start()
    {
        // SetInstructions(); Make some instructions for keybinds.
        SetPlayerStats();
        SetSkeletonStats();
    }

    // Update is called once per frame
    void Update()
    {
        Battle();
        TestGameResult();
        GameRestart();
    }

    void SetPlayerStats()
    {
        // playerLevel = 1; // Add XP and level caps that increase exponentially.
        // playerHealth = 25;
        // playerFaith = Random.Range(5, 10);
        // playerStrength = Random.Range(5, 10);
        // playerDexterity = Random.Range(5, 10);
        

        // playerLevel = 1; // Add XP and level caps that increase exponentially.
        // playerHealth = 25;
        // playerFaith = 1;
        // playerStrength = 1;
        // playerDexterity = 1;

        playerLevel = 1; // Add XP and level caps that increase exponentially.
        playerHealth = playerStartingHealth;
        playerFaith = 4;
        playerStrength = 4;
        playerDexterity = 4;
        playerExperience = 15;
    }

    void SetSkeletonStats()
    {
        // skeletonLevel = 1; // Add XP and level caps that increase exponentially.
        // skeletonHealth = 25;
        // skeletonFaith = Random.Range(5, 10);
        // skeletonStrength = Random.Range(5, 10);
        // skeletonDexterity = Random.Range(5, 10);

        // skeletonLevel = 1; // Add XP and level caps that increase exponentially.
        // skeletonHealth = 25;
        // skeletonFaith = 2;
        // skeletonStrength = 1;
        // skeletonDexterity = 2;

        skeletonLevel = 1; // Add XP and level caps that increase exponentially.
        skeletonHealth = 25;
        skeletonFaith = 2;
        skeletonStrength = 2;
        skeletonDexterity = 2;
    }

   void Battle()
    {
        // Debug.Log("here");

        if(gameOver == true)
        {
            Debug.Log("Game has ended.");
        }
        else if (Input.GetKeyDown(KeyCode.F) && playerHealth > 0 && skeletonHealth > 0)
        {
            Debug.Log((Input.GetKeyDown(KeyCode.F) + "F has been pressed."));

            playerMagicPowerLevel = GeneratePlayerMagicPower(playerFaith, playerStrength, playerDexterity);
            skeletonMagicPowerLevel = GenerateSkeletonMagicPower(skeletonFaith, skeletonStrength, skeletonDexterity);
            DetermineWinner(playerMagicPowerLevel, skeletonMagicPowerLevel);
        }
        else if(playerHealth <= 0)
        {
            Debug.Log("Player has died, restart?");
            gameOver = true;
        }
        else if(skeletonHealth <= 0 && skeletonDefeat == false) // The skeletonHealth check is unneccessary as the check was made above.
        {
            Debug.Log("Skeleton has been defeated.");

            AddPlayerExperience();
            
            // if(playerExperience >= experienceThreshold)
            // {
            //     Debug.Log("The player has attained enough experience for a level up.");
            //     
            //     PlayerLevelUp();
            // }

            skeletonDefeat = true;

            // if (Input.GetKeyDown(KeyCode.T) && playerExperience >= experienceThreshold)
            // {
            //     Debug.Log("T has been pressed.");
            //     PlayerLevelUp();
            // }

            // PlayerLevelUp();

            if (playerHealth >= 1)
            {
                SetSkeletonStats();

                skeletonDefeat = false;
            }
        }
    }

    void PlayerLevelUp()
    {
        // Debug.Log("Here.");

        // playerExperience = playerExperience - experienceThreshold;

        experienceThreshold = (int) (experienceThreshold * 1.5); // create a variable for threshold increase.
               
        playerHealth = playerStartingHealth + playerHealth;

        playerLevel = playerLevel + 1;

        Debug.Log("Player has leveled up, new health is " + playerHealth);

        Debug.Log("Skeleton level is now: " + skeletonLevel);

        // isPlayerLeveledUp = true;
    }

    int GeneratePlayerMagicPower(float inPlayerFaith, float inPlayerStrength, float inPlayerDexterity)
    {
        // int playerMagicPower = (int)((playerFaith * 0.5) * (playerStrength * 1.5) * (playerDexterity * 0.75) * (Random.Range(1, 10)));

        return (int)((inPlayerFaith) * (inPlayerStrength) * (inPlayerDexterity));

        // return playerMagicPower;
    }

    int GenerateSkeletonMagicPower(float inSkeletonFaith, float inSkeletonStrength, float inSkeletonDexterity)
    {
        // int skeletonMagicPower = (int)((skeletonFaith * 0.5) * (skeletonStrength * 1.5) * (skeletonDexterity * 0.75) * (Random.Range(1, 10)));

        return (int)((inSkeletonFaith) * (inSkeletonStrength) * (inSkeletonDexterity));

        // return skeletonMagicPower;
    }

    int GenerateSkeletonMagicPower(float skeletonFaith, float skeletonStrength, float skeletonDexterity, float skeletonHairColour)
    {
        // int skeletonMagicPower = (int)((skeletonFaith * 0.5) * (skeletonStrength * 1.5) * (skeletonDexterity * 0.75) * (Random.Range(1, 10)));

        return (int)((skeletonFaith) * (skeletonStrength) * (skeletonDexterity));

        // return skeletonMagicPower;
    }

    void DetermineWinner(int playerMagicPowerLevel, int skeletonMagicPowerLevel)
    {
        if (playerMagicPowerLevel > skeletonMagicPowerLevel)
        {
            skeletonHealth -= 10;
            Debug.Log("Skeleton has taken 10 damage.");
        }
        else if(skeletonMagicPowerLevel > playerMagicPowerLevel)
        {
            playerHealth -= 10;
            Debug.Log("Player has taken 10 damage.");
        }
        else
        {
            playerHealth -= 5;
            skeletonHealth -= 5;
            Debug.Log("Both players have taken damage.");
        }
    }

    void GameRestart()
    {
        if (Input.GetKeyDown(KeyCode.G) && playerHealth <= 0)
        {
            SetPlayerStats();
            SetSkeletonStats();
            Debug.Log("Game has been restarted.");

            gameOver = false;
        }
    }

    void TestGameResult()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerExperience >= experienceThreshold)
        {
            PlayerLevelUp();
            Debug.Log("Player has leveled up.");

            gameOver = false;
        }
    }

    void AddPlayerExperience() // Future random value.
    {
        playerExperience = playerExperience + 50;
        Debug.Log("Player Experience is now: " + playerExperience);
    }
}

