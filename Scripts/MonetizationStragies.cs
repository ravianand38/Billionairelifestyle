using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonetizationStragies : MonoBehaviour
{
    [SerializeField] private GameObject doubleMoneyPanel;

    [SerializeField] private float doubleMoneyInterval = 60f;
    [SerializeField] private float skippableVideoInterval = 150f;





    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoubleMoneyAdRoutine());
        StartCoroutine(SkippableVideoAdRoutine());
    }














    IEnumerator DoubleMoneyAdRoutine()
    {
        doubleMoneyPanel.SetActive(false);

        while (true)
        {
            yield return new WaitForSeconds(doubleMoneyInterval);

            if (!doubleMoneyPanel.activeSelf)
            {
                doubleMoneyPanel.SetActive(true);
            }

        }
    }






    IEnumerator SkippableVideoAdRoutine()
    {
        while (true)
        {
            if(PlayerPrefs.GetInt("adsRemoved",0) == 1)
            {
                yield break;
            }
            yield return new WaitForSeconds(skippableVideoInterval);

            GetComponent<Ads>().ShowSkippableAd();

        }

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
