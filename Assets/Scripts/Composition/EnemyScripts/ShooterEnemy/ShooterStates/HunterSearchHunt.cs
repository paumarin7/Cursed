using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterSearchHunt : IState
{

    private EnemyShooterStates enemyShooterStates;
    public HunterSearchHunt(EnemyShooterStates enemyShooterStates)
    {
        this.enemyShooterStates = enemyShooterStates;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
    }

    public void Tick()
    {


        Collider[] hitColliders = Physics.OverlapSphere(enemyShooterStates.transform.position, 20);


        Debug.Log(enemyShooterStates.toHunt.Count + "SearchHunting");

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Hunt")
                {
                enemyShooterStates.animal = hitCollider.gameObject;

                //   hitCollider.gameObject.GetComponent<rabbit>().arein = true;

            }
            }
        }

    }            

