using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleMoveToHouse : IState
{

    private EnemyMeleStates enemyMovementMele;
    Vector3 playerDirection;

    public MeleMoveToHouse(EnemyMeleStates enemyMovementMele)
    {
        this.enemyMovementMele = enemyMovementMele;
    }

    public void OnEnter()
    {
        playerDirection = (enemyMovementMele.bed.transform.position - enemyMovementMele.transform.position);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

        enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3((enemyMovementMele.bed.transform.position.x - enemyMovementMele.transform.position.x), 0, (enemyMovementMele.bed.transform.position.z - enemyMovementMele.transform.position.z)).normalized * enemyMovementMele.Stats.Speed;
        enemyMovementMele.enemyMeleMovement.controller.Move(enemyMovementMele.enemyMeleMovement.followPlayer * Time.deltaTime);

    }
}
