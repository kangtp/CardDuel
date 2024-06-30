using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool enemyHit = false;
    public bool playerHit = false;
    

    public void HitCheck(string target)
    {
        if(target == "enemy" && enemyHit)
        {
            //enemy -1 heart
            FindObjectOfType<Enemy>().GetDamage();
            Debug.Log("enemy -1");
        }
        else if(target == "player" && playerHit)
        {
            //player -1 heart
            FindObjectOfType<Player>().GetDamage();
            Debug.Log("player -1");
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHit = true;
        }
        if (collision.CompareTag("Enemy"))
        {
            enemyHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHit = false;
        }
        if (collision.CompareTag("Enemy"))
        {
            enemyHit = false;
        }
    }
}