using UnityEngine;

internal class MeleAttack: IState
{
    private EnemyMeleStates enemyMovementMele;

    private Delay delay;

    public MeleAttack(EnemyMeleStates enemyMovementMele, Delay delay)
    {
        this.enemyMovementMele = enemyMovementMele;

        this.delay = delay;
    }

    public void OnEnter()
    {
        Debug.Log("Attacking");
        enemyMovementMele.enemyMeleAnimations.Idle = true;
        enemyMovementMele.enemyMeleAnimations.Attacking = true;
    }

    public void OnExit()
    {
        enemyMovementMele.enemyMeleAnimations.Idle = false;
        enemyMovementMele.enemyMeleAnimations.Attacking = false;
        enemyMovementMele.CanShoot= false;
    }

    public void Tick()
    {
        if (enemyMovementMele.CanShoot){
  
            enemyMovementMele.Attack();

        }
        else
        {
           
            Debug.Log("Hola");
        }
       
    }
}