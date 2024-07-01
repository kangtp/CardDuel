using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 5;
    private int index = 0;
    public GameObject hearts;

    public void GetDamage()
    {
        health -= 1;
        hearts.transform.GetChild(index).gameObject.SetActive(false);
        index += 1;
        DeathCheck();
    }

    public void DeathCheck()
    {
        if(health <= 0)
        {
            Debug.Log("Game Over: Player win");
            FindObjectOfType<GameManager>().GameOverWin();
        }
    }
}
