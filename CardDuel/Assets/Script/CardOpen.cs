using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOpen : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private int playerPosition = 5;
    private int enemyPosition = 8;
    private float timer = 0.0f;
    List<string> playerCardList;
    List<string> enemyCardList;
    private int i = 0;
    private bool isOpening = false; //카드 오픈 여부
    public GameObject cardSelectUI;

    private void Update()
    {
        if (isOpening)  //카드발동이 true이면
        {
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                CardActivate(i);    //카드 발동 함수 실행
                timer = 0;
                i++;
            }
            //after activating 3 card, then stop.
            if (i >= 3)
            {
                isOpening = false;
                i = 0;
                timer = 0;
                
                
                Invoke("ChangeScene", 3f);
            }
        }
    }

    void ChangeScene()
    {
        cardSelectUI.SetActive(true);
        //FindObjectOfType<EnemyCardList>().EnemyCardSelect();
        //playerCardList.Clear();
    }

    //get player card list
    public void GetPlayerCardList(List<string> _cardList)
    {
        playerCardList = _cardList;
        isOpening = true;   //card open start
    }

    //get enemy card list
    public void GetEnemyCardList(List<string> _cardList)
    {
        enemyCardList = _cardList;
        for(int i = 0; i < 3; i++)
        {
            Debug.Log(enemyCardList[i]);
        }
    }

    //card open function
    void CardActivate(int i)
    {
        StartCoroutine(PlayerTurn1(i));
    }

    void PlayerTurn()
    {
        if (playerCardList[i] == "up")
        {
            MoveUp(player);
        }
        else if (playerCardList[i] == "down")
        {
            MoveDown(player);
        }
        else if (playerCardList[i] == "left")
        {
            MoveLeft(player);
        }
        else if (playerCardList[i] == "right")
        {
            MoveRight(player);
        }
        else
        {
            Attack("enemy", playerCardList[i]);
        }
    }

    void EnemyTurn()
    {
        if (enemyCardList[i] == "up")
        {
            MoveUp(enemy);
        }
        else if (enemyCardList[i] == "down")
        {
            MoveDown(enemy);
        }
        else if (enemyCardList[i] == "left")
        {
            MoveLeft(enemy);
        }
        else if (enemyCardList[i] == "right")
        {
            MoveRight(enemy);
        }
        else
        {
            Attack("player", enemyCardList[i]);
        }
    }

    void MoveUp(GameObject target)
    {
        if(target == player)
        {
            if (playerPosition - 4 <= 0)
            {
                Debug.Log(target + " Blocked");
                return;
            }
            playerPosition -= 4;
            player.transform.position = GameObject.Find("PlayerAnchor" + playerPosition).transform.position;
            Debug.Log(target + " UP");
        }
        else if(target == enemy)
        {
            if (enemyPosition - 4 <= 0)
            {
                Debug.Log(target + " Blocked");
                return;
            }
            enemyPosition -= 4;
            enemy.transform.position = GameObject.Find("EnemyAnchor" + enemyPosition).transform.position;
            Debug.Log(target + " UP");
        }
    }

    void MoveDown(GameObject target)
    {
        if(target == player)
        {
            if (playerPosition + 4 >= 13)
            {
                Debug.Log(target + " Blocked");
                return;
            }
            playerPosition += 4;
            player.transform.position = GameObject.Find("PlayerAnchor" + playerPosition).transform.position;
            Debug.Log(target + " down");
        }
        else if(target == enemy)
        {
            if (enemyPosition + 4 >= 13)
            {
                Debug.Log(target + " Blocked");
                return;
            }
            enemyPosition += 4;
            enemy.transform.position = GameObject.Find("EnemyAnchor" + enemyPosition).transform.position;
            Debug.Log(target + " down");
        }
    }

    void MoveLeft(GameObject target)
    {
        if(target == player)
        {
            if (playerPosition % 4 == 1)
            {
                Debug.Log(target + " Blocked");
                return;
            }
            playerPosition -= 1;
            player.transform.position = GameObject.Find("PlayerAnchor" + playerPosition).transform.position;
            Debug.Log(target + " left");
        }
        else if(target == enemy)
        {
            if (enemyPosition % 4 == 1)
            {
                Debug.Log(target + " Blocked");
                return;
            }
            enemyPosition -= 1;
            enemy.transform.position = GameObject.Find("EnemyAnchor" + enemyPosition).transform.position;
            Debug.Log(target + " left");
        }
    }

    void MoveRight(GameObject target)
    {
        if(target == player) 
        {
            if (playerPosition % 4 == 0)
            {
                Debug.Log(target + " Blocked");
                return;
            }
            playerPosition += 1;
            player.transform.position = GameObject.Find("PlayerAnchor" + playerPosition).transform.position;
            Debug.Log(target + " right");
        }
        else if(target == enemy)
        {
            if (enemyPosition % 4 == 0)
            {
                Debug.Log(target + " Blocked");
                return;
            }
            enemyPosition += 1;
            enemy.transform.position = GameObject.Find("EnemyAnchor" + enemyPosition).transform.position;
            Debug.Log(target + " right");
        }
    }

    void Attack(string target, string num)
    {
        GameObject.Find("Block" + num).GetComponent<Attack>().HitCheck(target);
        Debug.Log("Attack " + num);
    }

    IEnumerator PlayerTurn1(int i)
    {
        yield return new WaitForSeconds(6f);

        if (playerCardList[i] == "up")
        {
            MoveUp(player);
        }
        else if (playerCardList[i] == "down")
        {
            MoveDown(player);
        }
        else if (playerCardList[i] == "left")
        {
            MoveLeft(player);
        }
        else if (playerCardList[i] == "right")
        {
            MoveRight(player);
        }
        else
        {
            Attack("enemy", playerCardList[i]);
        }

        StartCoroutine(EnemyTurn1(i));
    }

    IEnumerator EnemyTurn1(int i)
    {
        yield return new WaitForSeconds(3f);

        if (enemyCardList[i] == "up")
        {
            MoveUp(enemy);
        }
        else if (enemyCardList[i] == "down")
        {
            MoveDown(enemy);
        }
        else if (enemyCardList[i] == "left")
        {
            MoveLeft(enemy);
        }
        else if (enemyCardList[i] == "right")
        {
            MoveRight(enemy);
        }
        else
        {
            Attack("player", enemyCardList[i]);
        }
    }
    
}
