using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLeft : MonoBehaviour
{
    [SerializeField] private float speedTransform = 3f;
    [SerializeField] private float speedRotate= 2f;

    void Update()
    {
        if (transform.position.x>10f)
        {
            Destroy(this.gameObject);
        }
    }


    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, speedRotate * Time.deltaTime));
        transform.Translate(Vector2.right * speedTransform * Time.deltaTime);
    }
}
