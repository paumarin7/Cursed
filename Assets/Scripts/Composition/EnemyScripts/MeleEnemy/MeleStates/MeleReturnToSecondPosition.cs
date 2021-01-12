using UnityEngine;

internal class MeleReturnToSecondPosition: IState
{
    private EnemyMeleStates enemyMovementMele;

    public MeleReturnToSecondPosition(EnemyMeleStates enemyMovementMele)
    {
        this.enemyMovementMele = enemyMovementMele;

    }

    public void OnEnter()
    {
        enemyMovementMele.enemyMeleAnimations.IsReturningInitialPosition = false;

    }

    public void OnExit()
    {

    }

    public void Tick()
    {

        Debug.Log("Return to second position");

        enemyMovementMele.enemyMeleAnimations.IsFollowing = false;
        if (Vector2.Distance(enemyMovementMele.enemyMeleMovement.FirstPosition, enemyMovementMele.enemyMeleMovement.LastPosition) < 0.5)
        {
            enemyMovementMele.enemyMeleAnimations.IsReturningInitialPosition = true;
            enemyMovementMele.enemyMeleAnimations.IsReturningFirstPosition = false;
            enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3(enemyMovementMele.enemyMeleMovement.InitialPosition.x - enemyMovementMele.transform.position.x, 0, enemyMovementMele.enemyMeleMovement.InitialPosition.z - enemyMovementMele.transform.position.z).normalized * enemyMovementMele.Stats.Speed;
          
        }
        else
        {
            enemyMovementMele.enemyMeleAnimations.IsReturningFirstPosition = true;
            enemyMovementMele.enemyMeleAnimations.IsReturningInitialPosition = false;
            enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3(enemyMovementMele.enemyMeleMovement.LastPosition.x - enemyMovementMele.transform.position.x, 0, enemyMovementMele.enemyMeleMovement.LastPosition.z - enemyMovementMele.transform.position.z).normalized * enemyMovementMele.Stats.Speed;
        }
        enemyMovementMele.enemyMeleMovement.controller.Move(enemyMovementMele.enemyMeleMovement.followPlayer * Time.deltaTime);

    }
}