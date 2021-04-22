using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public bool isBuildable;
    public Color selected;
    public Color buildable;

    private Renderer nodeRenderer;
    private Color startingColor;

    private GameObject currentTurret;

    private void Start()
    {
        nodeRenderer = GetComponent<Renderer>();
        startingColor = nodeRenderer.material.color;
        if (isBuildable)
        {
            nodeRenderer.material.color = buildable;
        }

        Input.simulateMouseWithTouches = true;
    }

    private void Update()
    {

    }

    private void OnMouseEnter()
    {
        nodeRenderer.material.color = selected;
    }

    private void OnMouseExit()
    {

        if (isBuildable)
        {
            nodeRenderer.material.color = buildable;
        }
        else
        {
            nodeRenderer.material.color = startingColor;
        }

    }

    private void OnMouseDown()
    {
        if (isBuildable)
        {
            if (currentTurret != null)
            {
                Debug.Log("There is already a turret here");
                return;
            }

            CreateTurret();
        }
        else
        {
            Debug.Log("You cannot build in this zone");
        }

    }

    public void CreateTurret()
    {
        GameObject turretBuilding = BuildManager.instance.BuildTurret();
        currentTurret = Instantiate(turretBuilding, transform.position, transform.rotation);
    }
}
