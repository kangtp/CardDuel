using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCardList : MonoBehaviour
{
    public List<string> enemyCardList = new List<string>();
    string[] cards = { "up", "down", "left", "right"};
    int[] candi = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        EnemyCardSelect();
    }

    public List<string> getCardList()
    {
        return enemyCardList;
    }

    public void EnemyCardSelect()
    {
        enemyCardList.Clear();

        int playerPosition = FindObjectOfType<CardOpen>().GetPlayerPosition();

        //2 attack card
        for(int i = 0; i < 2; i++)
        {
            AttackCandidate(playerPosition);
            int index = Random.Range(0, 5);
            enemyCardList.Add(candi[index].ToString());
        }

        //1 move card
        enemyCardList.Add(cards[Random.Range(0, 4)]);

        enemyCardList = ShuffleList(enemyCardList);

        FindObjectOfType<CardOpen>().GetEnemyCardList(enemyCardList);
        GameObject.Find("EnemyDeck").gameObject.GetComponent<Deck>().Setting();
    }

    public void AttackCandidate(int index)
    {
        
        if(index -4 <= 0)
        {
            candi[0] = index;
        }
        else
        {
            candi[0] = index - 4;
        }
        if(index + 4  >= 13)
        {
            candi[1] = index;
        }
        else
        {
            candi[1] = index + 4;
        }
        if (index % 4 == 1)
        {
            candi[2] = index;
        }
        else
        {
            candi[2] = index - 1;
        }
        if(index % 4 == 0)
        {
            candi[3] = index;
        }
        else
        {
            candi[3] = index + 1;
        }
        candi[4] = index;

    }

    private List<T> ShuffleList<T>(List<T> list)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < list.Count; ++i)
        {
            random1 = Random.Range(0, list.Count);
            random2 = Random.Range(0, list.Count);

            temp = list[random1];
            list[random1] = list[random2];
            list[random2] = temp;
        }

        return list;
    }
}
