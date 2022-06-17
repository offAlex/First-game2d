using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRight : MonoBehaviour
{
    [SerializeField] private float speedTransform = 3f;
    [SerializeField] private float speedRotate= 2f;

    // Update is called once per frame

    void Update()
    {
        if (transform.position.x<-10f)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, speedRotate * Time.deltaTime));
        transform.Translate(Vector2.left * speedTransform * Time.deltaTime);
    }
}