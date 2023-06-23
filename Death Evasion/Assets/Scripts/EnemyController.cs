using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; 
    public float speed = 5f; 

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
