using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] TileBASE currentTile;
    public playerColor playerColor;
    [SerializeField] float TimeToMoveToNode;
    [SerializeField]bool ismoving;
    [SerializeField] TMP_Text cashText;
    public void MoveTile(int diceCount)
    {
        if (diceCount <= 0)
        {
            currentTile.LandedOn(this);
            ismoving = false;
            PlayerManager.instance.ChangeTurn();
            return;
        }
        ismoving = true;
        StartCoroutine(MoveToNextTile(diceCount));
    }
    public bool IsMoving()
    {
        return ismoving;
    }
    public void AddMoney(uint amount)
    {
        money += (int)amount;
        UpdateCash();
    }

    private void UpdateCash()
    {
        cashText.text = money + "$";
    }

    public void SubtractMoney(uint amount)
    {
        money -= (int)amount;
        UpdateCash();

    }
    public int getMoney()
    {
        return money;
    }
    IEnumerator MoveToNextTile(int diceCount)
    {
        Debug.Log("startedRoutin");
        float t = 0;
        Vector3 velocity = Vector3.zero;
        while (true)
        {
            
            //transform.position = Vector3.Lerp(currentTile.transform.position, currentTile.nextTile.transform.position, t);
            transform.position = Vector3.SmoothDamp(transform.position, currentTile.nextTile.transform.position, ref velocity, TimeToMoveToNode);
            if (Vector3.Distance(transform.position,currentTile.nextTile.transform.position)< 0.1f)
                break;
            yield return null;

        }
        currentTile = currentTile.nextTile;
        MoveTile(diceCount - 1);
    }
    private void Start()
    {
        
        cashText.text = money + "$";
    }
}
public enum playerColor { blue, red }