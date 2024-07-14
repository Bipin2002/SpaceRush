using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public int minHealth = 0;
    private PageLoader2 pageChanger;

    void Start()
    {
        pageChanger = FindObjectOfType<PageLoader2>();
        health = maxHealth;
        UpdateHealthDisplay(); 
    }

    public void TakeDamage(int damage)
    {
        if (health > minHealth)
        {
            health -= damage;
            UpdateHealthDisplay();
        }
        if (health <= minHealth)
        {

            if (gameObject.CompareTag("Player"))
            {
                pageChanger.GameOver();
            }
            else
            {
               
                Destroy(gameObject); 
            }


        }
    }

    public void IncreaseHealth(int value)
    {
        if (health < maxHealth)
        {
            health += value;
            UpdateHealthDisplay();
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        if (pageChanger != null)
        {
            pageChanger.UpdateHealthDisplay(health);
        }
    }
}
