using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHunt : IState
{
    private EnemyShooterStates enemyShooterStates;



    public MoveToHunt(EnemyShooterStates enemyShooterStates)
    {
        this.enemyShooterStates = enemyShooterStates;
    }

    public void OnEnter()
    {




    }

    public void OnExit()
    {

        //   enemyShooterStates.enemyShooterAnimations.IsFollowing = false;
    }

    public void Tick()
    {
        enemyShooterStates.enemyShooterAnimations.IsFollowing = true;
        Debug.Log("following player");
        //  animator.SetBool("Idle",false);
        enemyShooterStates.enemyShooterMovement.followPlayer = new Vector3((enemyShooterStates.animal.transform.position.x - enemyShooterStates.transform.position.x), 0, (enemyShooterStates.animal.transform.position.z - enemyShooterStates.transform.position.z)).normalized * enemyShooterStates.Stats.Speed;
        enemyShooterStates.enemyShooterMovement.controller.Move(enemyShooterStates.enemyShooterMovement.followPlayer * Time.deltaTime);
        enemyShooterStates.enemyShooterMovement.LastPosition = new Vector3(enemyShooterStates.animal.transform.position.x, enemyShooterStates.transform.position.y, enemyShooterStates.animal.transform.position.z);
        enemyShooterStates.enemyShooterMovement.FirstPosition = enemyShooterStates.transform.position;

    }
}

