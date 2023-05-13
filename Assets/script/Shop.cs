using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncherTurret;
    public TurretBluePrint laserBeamTurret;
    public TurretBluePrint iceTurret;
    public TurretBluePrint fireTurret;
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Tourelle Standard selectionné");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Lance Missile selectionné");
        buildManager.SelectTurretToBuild(missileLauncherTurret);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Tourelle laser selectionné");
        buildManager.SelectTurretToBuild(laserBeamTurret);
    }

    public void SelectIceTurret()
    {
        Debug.Log("Tourelle laser selectionné");
        buildManager.SelectTurretToBuild(iceTurret);
    }

    public void SelectFireTurret()
    {
        Debug.Log("Tourelle laser selectionné");
        buildManager.SelectTurretToBuild(fireTurret);
    }
}
