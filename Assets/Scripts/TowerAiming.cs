using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAiming : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] float maxRange = 15.0f;
    Transform target;

    void Start()
    {
        Attack(false);
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = maxRange;

        foreach(Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance <= maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = distance;
            }
        }

        if(closestTarget)
        {
            target = closestTarget;
            Attack(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target && target.gameObject.activeSelf) { CheckTarget(); }

        else { FindClosestTarget(); }
    }

    void CheckTarget()
    {
        if(Vector3.Distance(target.gameObject.transform.position, transform.position) > maxRange)
        {
            Debug.Log(Vector3.Distance(target.gameObject.transform.position, transform.position));
            target = null;
            Debug.Log("Target moved out of range");
        }

        else
        {
            weapon.transform.LookAt(target.transform.position);
        }
    }

    void Attack(bool isActive)
    {
        ParticleSystem.EmissionModule emissionModule = GetComponentInChildren<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
    }


}
