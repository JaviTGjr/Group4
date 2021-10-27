using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;

    public static BuildManager instance;

    public GameObject standardTurretPrefab;

    public GameObject missileTurretPrefab;

    public GameObject WaypointPrefab;

    public void BuildTurretOn(Node node)
    {

        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;


        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left" + PlayerStats.Money);

    }

    void Awake()
    {

        if(instance != null)
        {
            Debug.Log("More than one Build manager in scene");
            return;
        }
        instance = this;
       
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }



}
