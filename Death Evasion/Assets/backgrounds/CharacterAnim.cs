using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("runLeft", true);
        }
        else
        {
            anim.SetBool("runLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetTrigger("jump");
        }
    }
}
