using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private Text moneyUI;

    public static MoneyManager instance;

        public BigInteger Money { get; private set; }
    private void UpdateMoneyUI()
    {
        moneyUI.text = string.Format("{0}", MonetFormatter.FormatMoney(Money));
    }




    // Start is called before the first frame update
    void Start()
    {
        Money = BigInteger.Parse(PlayerPrefs.GetString("Money", "0"));
        UpdateMoneyUI();
        instance = this;
        
    }

    public bool Buy(BigInteger cost)
    {
        bool isBuyOPSuccessfull = false;

        if(cost <= Money)
        {
            Money -= cost;
            isBuyOPSuccessfull = true;
        }

        UpdateMoneyUI();

        return isBuyOPSuccessfull;
    }



    public void AddMoney(BigInteger profit)
    {
        if(profit > 0)
        {
            Money += profit;
            UpdateMoneyUI();
        }
    }


    private void SaveMoney()
    {
        PlayerPrefs.SetString("Money", Money.ToString());

        PlayerPrefs.Save();
    }


    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveMoney();
        }
        
    }

    private void OnApplicationQuit()
    {
        SaveMoney();
    }

}
