using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject explosionPrefab;
    private Coroutine loseHealthCoroutine; 

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(LoseHealthOverTime());
    }

    IEnumerator LoseHealthOverTime()
    {
        while (true) // Changez ici pour une boucle infinie
        {
            if (currentHealth <= 0)
            {
                TriggerExplosion();
                yield return new WaitForSeconds(2); // Petite pause avant de recommencer
                ResetToSavedPoint();
                continue; // Continue la boucle
            }

            yield return new WaitForSeconds(1);
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    void TriggerExplosion()
    {
        if (explosionPrefab != null)
        {
            GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explosionInstance.SetActive(true);
            Destroy(explosionInstance, 2f);
        }
    }

    void ResetToSavedPoint()
    {
        var manager = FindObjectOfType<CheckpointManager>();
        Transform checkpointTransform = manager.GetActiveCheckpoint();

        if (checkpointTransform != null)
        {
            transform.position = checkpointTransform.position;
            transform.rotation = checkpointTransform.rotation;
        }

        ResetHealth();
        if (loseHealthCoroutine != null)
        {
            StopCoroutine(loseHealthCoroutine);
        }
        loseHealthCoroutine = StartCoroutine(LoseHealthOverTime());
    }
}
