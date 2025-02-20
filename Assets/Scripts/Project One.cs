using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectOne : MonoBehaviour
{
    public int playerHealth = 0;
    public int playerFaith = 0;
    public int playerStrength = 0;
    public int playerDexterity = 0;
    int playerMagicPowerLevel = 0;
    int playerLevel = 1;

    public int skeletonHealth = 0;
    public int skeletonFaith = 0;
    public int skeletonStrength = 0; 
    public int skeletonDexterity = 0;
    int skeletonMagicPowerLevel = 0;
    int skeletonLevel = 1;

    bool gameOver = false;
    bool isPlayerLeveledUp = false;
    bool skeletonDefeat = false;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerStats();
        SetSkeletonStats();
    }

    // Update is called once per frame
    void Update()
    {
        Battle();
        GameRestart();
    }

    void SetPlayerStats()
    {
        playerLevel = 1; // Add XP and level caps that increase exponentially.
        playerHealth = 25;
        playerFaith = Random.Range(5, 10);
        playerStrength = Random.Range(5, 10);
        playerDexterity = Random.Range(5, 10);
    }

    void SetSkeletonStats()
    {
        skeletonLevel = 1; // Add XP and level caps that increase exponentially.
        skeletonHealth = 25;
        skeletonFaith = Random.Range(5, 10);
        skeletonStrength = Random.Range(5, 10);
        skeletonDexterity = Random.Range(5, 10);
    }

    void PlayerLevelUp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth = playerHealth + 25;

            Debug.Log("Player has leveled up, new health is " + playerHealth + ". Stats have increased.");

            isPlayerLeveledUp = true;
        }
    }

   void Battle()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerHealth > 0 && skeletonHealth > 0)
        {
            playerMagicPowerLevel = GeneratePlayerMagicPower(playerFaith, playerStrength, playerDexterity);
            skeletonMagicPowerLevel = GenerateSkeletonMagicPower(skeletonFaith, skeletonStrength, skeletonDexterity);
            DetermineWinner(playerMagicPowerLevel, skeletonMagicPowerLevel);
        }
        else if(playerHealth <= 0 && gameOver == false)
        {
            Debug.Log("Player has died, restart?");
            gameOver = true;
        }
        else if(skeletonHealth <= 0 && gameOver == false)
        {
            if(skeletonDefeat == false)
            {
                Debug.Log("Skeleton has been defeated.");
            }
            
            skeletonDefeat = true;

            PlayerLevelUp();

            if(isPlayerLeveledUp == true)
            {
                SetSkeletonStats();

                isPlayerLeveledUp = false;

                skeletonDefeat = false;
            }
        }
    }
    
    int GeneratePlayerMagicPower(float playerFaith, float playerStrength, float playerDexterity)
    {
        int playerMagicPower = (int)((playerFaith * 0.5) * (playerStrength * 1.5) * (playerDexterity * 0.75) * (Random.Range(1, 10)));

        return playerMagicPower;
    }

    int GenerateSkeletonMagicPower(float skeletonFaith, float skeletonStrength, float skeletonDexterity)
    {
        int skeletonMagicPower = (int)((skeletonFaith * 0.5) * (skeletonStrength * 1.5) * (skeletonDexterity * 0.75) * (Random.Range(1, 10)));

        return skeletonMagicPower;
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
}

