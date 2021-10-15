using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

[Serializable]
public class BuildingData 
{
    [SerializeField]public bool IsUnlocked { get; set; }

    [SerializeField] public int BuildingLv1 { get; set; }

    [SerializeField] public string Profit { get; set; }


    public BuildingData(bool isUnlocked, int buildingLv1, string profit)
    {
        this.IsUnlocked = isUnlocked;
        this.BuildingLv1 = buildingLv1;
        this.Profit = profit;
    }

    public static string CreateJSONFromBuiulding(BuildingData building)
    {
        return JsonConvert.SerializeObject(building);
    }


    public static BuildingData CreateBuildingFromJSON(string jsonString)
    {
        return JsonConvert.DeserializeObject<BuildingData>(jsonString);
    }



}
