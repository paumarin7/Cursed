

using UnityEngine;

internal class ShooterMoveToPlayer:IState
{
    private EnemyShooterStates enemyShooterStates;
    Vector3 playerDirection;


    public ShooterMoveToPlayer(EnemyShooterStates enemyShooterStates)
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
        enemyShooterStates.enemyShooterAnimations.IsFollowing = true;
        Debug.Log("following player");
        //  animator.SetBool("Idle",false);
        enemyShooterStates.enemyShooterMovement.followPlayer = new Vector3((enemyShooterStates.Player.transform.position.x - enemyShooterStates.transform.position.x), 0, (enemyShooterStates.Player.transform.position.z - enemyShooterStates.transform.position.z)).normalized * enemyShooterStates.Stats.Speed;
        enemyShooterStates.enemyShooterMovement.controller.Move(enemyShooterStates.enemyShooterMovement.followPlayer * Time.deltaTime);
        enemyShooterStates.enemyShooterMovement.LastPosition = new Vector3(enemyShooterStates.Player.transform.position.x, enemyShooterStates.transform.position.y, enemyShooterStates.Player.transform.position.z);
        enemyShooterStates.enemyShooterMovement.FirstPosition = enemyShooterStates.transform.position;

    }
}