using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    [SerializeField] private GameObject uiDefault;
    [SerializeField] private GameObject uiTurrer;
    [SerializeField] private Text damage;
    [SerializeField] private Text extraMoney;

    private void Awake()
    {
        uiTurrer.SetActive(false);
        uiDefault.SetActive(true);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            target =null;
            BuildManager.instance.DeselectNode();
        }
        

        if(target != null)
        {
            damage.text = target.turret.GetComponent<Turret>().upgradeDmg.ToString();
            extraMoney.text = target.turret.GetComponent<Turret>().moneyForEnemy.ToString();
        }else{
            damage.text = "";
            extraMoney.text = "";
        }
        
    
    }

    public void SetTarget(Node _target)
    {
        target = _target;
        uiTurrer.SetActive(true);
        uiDefault.SetActive(false);
    }

    public void Hide()
    {
        
        uiTurrer.SetActive(false);
        uiDefault.SetActive(true);

    }

    public void SellTurret()
    {
        target.SellTurret();
        target =null;
        BuildManager.instance.DeselectNode();
    }

    public void UpgradeMoneyForEnemyCost()
    {
        target.UpgradeMoneyForEnemyTurret();
    }

    public void UpgradeDmg()
    {
        target.UpgradeDmgTurret();
    }
}
