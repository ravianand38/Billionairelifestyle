using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBounus : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            

            MoneyManager.instance.AddMoney(1000);

            Destroy(gameObject);

        }
        
        
           
        
    }
}
