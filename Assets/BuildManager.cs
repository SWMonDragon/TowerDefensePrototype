using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private GameObject turretSelected;

    public GameObject basicTurret;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one instance of this manager exists");
        }
        instance = this;
    }

    private void Start()
    {
        turretSelected = basicTurret;
    }



    public GameObject BuildTurret()
    {

        return turretSelected;
    }
}
