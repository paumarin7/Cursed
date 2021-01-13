using UnityEngine;

internal class MeleReturnToFirstPosition: IState
{

    private Animator animator;
    private EnemyMeleStates enemyMovementMele;
    public MeleReturnToFirstPosition(EnemyMeleStates enemyMovementMele)
    {
        this.enemyMovementMele = enemyMovementMele;

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

        enemyMovementMele.enemyMeleAnimations.IsFollowing = false;

        Debug.Log("Return to first position");
        //   animator.SetBool("Idle", false);
        if (Vector2.Distance(enemyMovementMele.enemyMeleMovement.FirstPosition, enemyMovementMele.enemyMeleMovement.LastPosition) < 0.5)
            {
            enemyMovementMele.enemyMeleAnimations.IsReturningInitialPosition = true;
            enemyMovementMele.enemyMeleAnimations.IsReturningFirstPosition = false;
            enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3(enemyMovementMele.enemyMeleMovement.InitialPosition.x - enemyMovementMele.transform.position.x, 0, enemyMovementMele.enemyMeleMovement.InitialPosition.z - enemyMovementMele.transform.position.z).normalized * enemyMovementMele.Stats.Speed;

        }
            else
            {
            enemyMovementMele.enemyMeleAnimations.IsReturningFirstPosition = false;
            enemyMovementMele.enemyMeleAnimations.IsReturningInitialPosition = false;
            enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3(enemyMovementMele.enemyMeleMovement.FirstPosition.x - enemyMovementMele.transform.position.x, 0, enemyMovementMele.enemyMeleMovement.FirstPosition.z - enemyMovementMele.transform.position.z).normalized * enemyMovementMele.Stats.Speed;
            }
        enemyMovementMele.enemyMeleMovement.controller.Move(enemyMovementMele.enemyMeleMovement.followPlayer * Time.deltaTime);



    }
}