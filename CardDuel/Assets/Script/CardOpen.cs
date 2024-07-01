using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOpen : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject cardSelectUI;

    List<string> playerCardList;
    List<string> enemyCardList;

    private int playerPosition = 5;
    private int enemyPosition = 8;
    
    private bool isOpening = false; //카드 오픈 여부
    private bool endTurn = false;

    public Vector3 originScale;
    public Vector3 maxScale = new Vector3(8, 8, 8);
    public float scaleSpeed = 0.2f; // 크기 조정 속도

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

        yield return new WaitForSeconds(2f);
        //카드 다시 덮어놓기
        for (int j = 0; j < 3; j++)
        {
            GameObject.Find("PlayerCover").transform.GetChild(j).gameObject.SetActive(true);
            GameObject.Find("EnemyCover").transform.GetChild(j).gameObject.SetActive(true);
        }
        Invoke("ChangeScene", 1f);
    }

    void MoveUp(GameObject target)
    {
        AudioManager.instance.PlaySFX("Move");
        if (target == player)
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
        AudioManager.instance.PlaySFX("Move");
        if (target == player)
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
        AudioManager.instance.PlaySFX("Move");
        if (target == player)
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
        AudioManager.instance.PlaySFX("Move");
        if (target == player) 
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
        GameObject.Find("Block" + num).GetComponent<AttackManager>().HitCheck(target);
    }

    IEnumerator PlayerTurn(int i)
    {
        //카드 공개
        yield return new WaitForSeconds(2f);
        AudioManager.instance.PlaySFX("CardOpen");
        GameObject.Find("PlayerCover").transform.GetChild(i).gameObject.SetActive(false);
        StartCoroutine(CardOpenEffect("player",i));


        //동작 실행
        yield return new WaitForSeconds(1.5f);

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
            yield return new WaitForSeconds(1.5f);
        }

        StartCoroutine(EnemyTurn(i));
    }

    IEnumerator EnemyTurn(int i)
    {
        //카드 공개
        yield return new WaitForSeconds(2f);
        AudioManager.instance.PlaySFX("CardOpen");
        GameObject.Find("EnemyCover").transform.GetChild(i).gameObject.SetActive(false);
        StartCoroutine(CardOpenEffect("enemy",i));

        //동작 실행
        yield return new WaitForSeconds(1.5f);

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
            yield return new WaitForSeconds(1.5f);
        }

        endTurn = true;

    }

    IEnumerator CardOpenEffect(string player, int i)
    {
        GameObject target = null;

        if(player == "player")
            target = GameObject.Find("PlayerDeck").transform.GetChild(i).gameObject;
        else if(player == "enemy")
            target = GameObject.Find("EnemyDeck").transform.GetChild(i).gameObject;

        originScale = target.transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < scaleSpeed)
        {
            // 선형 보간을 사용하여 크기를 조정
            target.transform.localScale = Vector3.Lerp(originScale, maxScale, elapsedTime / scaleSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;

        while (elapsedTime < scaleSpeed)
        {
            // 선형 보간을 사용하여 크기를 조정
            target.transform.localScale = Vector3.Lerp(maxScale, originScale, elapsedTime / scaleSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    
}
