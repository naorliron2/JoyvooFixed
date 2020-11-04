using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardTile : TileBASE
{
    [SerializeField] uint rewardAmount;
    public override void LandedOn(Player playerThatLanded)
    {
        int randomNum = Random.Range(1, 101);
        if (InRange(randomNum, 1, 50))
        {
            playerThatLanded.AddMoney(rewardAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + rewardAmount + "$");

        }

        else if (InRange(randomNum, 51, 60))
        {
            uint CalculatedAmount = rewardAmount + (uint)(rewardAmount * 0.2f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");

        }

        else if (InRange(randomNum, 61, 70))
        {
            uint CalculatedAmount = rewardAmount - (uint)(rewardAmount * 0.2f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");

        }

        else if (InRange(randomNum, 71, 80))
        {
            uint CalculatedAmount = rewardAmount - (uint)(rewardAmount * 0.4f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");
        }

        else if (InRange(randomNum, 81, 90))
        {
            uint CalculatedAmount = rewardAmount + (uint)(rewardAmount * 0.4f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");
        }

        else if (InRange(randomNum, 91, 95))
        {
            uint CalculatedAmount = rewardAmount - (uint)(rewardAmount * 0.8f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");
        }

        else if (InRange(randomNum, 96, 100))
        {
            uint CalculatedAmount = rewardAmount = (uint)(rewardAmount * 0.8f);
            playerThatLanded.AddMoney(CalculatedAmount);
            IngameUiManager.instance.PopUp("You have been rewarded " + CalculatedAmount + "$");
        }

    }

    bool InRange(int value, int min, int max)
    {
        return (value >= min && value <= max);
    }
}
