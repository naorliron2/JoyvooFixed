using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoSingleton<DiceRoller>
{
    [Header("Variables")]
    [SerializeField] float rollingDieTime;
    [SerializeField] float switchDieSideTime;
    [Header("References")]
    [SerializeField] GameObject[] dieSides;
    [Header("Debug Info")]
    [SerializeField] int lastActiveDie = 0;
    [SerializeField] float timer;
    [SerializeField] float switchTimer;
    bool startTimer;
    /// <summary>
    /// Starts the rolling sequence
    /// </summary>
    public void Roll()
    {
        PlayerManager.instance.currentPlayer.SetIsMoving(true);
        //make sure the last die side is deactivated
        dieSides[lastActiveDie].SetActive(false);
        //reset timers
        ResetTimers();
        //Start the timers
        startTimer = true;
    }
    /// <summary>
    /// resets both of the timers
    /// </summary>
    private void ResetTimers()
    {
        switchTimer = switchDieSideTime;
        timer = rollingDieTime;
    }

    private void Update()
    {
        StartRollingSequence();
    }

    private void StartRollingSequence()
    {
        if (startTimer)
        {
            //The first timer is responsible for counting how much time the whole sequence goes on, and then rolling a number to move on
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                //the second timer/switch timer is responsible for counting the time between each time we switch the die side
                switchTimer -= Time.deltaTime;
                if (switchTimer <= 0)
                {
                    //each time the timer ends
                    //we again make sure the last die is deactivated
                    dieSides[lastActiveDie].SetActive(false);
                    //we then roll a random num, this will determin what number will show on the dice
                    int randNum = Random.Range(0, dieSides.Length);
                    //we activate the apropriate die side
                    dieSides[randNum].SetActive(true);
                    //and set our lastActiveDie to the current one
                    lastActiveDie = randNum;
                    //reset the timer;
                    switchTimer = switchDieSideTime;
                }
            }
            else
            {
                //if the whole sequence has ended
                //we deactivate the last die
                dieSides[lastActiveDie].SetActive(false);
                //roll a new number, this one will be used for the actual moving of our player
                int dieRoll = Random.Range(0, dieSides.Length);
                //we activate the apropriate die side
                dieSides[dieRoll].SetActive(true);
                //end the sequence
                startTimer = false;
                //set the current die to lastactive in order to deactivate it in the next sequence
                lastActiveDie = dieRoll;
                ResetTimers();
                //Move the player, using dieroll + 1 to accomodate for arrays(dieroll 5 = dieside 6)
                PlayerManager.instance.currentPlayer.MoveTile(dieRoll + 1);

            }
        }
    }
}
