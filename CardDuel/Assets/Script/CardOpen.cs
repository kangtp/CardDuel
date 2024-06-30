using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOpen : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private int playerPosition = 5;
    private int enemyPosition = 8;
    List<string> playerCardList;
    List<string> enemyCardList;
    private int i = 0;
    private bool isOpening = false; //카드 오픈 여부
    private bool endTurn = false;
    public GameObject cardSelectUI;

    private void Update()
    {
        if (isOpening)  //카드발동이 true이면
        {
            StartCoroutine(CardActivate());    //코루틴을 시작하여 카드 발동 함수 실행
            isOpening = false;
        }
    }

    void ChangeScene()
    {
        cardSelectUI.SetActive(true);
        FindObjectOfType<EnemyCardList>().EnemyCardSelect();
        FindObjectOfType<CardController>().ClearButton();
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
    IEnumerator CardActivate()
    {
        for (int i = 0; i < 3; i++)
        {
            endTurn = false;
            StartCoroutine(PlayerTurn(i));
            yield return new WaitUntil(() => endTurn);  //endTurn이 true가 될 때까지 대기
        }
        Invoke("ChangeScene", 3f);
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
        Debug.Log("Attack " + num);
        GameObject.Find("Block" + num).GetComponent<Attack>().HitCheck(target);
    }

    IEnumerator PlayerTurn(int i)
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

        StartCoroutine(EnemyTurn(i));
    }

    IEnumerator EnemyTurn(int i)
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
        endTurn = true;

    }
    
}
