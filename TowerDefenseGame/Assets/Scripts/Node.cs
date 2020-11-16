using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public enum State
    {
        Normal,
        Selected,
        Unselected,
    }
    public Color hoverColor;
    public Color notEnoughtMoney;
    public Color selectNode;
    private BuildManager buildManager;
    public State state;
    private Turret upgradeTurret;

    [Header("Optional")]
    public GameObject turret;

    // public TurretBlueprint turretBlueprint;
    public Vector3 offset;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        state = State.Normal;
        buildManager = BuildManager.instance;
        
    }

    /*private void Update()
    {
        switch(state)
        {
            case State.Normal:

                break;
            case State.Unselected:
                ColorDefaultNode();
                break;
            case State.Selected:
                
                break;

        }
    }*/

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        

        if(turret != null )
        {
            buildManager.SelectNode(this);
            rend.material.color = selectNode;
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurreToBuild());
        //GameObject turrerToBuild = BuildManager.instance.GetTurretToBuild();
        //turret = Instantiate(turrerToBuild, transform.position + offset, transform.rotation);
    }

    public void BuildTurret(TurretBlueprint blueprint)
    {
        if(PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enought money!");
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        
        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turret.GetComponent<Turret>().turretBlueprint = blueprint;
        
    }

    public void UpgradeDmgTurret()
    {
        upgradeTurret = turret.GetComponent<Turret>();
        if(PlayerStats.Money < upgradeTurret.turretBlueprint.upgradeDmgCost)
        {
            Debug.Log("Not enought money to upgrade UpgradeDmgTurret!");
            return;
        }
        PlayerStats.Money -= upgradeTurret.turretBlueprint.upgradeDmgCost;

        
        upgradeTurret.upgradeDmg += 25;
        Debug.Log("Денег" + upgradeTurret.turretBlueprint.upgradeDmgCost  + "\nDNG "+ upgradeTurret.upgradeDmg);
    }

    public void UpgradeMoneyForEnemyTurret()
    {
        upgradeTurret = turret.GetComponent<Turret>();
        if(PlayerStats.Money < upgradeTurret.turretBlueprint.upgradeMoneyForEnemyCost)
        {
            Debug.Log("Not enought money to upgrade MoneyForEnemy!");
            return;
        }
        PlayerStats.Money -= upgradeTurret.turretBlueprint.upgradeMoneyForEnemyCost;

        
        upgradeTurret.moneyForEnemy += 25;
        //Debug.Log(" Плюс апгрейд деньги " + upgradeTurret.moneyForEnemy);
    }

    /*public void ForTurret(BuildManager buildManager, Node node)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (node.turret != null)
        {
            buildManager.SelectNode(node);
            node.rend.material.color = node.selectNode;
            return;
        }

        if (!buildManager.CanBuild)
            return;

        buildManager.BuildTurretOn(node);
     }*/

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turret.GetComponent<Turret>().turretBlueprint.SellCost();
        Debug.Log("Sell " + turret.GetComponent<Turret>().turretBlueprint.SellCost());
        Destroy(turret);
        //turretBlueprint = null;
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if(buildManager.HasMoney && buildManager.CanBuild)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughtMoney;
        }
        
        
    }

  

    private void OnMouseExit()
    {
        if(buildManager.selectedNode == this)
        {
            //state = State.Selected;
            rend.material.color = selectNode;
        }else
        {
            //state = State.Unselected;
            rend.material.color = startColor;
        }

        
    }

    public void ColorDefaultNode()
    {
        rend.material.color = startColor;
    }

    public void ColorSelectedNode()
    {
        rend.material.color = selectNode;
    }
}
