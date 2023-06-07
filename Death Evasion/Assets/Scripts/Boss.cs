using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] GameObject laser;
    [SerializeField] float laserSpeed;
    [SerializeField] bool isRight = false;
    [SerializeField] float cooldown;
    [SerializeField] int health = 50;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        timer -= Time.deltaTime;
        if( timer <= 0)
        { Attack(); timer = cooldown; }
    }
    private void Follow()
    {
        if (player.position.x < transform.position.x)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0);
            isRight = false;
        }
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0);
            isRight = true;
        }
    }

    private void Attack()
    {
        if (isRight)
        {
            var laserInstance = Instantiate(laser, transform.position, transform.rotation);
            laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);

        }
        else
        {
            var laserInstance = Instantiate(laser, transform.position, transform.rotation);
            laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
        }
    }
    public int GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer otherDamageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (otherDamageDealer == null) { return; }
        ProcessHit(otherDamageDealer);
        if (health <= 0)
        {
            Die();
        }
    }

    private void ProcessHit(DamageDealer otherDamageDealer)
    {
        health -= otherDamageDealer.GetDamage();
    }

    private void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(16);
    }
}