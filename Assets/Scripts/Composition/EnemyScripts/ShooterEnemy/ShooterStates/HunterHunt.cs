using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterHunt :   IState
{
    private EnemyShooterStates enemyShooterStates;
    private Delay delay;

    public HunterHunt(EnemyShooterStates enemyShooterStates, Delay delay)
    {
        this.enemyShooterStates = enemyShooterStates;
        this.delay = delay;
    }

    public void OnEnter()
    {
      //  Debug.Log("Attacking");
      //  enemyShooterStates.enemyShooterAnimations.Idle = true;
      //  enemyShooterStates.enemyShooterAnimations.Attacking = true;
  
    }

    public void OnExit()
    {
        //   enemyShooterStates.enemyShooterAnimations.Idle = false;
        //   enemyShooterStates.enemyShooterAnimations.Attacking = false;
           enemyShooterStates.CanShoot = false;
      //    enemyShooterStates.enemyShooterAnimations.Idle = true;
       //   enemyShooterStates.enemyShooterAnimations.Attacking = true;

    }

    public void Tick()
    {
        Debug.Log(enemyShooterStates.toHunt.Count+"HunterHunt");
            
         //   enemyShooterStates.toHunt.Remove(enemyShooterStates.animal);
            enemyShooterStates.Attacking();
        


    }
}
