using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Sprite[] sprites;
    public Image[] images;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<ButtonManager>().cardList.Count != 0)
        {
            int i = 0;
            foreach (string card in FindObjectOfType<ButtonManager>().cardList)
            {
                
                if (card == "1")
                {
                    images[i].sprite = sprites[0];
                }
                else if (card == "2")
                {
                    images[i].sprite = sprites[1];
                }
                else if (card == "3")
                {
                    images[i].sprite = sprites[2];
                }
                else if (card == "4")
                {
                    images[i].sprite = sprites[3];
                }
                else if (card == "5")
                {
                    images[i].sprite = sprites[4];
                }
                else if (card == "6")
                {
                    images[i].sprite = sprites[5];
                }
                else if (card == "7")
                {
                    images[i].sprite = sprites[6];
                }
                else if (card == "8")
                {
                    images[i].sprite = sprites[7];
                }
                else if (card == "9")
                {
                    images[i].sprite = sprites[8];
                }
                else if (card == "10")
                {
                    images[i].sprite = sprites[9];
                }
                else if (card == "11")
                {
                    images[i].sprite = sprites[10];
                }
                else if (card == "12")
                {
                    images[i].sprite = sprites[11];
                }
                else if (card == "up")
                {
                    images[i].sprite = sprites[12];
                }
                else if (card == "down")
                {
                    images[i].sprite = sprites[13];
                }
                else if (card == "left")
                {
                    images[i].sprite = sprites[14];
                }
                else if (card == "right")
                {
                    images[i].sprite = sprites[15];
                }
                i++;
            }
        }
        else
        {
            images[0].sprite = sprites[16];
            images[1].sprite = sprites[16];
            images[2].sprite = sprites[16];
        }

    }
}
