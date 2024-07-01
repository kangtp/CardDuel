using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<string> cardList;
    public GameObject[] cards;
    public Sprite[] sprites;

    public void Setting()
    {
        if(gameObject.tag == "Player")
        {
            cardList = FindObjectOfType<CardController>().getCardList();
        }
        else if(gameObject.tag == "Enemy")
        {
            cardList = FindObjectOfType<EnemyCardList>().getCardList();
        }

        if(cardList != null)
        {
            int i = 0;
            foreach(string card in cardList)
            {
                if (card == "1")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[0];
                }
                else if (card == "2")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[1];
                }
                else if (card == "3")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[2];
                }
                else if (card == "4")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[3];
                }
                else if (card == "5")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[4];
                }
                else if (card == "6")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[5];
                }
                else if (card == "7")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[6];
                }
                else if (card == "8")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[7];
                }
                else if (card == "9")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[8];
                }
                else if (card == "10")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[9];
                }
                else if (card == "11")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[10];
                }
                else if (card == "12")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[11];
                }
                else if (card == "up")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[12];
                }
                else if (card == "down")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[13];
                }
                else if (card == "left")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[14];
                }
                else if (card == "right")
                {
                    cards[i].GetComponent<SpriteRenderer>().sprite = sprites[15];
                }
                i++;
            }
        }
    }
}
