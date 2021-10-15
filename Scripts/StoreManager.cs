using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public void On100KPurchaseComplete()
    {
        MoneyManager.instance.AddMoney(100000);
    }


    public void OnRemoveAdsPurchaseComplete()
    {
        PlayerPrefs.SetInt("adsRemoved", 1);

       }



    public void OnhireManagerPurchaseComplete()
    {
        FindObjectOfType<ProfitCollector>().HireManager();

    }

    

}
