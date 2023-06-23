using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public CameraShake cameraShake;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Vector2 Position { get; set; }

    // Start is called before the first frame update

    public Player(float x, float y)
    {
        Position = new Vector2(x, y);
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        SceneManager.LoadScene("Game Over Screen");
    }
}





