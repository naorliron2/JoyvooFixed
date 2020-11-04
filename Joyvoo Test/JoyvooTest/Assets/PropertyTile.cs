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
            if (Cost < playerThatLanded.getMoney())
            {
                ApplyOwnership(playerThatLanded);
                playerThatLanded.SubtractMoney(Cost);
                IngameUiManager.instance.PopUp("Sold! to " + PlayerManager.instance.currentPlayer.gameObject.name + " for " + Cost + "$");
            }
        }
        else
        {
            if (ownedBy != playerThatLanded)
            {
                IngameUiManager.instance.PopUp("Not your property, owner gains " + Cost * 0.5 + "$");
                foreach (var player in PlayerManager.instance.players)
                {
                    if (player == playerThatLanded)
                    {
                        player.SubtractMoney((uint)(Cost * 0.5f));
                    }
                    else
                    {
                        player.AddMoney((uint)(Cost * 0.5f));
                    }
                }
            }
        }

    }
    void ApplyOwnership(Player PlayerToOwn)
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
