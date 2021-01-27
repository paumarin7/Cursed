using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMoveToHouse : IState
{
    private EnemyShooterStates enemyShooterStates;
    Vector3 playerDirection;


    public HunterMoveToHouse(EnemyShooterStates enemyShooterStates)
    {
        this.enemyShooterStates = enemyShooterStates;
    }
    public void OnEnter()
    {
        enemyShooterStates.enemyShooterMovement.playerDirection = enemyShooterStates.Player.transform.position - enemyShooterStates.transform.position;

    }

    public void OnExit()
    {

        //   enemyShooterStates.enemyShooterAnimations.IsFollowing = false;
    }

    public void Tick()
    {

        enemyShooterStates.enemyShooterMovement.followPlayer = new Vector3((enemyShooterStates.bed.transform.position.x - enemyShooterStates.transform.position.x), 0, (enemyShooterStates.bed.transform.position.z - enemyShooterStates.transform.position.z)).normalized * enemyShooterStates.Stats.Speed;
        enemyShooterStates.enemyShooterMovement.controller.Move(enemyShooterStates.enemyShooterMovement.followPlayer * Time.deltaTime);

    }
}
