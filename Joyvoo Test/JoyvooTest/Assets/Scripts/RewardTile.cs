using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardTile : TileBASE
{
    [Header("Variable")]
    [SerializeField] uint rewardAmount;

    public override void LandedOn(Player playerThatLanded)
    {
        //get a random number between 1 and 100
        int randomNum = Random.Range(1, 101);
        //if its between 1 and 50(so 50%)
        
        if (InRange(randomNum, 1, 50))
        {
            //add money
            playerThatLanded.AddMoney(rewardAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + rewardAmount + "$");

        }

        //if its between 51 and 60(so 10%)
        else if (InRange(randomNum, 51, 60))
        {
            //calculate how much to add and add it
            uint CalculatedAmount = rewardAmount + (uint)(rewardAmount * 0.2f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");

        }

        //if its between 61 and 70(so 10%)
        else if (InRange(randomNum, 61, 70))
        {
            //calculate how much to subtract and subtract it
            uint CalculatedAmount = rewardAmount - (uint)(rewardAmount * 0.2f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");

        }

        //if its between 71 and 80(so 10%)
        else if (InRange(randomNum, 71, 80))
        {
            //calculate how much to subtract and subtract it
            uint CalculatedAmount = rewardAmount - (uint)(rewardAmount * 0.4f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");
        }

        //if its between 81 and 90(so 10%)
        else if (InRange(randomNum, 81, 90))
        {
            //calculate how much to add and add it
            uint CalculatedAmount = rewardAmount + (uint)(rewardAmount * 0.4f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");
        }

        //if its between 91 and 95(so 5%)
        else if (InRange(randomNum, 91, 95))
        {
            //calculate how much to subtract and subract it
            uint CalculatedAmount = rewardAmount - (uint)(rewardAmount * 0.8f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");
        }

        //if its between 96 and 100(so 5%)
        else if (InRange(randomNum, 96, 100))
        {
            //calculate how much to add and add it
            uint CalculatedAmount = rewardAmount + (uint)(rewardAmount * 0.8f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");
        }

    }

    
    //check if a number is between two numbers
    bool InRange(int value, int min, int max)
    {
        return (value >= min && value <= max);
    }
}
