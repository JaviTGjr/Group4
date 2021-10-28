using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{

    public GameObject turret;

    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;

    public Color hoverColor;

    private Renderer rend;

    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


     void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if(turret != null)
        {
            Debug.Log("Can't build there!");
            return;
            
        }
       

        buildManager.BuildTurretOn(this);
        Waypoints.current.AddWaypoint(turret.transform);



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
