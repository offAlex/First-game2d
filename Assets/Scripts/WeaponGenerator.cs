using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{   
    public Transform weaponLeft;
    public Transform weaponRight;
    [SerializeField] private int change;

    // Update is called once per frame
    void FixedUpdate()
    {
        change = Random.Range(0,500);
        if (change == 1)
        {
            Instantiate(weaponLeft, new Vector3 (-10 ,Random.Range(-4,4),0),Quaternion.identity);
        }
        else if (change == 2)
        {
            Instantiate(weaponRight, new Vector3 (10 ,Random.Range(-4,4),0),Quaternion.identity);
        }

    }
}
