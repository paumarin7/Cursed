using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShoot : MonoBehaviour, IWeapon
{
    private GameObject bullet;
    private GameObject nearestEnemy;
    private string hitted;

    private void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
    }
    public void Attack()
    {
        Bullet(new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }


    public void SetNearestEnemy(GameObject nearestEnemy)
    {
        this.nearestEnemy = nearestEnemy;
    }

    public void SetHitted(string hitted)
    {
        this.hitted = hitted;
    }


    public void Bullet(Vector3 bulletPosition)
    {
       
        GameObject bala = Instantiate(bullet);
        bala.AddComponent(GetComponent<IShootable>().GetType());
        bala.layer = 2;
        bala.AddComponent<WeaponDirectionManager>();
        bala.GetComponent<WeaponDirectionManager>().SetDamage(GetComponentInParent<Stats>().Strength);
        bala.GetComponent<WeaponDirectionManager>().SetAttackSpeed(GetComponentInParent<Stats>().AttackSpeed);
        bala.GetComponent<IShootable>().SetAccuracy(GetComponentInParent<Stats>().Accuracy);
        bala.GetComponent<WeaponDirectionManager>().SetHitted(hitted);
        bala.transform.position = bulletPosition;
        if (nearestEnemy == null)
        {
        }
        else
        {
            bala.GetComponent<IShootable>().SetEnemyTransform(nearestEnemy.transform.position);
        }
    }
}
