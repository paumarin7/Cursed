using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDirectionManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 shootDirection;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private float damage;
    [SerializeField]
    private string hitted;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetHitted(string hitted)
    {
        this.hitted = hitted;
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    public void SetShootDirection(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection;
    }

    public void SetAttackSpeed(float attackSpeed)
    {
        this.attackSpeed = attackSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += shootDirection * Time.deltaTime * attackSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable trigger = other.GetComponent<IDamageable>();
        if (other.tag == hitted || other.tag == "Bullet" || other.tag == "Forest")
        {
           
        }
        else
        {
            if(trigger != null)
            {
                trigger.TakeHealth(damage);
            }

            Destroy(this.gameObject);

        }
        
    }

}

