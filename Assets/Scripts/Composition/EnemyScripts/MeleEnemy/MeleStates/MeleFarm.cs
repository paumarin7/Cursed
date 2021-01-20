using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleFarm : IState
{
    private EnemyMeleStates enemyMovementMele;
    Vector3 playerDirection;
    GameObject[] tofarm;
    GameObject farming;
    bool waiting = false;
    Collider collider;
    RaycastHit[] hit;

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
        //foreach (var item in tofarm)
        //{
        //    if (item.GetComponent<Wheat>().up == true && !waiting)
        //    {

        //        enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3((item.transform.position.x - enemyMovementMele.transform.position.x), 0, (item.transform.position.z - enemyMovementMele.transform.position.z)).normalized * enemyMovementMele.Stats.Speed;
        //        enemyMovementMele.enemyMeleMovement.controller.Move(enemyMovementMele.enemyMeleMovement.followPlayer * Time.deltaTime);
        //        Debug.Log((item.transform.position - enemyMovementMele.transform.position).magnitude);
        //    waiting = true;
        //    if ((item.transform.position - enemyMovementMele.transform.position).magnitude <= 0.9)
        //        {
        //            item.GetComponent<Wheat>().up = false;
        //            item.GetComponent<SpriteRenderer>().sprite = item.GetComponent<Wheat>().Wheat1;
        //            waiting = false;
        //        }

        //    }

        //}



        //TODO QUEUE BOXCASTALL




     //   hit = Physics.BoxCastAll(enemyMovementMele.transform.position, new Vector3(1,1,1), enemyMovementMele.transform.position, Quaternion.identity, 3, 9);

            foreach (var item in tofarm)
            {

             if (item.GetComponent<Wheat>().up == true && !waiting)
                {
                farming = item;
                waiting = true;
                     }
        }

        if (waiting)
        {
                    enemyMovementMele.enemyMeleMovement.followPlayer = new Vector3((farming.transform.position.x - enemyMovementMele.transform.position.x), 0, (farming.transform.position.z - enemyMovementMele.transform.position.z)).normalized* enemyMovementMele.Stats.Speed;
                     enemyMovementMele.enemyMeleMovement.controller.Move(enemyMovementMele.enemyMeleMovement.followPlayer* Time.deltaTime);
                    if ((farming.transform.position - enemyMovementMele.transform.position).magnitude <= 0.9)
                    {
                        farming.GetComponent<Wheat>().up = false;
                        farming.GetComponent<SpriteRenderer>().sprite = farming.GetComponent<Wheat>().Wheat1;
                waiting = false;
                    }
                }
        }




 

    
}
