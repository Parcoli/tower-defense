using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Tourelle Standard selectionn�");
        buildManager.SetTurretToBuild(buildManager.standardTurretPreb);
    }

    public void PurchaseMissileLauncher()
    {
        Debug.Log("Lance Missile selectionn�");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPreb);
    }
}