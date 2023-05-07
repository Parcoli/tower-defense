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
            Debug.LogError("Il y a déjà un Buidmanager dans la scène");
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
