
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float damage;

    public float speed = 15f;
    public GameObject VFX;

    public void SeekTarget(Transform _target, float _damage)
    {
        target = _target;
        damage = _damage;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float currentFrameDistance = speed * Time.deltaTime;

        if(dir.magnitude <= currentFrameDistance)
        {
            DamageTarget(damage);
            return;
        }

        transform.Translate(dir.normalized * currentFrameDistance, Space.World);
    }

    public void DamageTarget(float _dmg)
    {
        Debug.Log("You hit something for: " + _dmg);
        GameObject hitFX = Instantiate(VFX, transform.position, transform.rotation);
        Destroy(hitFX, 2f);
        target.GetComponent<EnemyBehaviour>().DoDamage(damage);
        Destroy(gameObject);
    }
}
