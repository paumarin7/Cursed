using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private Vector3 moveDirection;
    PlayerManager playerManager;
    [SerializeField]
    private bool focusedOnEnemy;
    private bool isMoving;

    public bool FocusedOnEnemy { get => focusedOnEnemy; set => focusedOnEnemy = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection.x == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }


        if (isMoving)
        {

                animator.SetFloat("x", moveDirection.x);
                animator.SetFloat("z", moveDirection.z);
        
        }
        else
        {
            animator.SetFloat("x", 0);
            animator.SetFloat("z", 0);
        }


    }


    public void PlayMoveAnimation(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;
    }
}
