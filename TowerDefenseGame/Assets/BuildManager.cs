using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }

    //public GameObject standardTurretPrefab;
    //public GameObject anotherTurretPrefab;
   
    private TurretBlueprint turrerToBuild;
    public Node selectedNode;
    public NodeUI nodeUI;
    
    public bool CanBuild { get { return turrerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turrerToBuild.cost; } }


    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        
        if(selectedNode != null)
        {
            selectedNode.ColorDefaultNode();
        }
        

        selectedNode = node;
        selectedNode.ColorSelectedNode();
        turrerToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        if(selectedNode != null)
        {
            selectedNode.ColorDefaultNode();
            selectedNode = null;
            
        }
        nodeUI.Hide();

    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turrerToBuild = turret;
        DeselectNode();
    }
    
    public TurretBlueprint GetTurreToBuild()
    {
        return turrerToBuild;
    }
}
