using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{   
    [SerializeField] public Text textCoins;

    // Update is called once per frame
    void Update()
    {   
        textCoins.text =""+ PlayerController.money;
    }
}
