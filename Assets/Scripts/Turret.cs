using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform currentTarget;

    [Header("Turret Attributes")]
    public float range;
    public float damage;

    [Header("Shooting")]
    public float fireRate = 1f;
    public float timeToShoot = 0f;
    public GameObject bullet;
    public Transform firePoint;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TargetEnemy", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTarget == null)
        {
            return;
        }

        Vector3 dir = currentTarget.position - transform.position;
        transform.LookAt(new Vector3(currentTarget.position.x, transform.position.y, currentTarget.position.z));
        if(timeToShoot <= 0)
        {
            ShootEnemy();
            timeToShoot = 1f / fireRate;
        }

        timeToShoot -= Time.deltaTime;
    }

    void ShootEnemy()
    {
        GameObject bulletTemp = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet temp = bulletTemp.GetComponent<Bullet>();
        if(temp != null){
            temp.SeekTarget(currentTarget, damage);
        }

    }

    void TargetEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestEnemyDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (currentTarget != null && Vector3.Distance(transform.position, currentTarget.position) <= range)
            {
                return;
            }
            if (distanceToEnemy < closestEnemyDistance)
            {
                closestEnemyDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if(closestEnemy != null && closestEnemyDistance <= range)
        {
            currentTarget = closestEnemy.transform;
        }
        else
        {
            currentTarget = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
