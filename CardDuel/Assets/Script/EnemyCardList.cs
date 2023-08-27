using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardList : MonoBehaviour
{
    public List<string> enemyCardList = new List<string>();
    string[] cards = { "up", "down", "left", "right", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
    // Start is called before the first frame update
    void Start()
    {
        EnemyCardSelect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyCardSelect()
    {
        enemyCardList.Clear();
        for(int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, 4);
            enemyCardList.Add(cards[index]);
        }
        FindObjectOfType<CardOpen>().GetEnemyCardList(enemyCardList);
    }
}
