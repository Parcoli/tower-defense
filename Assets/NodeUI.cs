using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    private Node target;
    public GameObject ui;

    public Text sellAmount;

    public Text upgradeCost;
    public Button upgradeButton;
    
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if(!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretBluePrint.upgradeCost + "€";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "<i>Déjà améliorée</i>";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "+" + target.turretBluePrint.GetSellAmount() + "€";

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
