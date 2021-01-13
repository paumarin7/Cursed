using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleSearchPlayer : IState
{

    private EnemyMeleStates enemyMovementMele;
    Vector3 playerDirection;

    public MeleSearchPlayer(EnemyMeleStates enemyMovementMele)
    {
        this.enemyMovementMele = enemyMovementMele;
    }

    public void OnEnter()
    {
       playerDirection = (enemyMovementMele.Player.transform.position - enemyMovementMele.transform.position);
    }

    public void OnExit()
    {
       
    }

    public void Tick()
    {
        RaycastHit hitPlayer;
        Vector3 followPlayer;
        //Move To Player
        if (Physics.Raycast(enemyMovementMele.transform.position,  playerDirection, out hitPlayer, 50))
        {

            
        }

    }
}
