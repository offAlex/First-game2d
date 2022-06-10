using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private bool moveing;

    void FixedUpdate()
    {
        if (transform.position.y>3.5f){
            moveing = false;
        }
        if (transform.position.y<-4.5){
            moveing = true;
        }

        if(moveing){
            transform.position = new Vector2(transform.position.x,transform.position.y + speed);
        }
        else{
            transform.position = new Vector2(transform.position.x,transform.position.y - speed);
        }
    }

}
