using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsDelited : MonoBehaviour
{   

    
    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(DeliteCoins());
    }

        IEnumerator DeliteCoins()
    {   
        yield return new WaitForSeconds(7);

        Destroy(this.gameObject);
    }
}
