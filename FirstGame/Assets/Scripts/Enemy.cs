using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;

    public Transform attackPoint;
    public float attackRange = 1f;
    public int attackDamage = 10;
    public float attackDelay = 0.5f;
    public float attackCooldown = 1.5f;
    public LayerMask playerLayer;

    private bool isAttacking = false;
    private float lastAttackTime = -Mathf.Infinity;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        animator.SetTrigger("Idle");
    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

            if (player != null && !isAttacking)
            {
                StartCoroutine(Attack(player));
            }
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.517f);
    }

    private IEnumerator Attack(Collider2D player)
    {
        isAttacking = true;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(attackDelay);

        Collider2D playerInRange = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        if (playerInRange != null)
        {
            playerInRange.GetComponent<Player>().TakeDamage(attackDamage);
        }

        lastAttackTime = Time.time;
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
