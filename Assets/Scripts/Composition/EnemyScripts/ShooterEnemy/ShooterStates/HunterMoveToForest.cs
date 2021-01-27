using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMoveToForest : IState
{
    private EnemyShooterStates enemyShooterStates;
    Vector3 playerDirection;


    public HunterMoveToForest(EnemyShooterStates enemyShooterStates)
    {
        this.enemyShooterStates = enemyShooterStates;
    }

    public void OnEnter()
    {
        playerDirection = (enemyShooterStates.forest.transform.position - enemyShooterStates.transform.position);
    }

    public void OnExit()
    {

        //   enemyShooterStates.enemyShooterAnimations.IsFollowing = false;
    }
    public void Tick()
    {

        if (!enemyShooterStates.inForest && playerDirection.magnitude <= 1.5)
        {

            enemyShooterStates.inForest = true;

        }
        enemyShooterStates.enemyShooterMovement.followPlayer = new Vector3((enemyShooterStates.forest.transform.position.x - enemyShooterStates.transform.position.x), 0, (enemyShooterStates.forest.transform.position.z - enemyShooterStates.transform.position.z)).normalized * enemyShooterStates.Stats.Speed;
        enemyShooterStates.enemyShooterMovement.controller.Move(enemyShooterStates.enemyShooterMovement.followPlayer * Time.deltaTime);

    }
}
