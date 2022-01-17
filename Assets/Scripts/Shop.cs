using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint wayPoint;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint singleTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTripleTurret ()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret ()
    {
        Debug.Log("Missile Turret Selected");
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectSingleTurret()
    {
        Debug.Log("Raygun Turret Selected");
        buildManager.SelectTurretToBuild(singleTurret);

    }
    public void SelectWaypoint()
    {
        Debug.Log("Waypoint Selected");
        buildManager.SelectTurretToBuild(wayPoint);
    }

}
