using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    //public Animator camAnim;
    //public Animator playerAnim;

    private float attackCoolDown = 0f;

    public float defaultAttackCoolDown = 0.5f;
    public float attackRange;
    //public float attackRangeX;
    //public float attackRangeY;
    public int damage = 1;

    private void Update()
    {
        if(attackCoolDown <= 0)//then you can attack
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                attackCoolDown = defaultAttackCoolDown;
                Debug.Log("swung attack");
                //camAnim.SetTrigger("shake");
                //playerAnim.SetTrigger("attack");

                //                                     orOverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY));
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
        else
        {
            attackCoolDown -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
