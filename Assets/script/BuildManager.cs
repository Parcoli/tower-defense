using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Start()
    {
        turretToBuild = standardTurretPreb;
    }
    private GameObject turretToBuild;
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
