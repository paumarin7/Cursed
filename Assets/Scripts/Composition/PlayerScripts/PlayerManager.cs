using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerManager : MonoBehaviour, IDamageable
{

    public MovementManager playerMovementManager;
    public Stats playerStats;
    public PlayerAnimations playerAnimations;
    public PlayerAttack playerAttack;


    public void TakeHealth(float damage)
    {
        playerStats.Health-=damage;
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerStats = GetComponent<Stats>();
        playerMovementManager = GetComponent<MovementManager>();
        playerAnimations = GetComponent<PlayerAnimations>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {

        playerMovementManager.setSpeedMovement(playerStats.Speed);
        playerAnimations.PlayMoveAnimation(playerMovementManager.getMoveDirection());
    }
}
