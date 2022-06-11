using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{   
    [SerializeField] public Text textCoins;
    [SerializeField] public Text textRecords;
    [SerializeField] public int score;
    [SerializeField] public int coins;

    void Start()
    {      
        //PlayerPrefs.DeleteAll();  for delele records
    }

    void Update()
    {   
        coins = PlayerController.money;
        textCoins.text = "" + coins;
        if (coins>score)
        {   score = coins;
            PlayerPrefs.SetInt("saveScore", score);
            PlayerPrefs.Save();
            textRecords.text = "" + PlayerController.money;
            
        }
        score = PlayerPrefs.GetInt("saveScore", score);
        textRecords.text = "" + score;
    }
}
