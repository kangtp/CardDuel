using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public List<string> cardList = new List<string>();
    public GameObject map;
    
    public List<string> getCardList()
    {
        return cardList;
    }

    public void ClickUpButton()
    {
        AudioManager.instance.PlaySFX("cardSelect");
        if (cardList.Count == 3)
            return;

        cardList.Add("up");
    }

    public void ClickDownButton()
    {
        AudioManager.instance.PlaySFX("cardSelect");
        if (cardList.Count == 3)
            return;

        cardList.Add("down");
    }

    public void ClickLeftButton()
    {
        AudioManager.instance.PlaySFX("cardSelect");
        if (cardList.Count == 3)
            return;

        cardList.Add("left");
        
    }

    public void ClickRightButton()
    {
        AudioManager.instance.PlaySFX("cardSelect");
        if (cardList.Count == 3)
            return;

        cardList.Add("right");
    }

    public void ClickNumButton(string num)
    {
        AudioManager.instance.PlaySFX("cardSelect");
        if (cardList.Count == 3)
            return;

        cardList.Add(num);
    }

    public void ClearButton()
    {
        AudioManager.instance.PlaySFX("cardClear");
        cardList.Clear();
    }

    public void DoneButton()
    {
        //Do not run if the card list is not full
        if (cardList.Count != 3)
        {
            AudioManager.instance.PlaySFX("DoneFail");
            return;
        }
        //카드 리스트 정보 보내기
        AudioManager.instance.PlaySFX("cardDone");
        FindObjectOfType<CardOpen>().GetPlayerCardList(cardList);
        GameObject.Find("PlayerDeck").gameObject.GetComponent<Deck>().Setting();
        GameObject.Find("CardSelectUI").SetActive(false);
    }
}
