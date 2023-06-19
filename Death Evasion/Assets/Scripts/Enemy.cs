using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Random = System.Random;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    private Vector2 position;
    private float speed;

    public GameObject deathEffect;

    public Enemy(float x, float y, float speed)
    {
        position = new Vector2(x, y);
        this.speed = speed;
    }

    public void Update(Vector2 playerPosition)
    {
        // Calculate direction vector towards the player
        Vector2 direction = Vector2.Normalize(playerPosition - position);

        // Move towards the player based on the direction and speed
        position += direction * speed;

        // Output the updated position
        Console.WriteLine($"Enemy Position: {position.x}, {position.y}");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();

        }


    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public class Player
    {
        public Vector2 Position { get; set; }

        public Player(float x, float y)
        {
            Position = new Vector2(x, y);
        }
    }

    public class Game
    {
        private Player player;
        private Enemy enemy;

        public Game()
        {
            player = new Player(0, 0);
            enemy = new Enemy(10, 10, 1.5f);
        }

        public void Update()
        {
            // Assume the player's position is being updated elsewhere in the game
            // In this example, we update the player's position to a random value
            player.Position = new Vector2(GetRandomFloat(-10, 10), GetRandomFloat(-10, 10));

            // Update the enemy based on the player's position
            enemy.Update(player.Position);
        }

        private float GetRandomFloat(float min, float max)
        {
            Random random = new Random();
            return (float)(random.NextDouble() * (max - min) + min);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();

            // Run the game loop
            while (true)
            {
                game.Update();
            }
        }

    }
}
