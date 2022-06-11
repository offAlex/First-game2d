using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public bool moveingUp;
    [SerializeField] private int role;

    void Start()
    {
        role = Random.Range(0,2);
        if (role == 1)
        {
            moveingUp = false;
        }
        else 
        {
            moveingUp = true;
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y>3.5f)
        {
            moveingUp = false;
            speed = Random.Range(0.02f, 0.1f);
        }
        if (transform.position.y<-4.5)
        {
            moveingUp = true;
            speed = Random.Range(0.02f, 0.1f);
        }

        if(moveingUp)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y + speed);
        }
        else
        {
            transform.position = new Vector2(transform.position.x,transform.position.y - speed);
        }
    }

}
