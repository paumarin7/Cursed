using UnityEngine;

internal class ShooterReturnToFirstPosition: IState
{
    private EnemyShooterStates enemyShooterStates;

    public ShooterReturnToFirstPosition(EnemyShooterStates enemyShooterStates)
    {
        this.enemyShooterStates = enemyShooterStates;
    }

    public void OnEnter()
    {
        //   enemyMovementMele.IsReturningInitialPosition = false;
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

        enemyShooterStates.enemyShooterAnimations.IsFollowing = false;

        Debug.Log("Return to first position");
        //   animator.SetBool("Idle", false);
        if (Vector2.Distance(enemyShooterStates.enemyShooterMovement.FirstPosition, enemyShooterStates.enemyShooterMovement.LastPosition) < 0.5)
        {
            //   enemyShooterStates.enemyShooterAnimations.IsReturningInitialPosition = true;
            //  enemyShooterStates.enemyShooterAnimations.IsReturningFirstPosition = false;
            enemyShooterStates.enemyShooterMovement.followPlayer = new Vector3(enemyShooterStates.enemyShooterMovement.InitialPosition.x - enemyShooterStates.transform.position.x, 0, enemyShooterStates.enemyShooterMovement.InitialPosition.z - enemyShooterStates.transform.position.z).normalized * enemyShooterStates.Stats.Speed;

        }
        else
        {
         //   enemyShooterStates.enemyShooterAnimations.IsReturningFirstPosition = false;
         //   enemyShooterStates.enemyShooterAnimations.IsReturningInitialPosition = false;
            enemyShooterStates.enemyShooterMovement.followPlayer = new Vector3(enemyShooterStates.enemyShooterMovement.FirstPosition.x - enemyShooterStates.transform.position.x, 0, enemyShooterStates.enemyShooterMovement.FirstPosition.z - enemyShooterStates.transform.position.z).normalized * enemyShooterStates.Stats.Speed;
        }
        enemyShooterStates.enemyShooterMovement.controller.Move(enemyShooterStates.enemyShooterMovement.followPlayer * Time.deltaTime);



    }
}