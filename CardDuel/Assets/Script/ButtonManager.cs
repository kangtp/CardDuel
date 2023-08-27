using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
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
        //카드 리스트 정보 보내기
        //GameObject.Find("Map").SetActive(true);
        //map.SetActive(true);
        FindObjectOfType<CardOpen>().GetPlayerCardList(cardList);
        GameObject.Find("CardSelectUI").SetActive(false);
    }
}
