using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;
    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a déjà un Buidmanager dans la scène");
            return;
        }
        instance = this;
    }
    #endregion
    public GameObject buildEffect;
    public GameObject sellEffect;
    private TurretBluePrint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public bool canBuild{get{ return turretToBuild != null; }}
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBluePrint GetTurretToBuild() 
    { 
        return turretToBuild;
    }

    public void SelectNode(Node node)
    {
        if(node == selectedNode)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

}
