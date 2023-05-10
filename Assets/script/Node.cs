using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;
    private Color startColor;
    private Renderer rend;
    private BuildManager buildManager;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Pas assez d'argent pour améliorer");
            return;
        }

        PlayerStats.money -= turretBluePrint.upgradeCost;

        // Suppression de l'ancienne tourelle
        Destroy(turret);

        // Création de sa version améliorée
        GameObject _turret = Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isUpgraded = true;


        Debug.Log("Tourelle améliorée");
    }

    private void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.money < bluePrint.cost)
        {
            Debug.Log("Pas assez d'argent pour construire ceci");
            return;
        }

        PlayerStats.money -= bluePrint.cost;

        turretBluePrint = bluePrint;

        GameObject _turret = Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        Debug.Log("Tourelle acheté");
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBluePrint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        Destroy(turret);
        turretBluePrint = null;
        isUpgraded = false;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());

    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.canBuild)
        {
            return;
        }

        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
