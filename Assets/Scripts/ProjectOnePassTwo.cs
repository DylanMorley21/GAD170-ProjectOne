using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectOnePassTwo : MonoBehaviour
{
    #region Player, Enemy and Game Variables.
    public int playerHealth = 0;
    public int playerStartingHealth = 25; 
    public int playerMagicPowerLevel = 0;
    public int playerExperienceAmount = 0; 
    
    public float playerMagicDamage = 0; // Seperated for my own cleanliness.
   
    public int skeletonHealth = 0;
    public int skeletonStartingHealth = 25;

    public float skeletonMagicDamage = 0; // Seperated for my own cleanliness.

    public bool isGameStarted = false;
    public bool isSkeletonSpawned = false;
    public bool isSkeletonDead = false;
    public bool isPlayerDead = false;
    #endregion

    #region Start
    void Start() // Keybindings and game instructions.
    {
        Debug.Log("<color=green><b>~~<i>WELCOME!</i>~~</b></color>");
        Debug.Log("<color=green><b>~~Fight the Skeletons and Reach Level 5 to Win!~~</b></color>");
        Debug.Log("<color=green><b><i>Press Space to Start.</i></b></color>");
        Debug.Log("<color=green><b><i>Press I to Review Instructions.</i></b></color>");
        Debug.Log("<color=green><b><i>Press R to Restart on Defeat.</i></b></color>");
        Debug.Log("<color=green><b><i>Press A to Attack.</i></b></color>");
    }
    #endregion

    #region Update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // Keybind for game instructions.
        {
            GameInstructions();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGameStarted == false) //Keybind for game start.
        {
            SetPlayerStats();
            SetSkeletonStats();

            isGameStarted = true;
        } 

        if (Input.GetKeyDown(KeyCode.A) && isSkeletonSpawned) // Keybind for progressing battle.
        {
            DamageCoinToss();            
        }

        if (Input.GetKeyDown(KeyCode.R)) // Keybind for restarting game.
        {
            GameRestart();
        }
    }
    #endregion

    #region Instructions
    void GameInstructions() // Game Instructions for In-Game Display.
    {
        Debug.Log("<color=green> <b>~~Controls as Follows: <i>Space to Start. I for Instruction. A to Attack Enemy. R to Restart on Defeat.</i>~~</b></color>");
    }
    #endregion

    #region Player Stats and Damage
    void SetPlayerStats() // Sets player health, level and then damage stat.
    {
        playerHealth = playerStartingHealth * 2;
        playerMagicPowerLevel = 1;
        CalculatePlayerDamage();
        Debug.Log("<color=red><b>~~Player Health: " + playerHealth + ".</b></color> <color=yellow><b>Player Damage is Currently: " + playerMagicDamage + " .~~</b></color>");
        isPlayerDead = false;
    }
    
    void CalculatePlayerDamage() // Calculation for player damage.
    {
        playerMagicDamage = playerMagicPowerLevel * 2 + 3;
    }
    #endregion

    #region Skeleton Stats and Damage
    void SetSkeletonStats() // Sets skeletons health, and damage, level is based off player.
    {
        isSkeletonSpawned = true;
        skeletonHealth = skeletonStartingHealth + playerMagicPowerLevel * 5;
        skeletonMagicDamage = Random.Range(2, (4 * playerMagicPowerLevel));
        Debug.Log("<color=aqua><b>~~Skeleton Health: " + skeletonHealth + ". </b></color> <color=lime><b>Skeleton Damage is Currently: " + skeletonMagicDamage + ".~~</b></color>");
        isSkeletonDead = false;
    }
    #endregion

    #region Coin Toss for Battle
    void DamageCoinToss() //Starting coin toss, decides which player will do damage on button press.
    {
        int coinToss = Random.Range(0, 2); // Player is 0, skeleton is 1.

        // coinToss = 0;
        // coinToss = 1;

        if (coinToss == 0) 
        {            
            float inSkeleHealth = skeletonHealth - playerMagicDamage;
            skeletonHealth = Mathf.CeilToInt(inSkeleHealth);

            if (skeletonHealth <= 0)
            {
                Debug.Log("<color=aqua><i><b>Skeleton Has Died!</b></i></color>");
                isSkeletonDead = true;
                int playerHealingAmount;
                playerHealingAmount = playerMagicPowerLevel * 2 + 5;
                Debug.Log("<color=red><b>The Player Has Earned " + playerHealingAmount + " Health!</b></color>");
                playerHealth = playerHealth + playerHealingAmount;
                Debug.Log("<color=red><b>The Player Has " + playerHealth + " Health.</b></color>");
            }
            else
            {
                Debug.Log("<color=yellow><b>Skeleton has taken " + playerMagicDamage + " Damage.</b></color> <color=aqua><b>Remaining Skeleton Health: " + skeletonHealth + ".</b></color>");
            } 
                        
            if(isSkeletonDead)
            {
                if(!isPlayerDead)
                {
                    PlayerExperienceReward(45, 56);
                    if (!isSkeletonSpawned)
                    {
                        return;
                    }

                    Debug.Log("<color=green><b>~~A New Skeleton Appears!~~</b></color>");

                    SetSkeletonStats();

                    Debug.Log("<color=red><b>~~Player Health: " + playerHealth + "</b></color>. <color=yellow><b> Player Damage is Currently: " + playerMagicDamage + ".~~</b></color>");
                }
            }
        }
        else if (coinToss == 1) 
        {
            int hitCoinToss = Random.Range(0, 10);
            if (hitCoinToss <= 3) // Coin toss for if skeleton hits player, if not, skeleton misses.
            {
                Debug.Log("<color=lime><i><b>The Skeleton Missed.</b></i></color>");
            }
            else
            {
                float inPlayerHealth = playerHealth - skeletonMagicDamage;
                playerHealth = Mathf.CeilToInt(inPlayerHealth);

                if (playerHealth <= 0)
                {
                    Debug.Log("<color=red><b>Player Has Died.</b></color>");
                    Debug.Log("<color=green><b>The Game Has Ended. <i>Press R to Restart.</i></b></color>");
                    isPlayerDead = true;
                    isSkeletonSpawned = false;
                }
                else
                {
                    Debug.Log("<color=lime><b>Player Has Taken " + skeletonMagicDamage + " Damage.</b></color> <color=red><b>Remaining Player Health: " + playerHealth + ".</b></color>");
                }
            }                    
        }
    }
    #endregion

    #region Player Experience and Levelling
    void PlayerExperienceReward(int minimum, int maximum) // Creates a random amount of XP to reward, adds it to players current XP, displays both.
    {
        playerExperienceAmount = playerExperienceAmount + Random.Range(minimum, maximum);
        Debug.Log("<color=magenta><b>Player Has Earned: " + playerExperienceAmount + " Experience.</b></color>");       

        PlayerLevelUp();
    }
    #endregion

    #region Player Level Up
    void PlayerLevelUp()
    {
        int currentExperienceThreshold = 100 * playerMagicPowerLevel;

        if (playerExperienceAmount >= currentExperienceThreshold) // Check for player XP amount, if over 100, level up!
        {
            playerMagicPowerLevel = playerMagicPowerLevel + 1;

            if (playerMagicPowerLevel == 5) // Check for player level, if 5 has been reached, you win!
            {
                Debug.Log("<color=silver><b>You have Won! <i>Press R to Restart.</i></b></color>");
                // isPlayerDead = true;
                isSkeletonSpawned = false;
            }
            else
            {
                Debug.Log("<color=magenta><b>Player Magic Power has Increased. Magic Power is now: " + playerMagicPowerLevel + ".</b></color>");
                CalculatePlayerDamage();
                playerExperienceAmount = playerExperienceAmount - currentExperienceThreshold;
                playerHealth = playerHealth + playerMagicPowerLevel * 3;
                Debug.Log("<color=red><b>Player Heath Stat has Increased. Health is now: " + playerHealth + ".</b></color>");

                PlayerLevelUp();
            }
        }
    }
    #endregion

    #region Restart
    void GameRestart() // Restarts the game by reprinting fresh stats.
    {
        Debug.Log("<color=green><b><i>The Game Has Been Restarted.</i></b></color>");
        SetPlayerStats();
        SetSkeletonStats();        
    }
    #endregion
}
