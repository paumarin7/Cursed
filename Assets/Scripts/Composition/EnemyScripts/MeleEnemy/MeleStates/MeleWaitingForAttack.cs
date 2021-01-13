using UnityEngine;

internal class MeleWaitingForAttack: IState
{
    private EnemyMeleStates enemyMovementMele;

    private Delay delay;

    public MeleWaitingForAttack(EnemyMeleStates enemyMovementMele,  Delay delay)
    {
        this.enemyMovementMele = enemyMovementMele;

        this.delay = delay;
    }



    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
       enemyMovementMele.enemyMeleAnimations.Idle = false;
    }

    public void Tick()
    {

        Debug.Log("Waiting");
        enemyMovementMele.enemyMeleAnimations.Attacking = false;
        enemyMovementMele.enemyMeleAnimations.Idle = true;
        
        
        
    }
}