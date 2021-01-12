using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveShoot : MonoBehaviour, IWeapon
{
    private GameObject bullet;
    [SerializeField]
    private GameObject nearestEnemy;
    private string hitted;



    private void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");

    }
    public void Update()
    {
    }

    IEnumerator BulletWaitTime()
    {
        Bullet(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        yield return new WaitForSeconds(0.1f);
        Bullet(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        yield return new WaitForSeconds(0.1f);
        Bullet(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        yield return new WaitForSeconds(0.1f);
        Bullet(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        yield return new WaitForSeconds(0.1f);
        Bullet(new Vector3(transform.position.x, transform.position.y, transform.position.z));

    }

    public void Attack()
    {
        StartCoroutine(BulletWaitTime());
    }


    public void SetNearestEnemy(GameObject nearestEnemy)
    {
        this.nearestEnemy = nearestEnemy;
    }

    public void Bullet(Vector3 bulletPosition)
    {

        GameObject bala = Instantiate(bullet);

        bala.AddComponent(GetComponent<IShootable>().GetType());
        bala.AddComponent<WeaponDirectionManager>();
        bala.GetComponent<WeaponDirectionManager>().SetDamage(GetComponentInParent<Stats>().Strength);
        bala.GetComponent<WeaponDirectionManager>().SetAttackSpeed(GetComponentInParent<Stats>().AttackSpeed);
        bala.GetComponent<WeaponDirectionManager>().SetHitted(hitted);

        bala.GetComponent<IShootable>().SetAccuracy(GetComponentInParent<Stats>().Accuracy);
        bala.transform.position = bulletPosition;
        if (nearestEnemy == null)
        {
        }
        else
        {
            bala.GetComponent<IShootable>().SetEnemyTransform(nearestEnemy.transform.position);
        }
    }

    public void SetHitted(string v)
    {
        this.hitted = v;
    }
}
