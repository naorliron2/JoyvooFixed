using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoSingleton<DiceRoller>
{
    //[SerializeField] uint numOfSides;
    [SerializeField] float rollingDieTime;
    [SerializeField] float switchDieSideTime;
    [SerializeField] GameObject[] dieSides;
    [SerializeField]int lastActiveDie = 0;
    [SerializeField] float timer;
    [SerializeField] float switchTimer;
    bool startTimer;
    // Start is called before the first frame update
    public void Roll()
    {
        dieSides[lastActiveDie].SetActive(false);
        switchTimer = switchDieSideTime;
        timer = rollingDieTime;
        startTimer = true;
    }
    private void Update()
    {

        if (startTimer)
        {

            timer -= Time.deltaTime;
            if (timer > 0)
            {
                switchTimer -= Time.deltaTime;
                if (switchTimer <= 0)
                {
                    dieSides[lastActiveDie].SetActive(false);
                    //Debug.Log("aaaaa");
                    int randNum = Random.Range(0, dieSides.Length);
                    dieSides[randNum].SetActive(true);
                    lastActiveDie = randNum;
                    switchTimer = switchDieSideTime;
                }
            }
            else
            {
                dieSides[lastActiveDie].SetActive(false);
                int dieRoll = Random.Range(0, dieSides.Length);
                dieSides[dieRoll].SetActive(true);
                lastActiveDie = dieRoll;
                startTimer = false;
                timer = rollingDieTime;
                switchTimer = switchDieSideTime;
                PlayerManager.instance.currentPlayer.MoveTile(dieRoll+1);
               
            }
        }
    }

}
