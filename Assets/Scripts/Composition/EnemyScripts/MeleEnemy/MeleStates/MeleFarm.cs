using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleFarm : IState
{
    private EnemyMeleStates enemyMovementMele;
    Vector3 playerDirection;
    GameObject[] tofarm;

    public MeleFarm(EnemyMeleStates enemyMovementMele)
    {
        this.enemyMovementMele = enemyMovementMele;
    }

    public void OnEnter()
    {
        tofarm = GameObject.FindGameObjectsWithTag("Wheat");
    }

    public void OnExit()
    {
        enemyMovementMele.inWheatFarm = false;
    }

    public void Tick()
    {
        Debug.Log("farming");
            foreach (var item in tofarm)
            {
                if (item.GetComponent<Wheat>().up == true)
                {

                    while(item.GetComponent<Wheat>().up == true)
                {
                    enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3((item.transform.position.x - enemyMovementMele.transform.position.x), 0, (item.transform.position.z - enemyMovementMele.transform.position.z)).normalized * enemyMovementMele.Stats.Speed;
                    enemyMovementMele.enemyMeleMovement.controller.Move(enemyMovementMele.enemyMeleMovement.followPlayer * Time.deltaTime);
                    Debug.Log((item.transform.position - enemyMovementMele.transform.position).magnitude);
                    if ((item.transform.position - enemyMovementMele.transform.position).magnitude <= 0.9)
                    {
                        item.GetComponent<Wheat>().up = false;
                        item.GetComponent<SpriteRenderer>().sprite = item.GetComponent<Wheat>().Wheat1;
                    }
                }
                    

                }
            }
        
       

    }
}
