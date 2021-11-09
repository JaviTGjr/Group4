using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{

    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    public bool isUpgraded = false;


    public GameObject obstacle;
    private static int obstacleCount;
    public int numberToSpawn;

    public Color notEnoughMoneyColor;

    public Color waypointColor;

    public Vector3 positionOffset;

    public Color hoverColor;

    private Renderer rend;

    private Color startColor;

    BuildManager buildManager;

    private bool hasWaypoint = false;

    private static int currentWaypointAmount;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        SpawnObstacle();

    }

    void SpawnObstacle()
    {
        numberToSpawn = Random.Range(numberToSpawn, numberToSpawn);
        if (obstacleCount < numberToSpawn)
        {
            obstacleCount++;
            Vector3 position = transform.position + positionOffset;
            Instantiate(obstacle, position, Quaternion.identity);
        }
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


     void OnMouseDown()
    {
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
            
        }

        if (!buildManager.CanBuild)
            return;

        if (currentWaypointAmount < buildManager.maxWaypoints)
        {
            BuildTurret(buildManager.GetTurretToBuild());
            if (buildManager.GetTurretToBuild().Prefab.name == "Waypoint")
            {
                Waypoints.current.AddWaypoint(turret.transform);
                Debug.Log("Waypoint added " + currentWaypointAmount);
                rend.material.color = waypointColor;
                hasWaypoint = true;
                currentWaypointAmount++;
            }
        }
        else if (currentWaypointAmount >= buildManager.maxWaypoints)
        {
            Debug.Log("too many waypoints");
        }
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        turretBlueprint = blueprint;
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Money -= blueprint.cost;


        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        Debug.Log("Turret build! Money left" + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to Upgrade that");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        

        isUpgraded = true;

        Debug.Log("Turret updraged! Money left" + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
        hasWaypoint = false;
        rend.material.color = startColor;
        if (turretBlueprint.Prefab.name == "Waypoint")
        {
            Debug.Log("less waypoints");
            currentWaypointAmount--;
        }
    }


    void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        

    }

     void OnMouseExit()
    {
        if(hasWaypoint)
        {
            rend.material.color = waypointColor;
        }
        else
        {
            rend.material.color = startColor;
        }
    }

}
