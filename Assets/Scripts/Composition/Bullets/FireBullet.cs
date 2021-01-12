using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour, IShootable
{
    private Vector3 enemyTransform;
    private Rigidbody rb;
    private WeaponDirectionManager weaponDirectionManager;
    private float Accuracy;
    private Sprite imageSprite;


    public void SetEnemyTransform(Vector3 enemyTransform)
    {
        this.enemyTransform = enemyTransform;
    }
    public void SetAccuracy(float Accuracy)
    {
        this.Accuracy = Accuracy;
    }
    void Start()
    {
        weaponDirectionManager = GetComponent<WeaponDirectionManager>();
        rb = GetComponent<Rigidbody>();
        enemyTransform = new Vector3(Random.Range(enemyTransform.x - Accuracy, enemyTransform.x + Accuracy), enemyTransform.y, Random.Range(enemyTransform.z - Accuracy, enemyTransform.z + Accuracy));
        enemyTransform = new Vector3(enemyTransform.x - transform.position.x, 0, enemyTransform.z - transform.position.z).normalized;
        imageSprite = Resources.Load<Sprite>("Bullets/fireBullet");
        if (GetComponent<SpriteRenderer>() == null)
        {
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = imageSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponDirectionManager != null)
        {
            weaponDirectionManager.SetShootDirection(enemyTransform);
        }

    }
}
