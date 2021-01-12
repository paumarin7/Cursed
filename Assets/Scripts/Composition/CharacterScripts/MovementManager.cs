using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    // Clase que controla el movimiento del jugador

    private float Speed=0;
    private Vector3 moveDirection;
    private CharacterController controller;

    // Start is called before the first frame update
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    public void setVectorMovement(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;
    }

    public void setSpeedMovement(float speed)
    {
        this.Speed = speed;
    }

    public Vector3 getMoveDirection()
    {
        return moveDirection;
    }



    // Update is called once per frame
    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            moveDirection = (moveDirection) * Speed;
            controller.Move(moveDirection * Time.deltaTime) ;

        }
        else
        {
            moveDirection.y -= 5;
        }
        //animations
       
        controller.Move(moveDirection * Time.deltaTime);

    }

}
