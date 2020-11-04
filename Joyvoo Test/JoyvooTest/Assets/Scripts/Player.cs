using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] TileBASE currentTile;
    [SerializeField] float TimeToMoveToNode;
    public playerColor playerColor;
    [Header("References")]
    [SerializeField] TMP_Text cashText;
    [SerializeField] GameObject playingNow;
    [Header("Debug Info")]
    [SerializeField] int money;
    [SerializeField] bool ismoving;
    [SerializeField] bool hasLost;

    bool firstRun = true;
    private const float DISTANCE_CUTOFF = 0.07f;

    /// <summary>
    /// Sets the status of the play now message
    /// </summary>
    /// <param name="status"></param>
    public void setPlayingNow(bool status)
    {
        playingNow.SetActive(status);
    }
    
    /// <summary>
    /// Return true if the player is currently moving, and false it it is not
    /// </summary>
    /// <returns></returns>
    public bool IsMoving()
    {
        return ismoving;
    }
    /// <summary>
    /// Set the players is moving status
    /// </summary>
    /// <param name="status"></param>
    public void SetIsMoving(bool status)
    {
        ismoving = status;
    }
    /// <summary>
    /// add money to the player
    /// </summary>
    /// <param name="amount"></param>
    public void AddMoney(uint amount)
    {
        money += (int)amount;
        UpdateCash();
    }
    //updates the cash UI
    private void UpdateCash()
    {
        cashText.text = money + "$";
    }
    /// <summary>
    /// Subtract money from the player
    /// </summary>
    /// <param name="amount"></param>
    public void SubtractMoney(uint amount)
    {
        money -= (int)amount;
        UpdateCash();

    }
    /// <summary>
    /// returns the amount of money a player has
    /// </summary>
    /// <returns></returns>
    public int getMoney()
    {
        return money;
    }
    /// <summary>
    /// Moves the player forward on the board an amount of tiles equivalant to the diceCount
    /// </summary>
    /// <param name="diceCount"></param>
    public void MoveTile(int diceCount)
    {
        //Since this is a recoursive function we need to check that we havnt gotten to our last step
        if (diceCount <= 0)
        {
            //if we have and this is the final tile
            //set is moving to false
            ismoving = false;
            //reset first run
            firstRun = true;
            // call LandedOn while passing on this pPlayer script
            currentTile.LandedOn(this);
            //and change the turn
            PlayerManager.instance.ChangeTurn();
            return;
        }
        //as long as we're moving, is moving will be on, this will stop us from being able to roll the dice again while a player is moving
        ismoving = true;
        //and staret the coroutin that moves us to the next tile
        StartCoroutine(MoveToNextTile(diceCount));
    }
    /// <summary>
    /// Moves to the next tile, and calls moveTile again but with dieRoll adjusted for the move
    /// </summary>
    /// <param name="diceCount"></param>
    /// <returns></returns>
    /// 
    IEnumerator MoveToNextTile(int diceCount)
    {
        //if this was the first time we went into the function, we would call the block we started on(so if we landed on start last turn, when we move this turn we would call it again)
        //this should stop that
        if (!firstRun)
            //call the Passby on the tile we landed on(currently only relevant to StartTile)
            currentTile.PassedBy(this);

        //a velocity vector used by smoothDamp
        Vector3 velocity = Vector3.zero;
        //keeps the while loop going until we reach our destination
        while (true)
        {
            //Smooth damping to the next tile
            transform.position = Vector3.SmoothDamp(transform.position, currentTile.nextTile.tileTransform.position, ref velocity, TimeToMoveToNode);
            //since we're SmoothDamping from our position to the next tile each frame, the last few frames take alot longer to move a very little amount
            //because of that we check if we're close enough, and if we are, we exit the loop
            if (Vector3.Distance(transform.position, currentTile.nextTile.tileTransform.position) < DISTANCE_CUTOFF)
                break;
            yield return null;

        }
        //if we reached this line, we have moved to the next tile, so we set the current tile to nextTile
        currentTile = currentTile.nextTile;
        firstRun = false;
        //call the MoveTile function again but this time wih one less diceCount, so we can recursively move over all our tiles
        MoveTile(diceCount - 1);
    }
    private void Start()
    {
        cashText.text = money + "$";
    }
    /// <summary>
    /// returns the player's loss status
    /// </summary>
    /// <returns></returns>
    public bool CheckForLoss()
    {
        if (money <= 0 && !hasLost)
        {
            hasLost = true;
            //we update the player manager that another player has lost
            PlayerManager.instance.UpdateLoss();
        }
        return hasLost;

    }
    private void Update()
    {
        CheckForLoss();
    }
}
public enum playerColor { blue, red }