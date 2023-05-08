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
            Debug.LogError("Il y a d�j� un Buidmanager dans la sc�ne");
            return;
        }
        instance = this;
    }
    #endregion
    public GameObject standardTurretPreb;
    public GameObject missileLauncherPreb;

    private TurretBluePrint turretToBuild;

    public bool canBuild{get{ return turretToBuild != null; }}
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Pas assez d'argent pour construire ceci");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Objet achet�, il vous reste : " + PlayerStats.money);
        
    }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

}
