using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public Transform coins;
    [SerializeField] private int change;

    // Update is called once per frame
    void FixedUpdate()
    {
        change = Random.Range(0,300);
        if (change == 1)
        {
            Instantiate(coins, new Vector3 (Random.Range(-8,8),Random.Range(-4,4),0),Quaternion.identity);
        }
    }

}
