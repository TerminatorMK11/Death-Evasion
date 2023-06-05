using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] int numOfEnemies;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        if (this.gameObject.tag == "Enemy")
        {
            SubtractEnemy();
        }
        Destroy(gameObject);
    }

    public void SubtractEnemy()
    {
        numOfEnemies--;
    }
    



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
