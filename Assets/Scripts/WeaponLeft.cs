using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLeft : MonoBehaviour
{
    [SerializeField] private float speedTransform = 3f;
    [SerializeField] private float speedRotate= 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, speedRotate * Time.deltaTime, 0);
        transform.Translate(Vector2.right * speedTransform * Time.deltaTime);
        if (transform.position.y>10)
        {
            Destroy(this.gameObject);
        }
    }
}
