using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator not found on " + gameObject.name);
        }
        else
        {
            Debug.Log("Animator found on " + gameObject.name);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        if (animator != null)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            Debug.LogError("Animator is null in Die method");
        }
        // Opcjonalnie, mo¿esz dodaæ opóŸnienie przed zniszczeniem obiektu, aby umo¿liwiæ odtworzenie animacji œmierci
        // Destroy(gameObject, 1.5f); // Zniszcz obiekt po 1.5 sekundzie (dopasuj do d³ugoœci animacji œmierci)
    }
}