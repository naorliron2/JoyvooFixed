using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTile : TileBASE
{
    [SerializeField] uint rewardAmount;
    public override void LandedOn(Player playerThatLanded)
    {
        playerThatLanded.AddMoney(rewardAmount);
    }
}
