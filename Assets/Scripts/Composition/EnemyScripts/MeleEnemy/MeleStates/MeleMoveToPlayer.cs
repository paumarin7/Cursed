using UnityEngine;

internal class MeleMoveToPlayer : IState
{

    private EnemyMeleStates enemyMovementMele;
    Vector3 playerDirection;
    public MeleMoveToPlayer(EnemyMeleStates enemyMovementMele)
    {
        this.enemyMovementMele = enemyMovementMele;
    }

    public void OnEnter()
    {
         playerDirection = (enemyMovementMele.Player.transform.position - enemyMovementMele.transform.position);


    }

    public void OnExit()
    {

        enemyMovementMele.enemyMeleAnimations.IsFollowing = false;
    }

    public void Tick()
    {
        enemyMovementMele.enemyMeleAnimations.IsFollowing = true;
        Debug.Log("following player");
        enemyMovementMele.animations.SetBool("Attacking",false);
          //  animator.SetBool("Idle",false);
         enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3((enemyMovementMele.Player.transform.position.x - enemyMovementMele.transform.position.x), 0, (enemyMovementMele.Player.transform.position.z - enemyMovementMele.transform.position.z)).normalized * enemyMovementMele.Stats.Speed;
         enemyMovementMele.enemyMeleMovement.controller.Move(enemyMovementMele.enemyMeleMovement.followPlayer * Time.deltaTime);
         enemyMovementMele.enemyMeleMovement.LastPosition = new Vector3(enemyMovementMele.Player.transform.position.x, enemyMovementMele.transform.position.y, enemyMovementMele.Player.transform.position.z);
         enemyMovementMele.enemyMeleMovement.FirstPosition = enemyMovementMele.transform.position;
        
    }
}