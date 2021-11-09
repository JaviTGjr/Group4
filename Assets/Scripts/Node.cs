using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class Node : MonoBehaviour
{

    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    public bool isUpgraded = false;


    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;

    public Color hoverColor;

    private Renderer rend;

    private Color startColor;

    BuildManager buildManager;

    public int numberToSpawn;

    public GameObject obstacle;

    private static int obstacleCount; 

    

    void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        SpawnObstacle();

    }

    void SpawnObstacle()
    {
        numberToSpawn = Random.Range(0, 10);
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

        if (EventSystem.current.IsPointerOverGameObject())
            return;



        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
            
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
        Waypoints.current.AddWaypoint(turret.transform);



    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Money -= blueprint.cost;


        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

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
        rend.material.color = startColor;
    }

}
