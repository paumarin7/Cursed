using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleMoveToWheat : IState
{
    private EnemyMeleStates enemyMovementMele;
    Vector3 playerDirection;

    public MeleMoveToWheat(EnemyMeleStates enemyMovementMele)
    {
        this.enemyMovementMele = enemyMovementMele;
    }

    public void OnEnter()
    {
        playerDirection = (enemyMovementMele.wheat.transform.position - enemyMovementMele.transform.position);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

        if (!enemyMovementMele.inWheatFarm && playerDirection.magnitude <= 2.5)
        {
            Debug.Log(playerDirection.magnitude);
            enemyMovementMele.inWheatFarm = true;
            
        }
        enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3((enemyMovementMele.wheat.transform.position.x - enemyMovementMele.transform.position.x), 0, (enemyMovementMele.wheat.transform.position.z - enemyMovementMele.transform.position.z)).normalized * enemyMovementMele.Stats.Speed;
        enemyMovementMele.enemyMeleMovement.controller.Move(enemyMovementMele.enemyMeleMovement.followPlayer * Time.deltaTime);

    }
}
