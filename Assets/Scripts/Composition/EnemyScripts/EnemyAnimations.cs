using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField]
    private bool idle = false;
    private bool attacking = false;
    [SerializeField]
    private bool isAlive = true;

    private bool isFollowing;
    private bool isReturningFirstPosition;
    private bool isReturningInitialPosition;



    private Animator animator;
    private EnemyMeleStates enemyMeleStates; 

    public bool Attacking { get => attacking; set => attacking = value; }
    public bool Idle { get => idle; set => idle = value; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }
    public bool IsFollowing { get => isFollowing; set => isFollowing = value; }
    public bool IsReturningFirstPosition { get => isReturningFirstPosition; set => isReturningFirstPosition = value; }
    public bool IsReturningInitialPosition { get => isReturningInitialPosition; set => isReturningInitialPosition = value; }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMeleStates = GetComponent<EnemyMeleStates>();
    }

    // Update is called once per frame
    void Update()
    {
        basicAnimation();
    }

    public void basicAnimation()
    {

        if (isAlive)
        {
            if (!Idle)
            {
                animator.SetLayerWeight(0, 1f);
                animator.SetLayerWeight(1, 0f);
                Attacking = false;

                if (IsFollowing)
                {
                    Attacking = false;
                    var direction = (enemyMeleStates.Player.transform.position - transform.position).normalized;
                    animator.SetFloat("x", direction.x);
                }
                else
                {
                    if (IsReturningFirstPosition)
                    {
                        var direction = (enemyMeleStates.enemyMeleMovement.LastPosition - transform.position).normalized;

                        animator.SetFloat("x", direction.x);
                    }
                    else if(IsReturningInitialPosition)
                    {
                        var direction = (enemyMeleStates.enemyMeleMovement.InitialPosition - transform.position).normalized;

                        animator.SetFloat("x", direction.x);
                    }
                    else
                    {
                        var direction = (enemyMeleStates.enemyMeleMovement.FirstPosition - transform.position).normalized;

                        animator.SetFloat("x", direction.x);
                    }


                }
            }
            else if (idle)
            {
                if (Attacking)
                {
                    var direction = (enemyMeleStates.Player.transform.position - transform.position).normalized;
                    animator.SetFloat("x", direction.x);
                    animator.SetLayerWeight(0, 0f);
                    animator.SetLayerWeight(1, 1f);
                    animator.SetBool("Attacking", true);
                }
                else if (idle)
                {
                    animator.SetLayerWeight(0, 1f);
                    animator.SetLayerWeight(1, 0f);
                    animator.SetFloat("x", 0);
                }

            }

        }
        else
        {
            var direction = (enemyMeleStates.Player.transform.position - transform.position).normalized;
            animator.SetFloat("x", direction.x);
            animator.SetLayerWeight(0, 0f);
            animator.SetLayerWeight(2, 1f);
            animator.SetBool("Death", true);
        }
        
    }
}
