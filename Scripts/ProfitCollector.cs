using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfitCollector : MonoBehaviour
{
    [SerializeField] private float profitCollectionInterval = 5f;

    [SerializeField] private GameObject dogAvatar;

    private float profitCollectorTimer = 0;

    private List<Building> buildings;
    private int isManagerHired = 0;


    // Start is called before the first frame update
    void Start()
    {
        isManagerHired = PlayerPrefs.GetInt("isManagerHired", 0);


        buildings = new List<Building>();


        buildings.AddRange(GameObject.FindObjectsOfType<Building>());
    }

    // Update is called once per frame
    void Update()
    {
        if(isManagerHired == 1)
        {
            profitCollectorTimer += Time.deltaTime;

            if(profitCollectorTimer >= profitCollectionInterval)
            {
                profitCollectorTimer = 0;

                foreach(Building building in buildings)
                {
                    building.OnCollectProfitButton();
                }

            }
        }


    }




    public void HireManager()
    {
        isManagerHired = 1;


        dogAvatar.SetActive(true);

        PlayerPrefs.SetInt("isManagerHired", isManagerHired);
    }
       
}
