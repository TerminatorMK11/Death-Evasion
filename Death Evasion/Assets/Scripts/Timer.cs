using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject, 1.5f);
    }
}
