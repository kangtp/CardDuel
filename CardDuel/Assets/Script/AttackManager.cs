using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public bool enemyHit = false;
    public bool playerHit = false;
    

    public void HitCheck(string target)
    {
        //공격 모션
        StartCoroutine(BeforeAttackEffect(target));

    }

    IEnumerator BeforeAttackEffect(string target)
    {
        AudioManager.instance.PlaySFX("beforeAttack");
        transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Attack(target));
    }

    IEnumerator Attack(string target)
    {
        AudioManager.instance.PlaySFX("hit");
        if (target == "enemy" && enemyHit)
        {
            //enemy -1 heart
            FindObjectOfType<Enemy>().GetDamage();
            Debug.Log("enemy -1");
        }
        else if (target == "player" && playerHit)
        {
            //player -1 heart
            FindObjectOfType<Player>().GetDamage();
            Debug.Log("player -1");
        }
        yield return null;
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