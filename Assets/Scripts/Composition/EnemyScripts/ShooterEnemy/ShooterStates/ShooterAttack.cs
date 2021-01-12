using UnityEngine;

internal class ShooterAttack:IState
{
    private EnemyShooterStates enemyShooterStates;
    private Delay delay;

    public ShooterAttack(EnemyShooterStates enemyShooterStates, Delay delay)
    {
        this.enemyShooterStates = enemyShooterStates;
        this.delay = delay;
    }

    public void OnEnter()
    {
        Debug.Log("Attacking");
        enemyShooterStates.enemyShooterAnimations.Idle = true;
        enemyShooterStates.enemyShooterAnimations.Attacking = true;
    }

    public void OnExit()
    {
        enemyShooterStates.enemyShooterAnimations.Idle = false;
        enemyShooterStates.enemyShooterAnimations.Attacking = false;
        enemyShooterStates.CanShoot = false;
    }

    public void Tick()
    {

            enemyShooterStates.Attacking();
    }
}