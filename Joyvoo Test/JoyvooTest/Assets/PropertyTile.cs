using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyTile : TileBASE
{
    [SerializeField] Player ownedBy;
    [SerializeField] uint Cost;
    [SerializeField] GameObject ownedByBlue;
    [SerializeField] GameObject ownedByRed;

    public override void LandedOn(Player playerThatLanded)
    {
        if (ownedBy == null)
        {
            if (Cost <= playerThatLanded.getMoney())
            {
                TransferOwnership(playerThatLanded);
                playerThatLanded.SubtractMoney(Cost);
            }
        }
        else
        {
            //apply penalty
        }
    }
    void TransferOwnership(Player PlayerToOwn)
    {
        ownedBy = PlayerToOwn;
        switch (PlayerToOwn.playerColor)
        {
            case playerColor.blue:
                ownedByBlue.SetActive(true);
                break;
            case playerColor.red:
                ownedByRed.SetActive(true);
                break;
            default:
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
