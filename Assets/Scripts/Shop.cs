using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint wayPoint;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);



    }

    public void SelectMissileTurret ()
    {
        Debug.Log("Missile Turret Selected");
        buildManager.SelectTurretToBuild(missileTurret);
    }



    public void SelectWaypoint()
    {
        Debug.Log("Waypoint Selected");
        buildManager.SelectTurretToBuild(wayPoint);
    }

}
