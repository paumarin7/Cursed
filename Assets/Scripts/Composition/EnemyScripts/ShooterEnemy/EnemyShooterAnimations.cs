using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterAnimations : MonoBehaviour
{
    [SerializeField]
    private bool idle = false;
    private bool attacking = false;
    [SerializeField]
    private bool isAlive = true;
    private bool isFollowing = false;
    [SerializeField]

    private bool isReturningFirstPosition;

     public Animator animator;
    private EnemyShooterStates enemyShooterStates;

    public bool Attacking { get => attacking; set => attacking = value; }
    public bool Idle { get => idle; set => idle = value; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }

    public bool IsFollowing { get => isFollowing; set => isFollowing = value; }
    public bool IsReturningFirstPosition { get => isReturningFirstPosition; set => isReturningFirstPosition = value; }
    public bool IsReturningInitialPosition { get; internal set; }


    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        animator = GetComponent<Animator>();
        enemyShooterStates = GetComponent<EnemyShooterStates>();
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
                    var direction = (enemyShooterStates.Player.transform.position - transform.position).normalized;
                    animator.SetFloat("x", direction.x);
                }
                else
                {
                    if (IsReturningFirstPosition)
                    {
                        var direction = (enemyShooterStates.enemyShooterMovement.LastPosition - transform.position).normalized;

                        animator.SetFloat("x", direction.x);
                    }
                    else if (IsReturningInitialPosition)
                    {
                        var direction = (enemyShooterStates.enemyShooterMovement.InitialPosition - transform.position).normalized;

                        animator.SetFloat("x", direction.x);
                    }
                    else
                    {
                        var direction = (enemyShooterStates.enemyShooterMovement.FirstPosition - transform.position).normalized;

                        animator.SetFloat("x", direction.x);
                    }


                }
            }
            else if (idle)
            {
                if (Attacking)
                {
                    var direction = (enemyShooterStates.Player.transform.position - transform.position).normalized;
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
            var direction = (enemyShooterStates.Player.transform.position - transform.position).normalized;
            animator.SetFloat("x", direction.x);
            animator.SetLayerWeight(0, 0f);
            animator.SetLayerWeight(1, 1f);
            animator.SetBool("Death", true);
        }

    }

}
