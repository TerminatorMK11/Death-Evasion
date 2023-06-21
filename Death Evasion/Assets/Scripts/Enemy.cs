using UnityEngine;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using Quaternion = UnityEngine.Quaternion;


public class Enemy : MonoBehaviour
{
    
    public int health = 100;
    private Vector2 position;
    private float speed;
    public GameObject deathEffect;





    private void Start()
    {
        position = transform.position;
        speed = 1.5f;
    }

    private void Update()
    {
        Vector2 playerPosition = GetRandomPlayerPosition();
        Vector2 direction = CalculateDirection(playerPosition);
        MoveTowardsPlayer(direction);
        Debug.Log($"Enemy Position: {position.x}, {position.y}");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private Vector2 GetRandomPlayerPosition()
    {
        return new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }

    private Vector2 CalculateDirection(Vector2 playerPosition)
    {
        return playerPosition - position;
    }

    private void MoveTowardsPlayer(Vector2 direction)
    {
        position += direction * speed * Time.deltaTime;
    }
}
