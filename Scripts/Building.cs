using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{

    [SerializeField] private int id;

    [SerializeField] private GameObject buildingVisual;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private string costRepresentation;


    [SerializeField] private GameObject upgradeButton;
    private Text upgradeButtonText;

    [SerializeField] private int  upgradeCostMultiplier = 10;

    [SerializeField] private GameObject collectProfitButton;

    [SerializeField] private int buildingLv1 = 1;
    [SerializeField] private int profitMultiplier = 1;

 Animator anim;
    private BigInteger NextUpgradeCost
    {
        get
        {
            return buildingLv1 * upgradeCostMultiplier;
        }
    }





    [SerializeField] private BigInteger profit;

    public BigInteger Cost
    {
        get { return BigInteger.Parse(costRepresentation); }
        set { costRepresentation = value.ToString(); }

    }

    private bool isUnlocked = false;
    private Text buyButtonText;
    private Text collectProfitButtonText;



    // Start is called before the first frame update
    void Start()
    {

        buyButtonText = buyButton.GetComponentInChildren<Text>();

        buyButtonText.text = MonetFormatter.FormatMoney(Cost);

        buyButton.SetActive(!isUnlocked);

        buildingVisual.SetActive(isUnlocked);

       
        collectProfitButtonText = collectProfitButton.GetComponentInChildren<Text>();

        collectProfitButton.SetActive(isUnlocked);


        upgradeButtonText = upgradeButton.GetComponentInChildren<Text>();

       
        upgradeButton.SetActive(isUnlocked);


        UpdateUpgradeUI();




        StartCoroutine(MakeProfit());
        
    }


    IEnumerator MakeProfit()
    {
        while (true)
        {
            if (isUnlocked)
            {

                profit += buildingLv1 * profitMultiplier;

                UpdateProfitUI();

            }

            yield return new WaitForSecondsRealtime(1f);

        }
    }






    private void UpdateProfitUI()
    {
        collectProfitButtonText.text = MonetFormatter.FormatMoney(profit);
    }



    private void UpdateUpgradeUI()
    {
        upgradeButtonText.text = $"ˆ\nLVL{buildingLv1}\n{MonetFormatter.FormatMoney(NextUpgradeCost)}";
    }




    public void OnBuyButton()
    {
        if (!isUnlocked)
        {
            if (MoneyManager.instance.Buy(Cost))
            {
                isUnlocked = true;

                buildingVisual.SetActive(isUnlocked);

                buyButton.SetActive(!isUnlocked);

                collectProfitButton.SetActive(isUnlocked);
                upgradeButton.SetActive(isUnlocked);
                
            }
           
        }
       

            
    }





    public void OnCollectProfitButton()
    {
        MoneyManager.instance.AddMoney(profit);

        profit = 0;

        UpdateProfitUI();
    }

    public void OnUpgradeButton()
    {
        if (MoneyManager.instance.Buy(NextUpgradeCost))
        {
            buildingLv1 += 1;

            UpdateUpgradeUI();
        }
    }


    private void SaveBuildingData()
    {
        BuildingData bd = new BuildingData(isUnlocked, buildingLv1, profit.ToString());


        string json = BuildingData.CreateJSONFromBuiulding(bd);

        PlayerPrefs.SetString("building" + id, json);

        PlayerPrefs.Save();
    }

    private void LoadBuildingData()
    {
        string json = PlayerPrefs.GetString("building" + id, "");

        BuildingData bd = null;

        if (json.Equals(""))
        {
            bd = new BuildingData(false, 1, "0");
        }
        else
        {
            bd = BuildingData.CreateBuildingFromJSON(json);
        }


        isUnlocked = bd.IsUnlocked;
        buildingLv1 = bd.BuildingLv1;

        profit = BigInteger.Parse(bd.Profit);
    }


    private void Awake()
    {
        LoadBuildingData();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveBuildingData();
        }

    }

    private void OnApplicationQuit()
    {
        SaveBuildingData();
    }


}
