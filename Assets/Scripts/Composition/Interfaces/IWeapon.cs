using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Attack();
    void SetNearestEnemy(GameObject nearestEnemy);

    void Bullet(Vector3 bulletPosition);
    void SetHitted(string v);
}
