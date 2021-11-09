using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;

    private Node selectedNode;

    public static BuildManager instance;

    public NodeUI nodeUI;

    public int maxWaypoints = 2;

    public int MaxWaypoints { get { return maxWaypoints; } }


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

    public void SelectNode(Node node)
    {

        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }


        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);

    }

    public void DeselectNode() {


        selectedNode = null;
        nodeUI.Hide();
    
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();

    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }



}
