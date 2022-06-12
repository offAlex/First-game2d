using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    public Transform weapon;
    [SerializeField] private int change;

    // Update is called once per frame
    void FixedUpdate()
    {
        change = Random.Range(0,500);
        if (change == 1)
        {
            Instantiate(weapon, new Vector3 (Random.Range(-8,8),Random.Range(-4,4),0),Quaternion.identity);
        }

    }
}
