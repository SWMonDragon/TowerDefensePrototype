using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameManager gm;

    [Header("Enemy Attributes")]
    public float speed = 10f;
    private Transform target;
    public float hitPoints = 10;

    private int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = WaypointManager.waypoints[0];
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,target.position) <= 0.5f)
        {
            MoveToNextWaypoint();
        }
    }

    public void DoDamage(float _dmg)
    {
        Debug.Log("I have been damaged");
        hitPoints -= _dmg;
        if(hitPoints <= 0)
        {
            gm.pointsToWin--;
            Destroy(gameObject);
            return;
        }
    }

    public void MoveToNextWaypoint()
    {
        if(waypointIndex >= WaypointManager.waypoints.Length - 1)
        {
            Destroy(gameObject);
            if (gm.suddenDeath)
            {
                gm.GameOver();
            }
            return;
        }

        waypointIndex++;
        target = WaypointManager.waypoints[waypointIndex];
    }

}
