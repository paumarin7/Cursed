using UnityEngine;

internal class ShooterWaitingForAttack:IState
{
    private EnemyShooterStates enemyShooterStates;
    private Delay delay;
    Vector3 mov;

    public ShooterWaitingForAttack(EnemyShooterStates enemyShooterStates, Delay delay)
    {
        this.enemyShooterStates = enemyShooterStates;
        this.delay = delay;
    }

    public void OnEnter()
    {
        var num = 3f;
        mov= new Vector3(Random.Range(enemyShooterStates.transform.position.x - num, enemyShooterStates.transform.position.x + num) , enemyShooterStates.transform.position.y, Random.Range(enemyShooterStates.transform.position.z - num, enemyShooterStates.transform.position.z + num));

    }

    public void OnExit()
    {
       // enemyShooterStates.enemyShooterAnimations.Idle = false;
    }

    public void Tick()
    {
        enemyShooterStates.enemyShooterMovement.followPlayer = new Vector3(mov.x - enemyShooterStates.transform.position.x, mov.y, mov.z - enemyShooterStates.transform.position.z).normalized * enemyShooterStates.Stats.Speed;
        Debug.Log("Waiting");
        enemyShooterStates.enemyShooterMovement.controller.Move(enemyShooterStates.enemyShooterMovement.followPlayer * Time.deltaTime);
      //  enemyShooterStates.enemyShooterAnimations.Attacking = false;
      //  enemyShooterStates.enemyShooterAnimations.Idle = true;



    }
}