using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TurretBlueprint {

    public GameObject prefab;
    public GameObject Prefab { get { return prefab; } }
    public int cost;

    public GameObject upgradedPrefab;

    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }


}
