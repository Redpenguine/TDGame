using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
    public Text uiCost;
    public int upgradeDmgCost;
    //public Text uiUpgradeDmgCost;
    public int upgradeMoneyForEnemyCost;
    //public Text uiUpgradeMoneyForEnemyCost;
    

    public int SellCost()
    {
        
        return cost/2;
    }
}
