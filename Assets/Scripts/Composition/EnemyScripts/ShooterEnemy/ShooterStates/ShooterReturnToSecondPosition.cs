using UnityEngine;

internal class ShooterReturnToSecondPosition:IState
{
    private EnemyShooterStates enemyShooterStates;

    public ShooterReturnToSecondPosition(EnemyShooterStates enemyShooterStates)
    {
        this.enemyShooterStates = enemyShooterStates;
    }

    public void OnEnter()
    {
      //  enemyShooterStates.enemyShooterAnimations.IsReturningInitialPosition = false;

    }

    public void OnExit()
    {

    }

    public void Tick()
    {

        Debug.Log("Return to second position");

       // enemyShooterStates.enemyShooterAnimations.IsFollowing = false;
        if (Vector2.Distance(enemyShooterStates.enemyShooterMovement.FirstPosition, enemyShooterStates.enemyShooterMovement.LastPosition) < 0.5)
        {
            //   enemyShooterStates.enemyShooterAnimations.IsReturningInitialPosition = true;
            //   enemyShooterStates.enemyShooterAnimations.IsReturningFirstPosition = false;
            enemyShooterStates.enemyShooterMovement.followPlayer = new Vector3(enemyShooterStates.enemyShooterMovement.InitialPosition.x - enemyShooterStates.transform.position.x, 0, enemyShooterStates.enemyShooterMovement.InitialPosition.z - enemyShooterStates.transform.position.z).normalized * enemyShooterStates.Stats.Speed;

        }
        else
        {
            //   enemyShooterStates.enemyShooterAnimations.IsReturningFirstPosition = true;
            //   enemyShooterStates.enemyShooterAnimations.IsReturningInitialPosition = false;
            enemyShooterStates.enemyShooterMovement.followPlayer = new Vector3(enemyShooterStates.enemyShooterMovement.LastPosition.x - enemyShooterStates.transform.position.x, 0, enemyShooterStates.enemyShooterMovement.LastPosition.z - enemyShooterStates.transform.position.z).normalized * enemyShooterStates.Stats.Speed;
        }
        enemyShooterStates.enemyShooterMovement.controller.Move(enemyShooterStates.enemyShooterMovement.followPlayer * Time.deltaTime);

    }
}