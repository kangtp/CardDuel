using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public List<string> cardList = new List<string>();
    public GameObject map;
    
    public void ClickUpButton()
    {
        if (cardList.Count == 3)
            return;

        cardList.Add("up");
    }

    public void ClickDownButton()
    {
        if (cardList.Count == 3)
            return;

        cardList.Add("down");
    }

    public void ClickLeftButton()
    {
        if (cardList.Count == 3)
            return;

        cardList.Add("left");
        
    }

    public void ClickRightButton()
    {
        if (cardList.Count == 3)
            return;

        cardList.Add("right");
    }

    public void ClickNumButton(string num)
    {
        if (cardList.Count == 3)
            return;

        cardList.Add(num);
    }

    public void ClearButton()
    {
        cardList.Clear();
    }

    public void DoneButton()
    {
        //Do not run if the card list is not full
        if (cardList.Count != 3)
            return;

        //카드 리스트 정보 보내기
        FindObjectOfType<CardOpen>().GetPlayerCardList(cardList);
        GameObject.Find("CardSelectUI").SetActive(false);
    }
}
