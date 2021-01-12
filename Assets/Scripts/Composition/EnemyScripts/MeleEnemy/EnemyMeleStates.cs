using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleStates : MonoBehaviour
{
    private StateMachine meleStateMachine;
    public EnemyAnimations enemyMeleAnimations;
    public EnemyMeleMovement enemyMeleMovement;
    public MovementManager movementManager;
    private GameObject player;
    public Animator animations;
    public Stats Stats;
    private Delay delay;

    [SerializeField]
    private bool canShoot;
    public GameObject Player { get => player; set => player = value; }
    public bool CanShoot { get => canShoot; set => canShoot = value; }


    // Start is called before the first frame update
    void Start()
    {
        Stats = GetComponent<Stats>();
        enemyMeleAnimations = GetComponent<EnemyAnimations>();
        enemyMeleMovement = GetComponent<EnemyMeleMovement>();
        movementManager = GetComponent<MovementManager>();
        delay = new Delay(Stats.FireRate);
        canShoot = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        animations = GetComponent<Animator>();


        meleStateMachine = new StateMachine();

        var searchPlayer = new MeleSearchPlayer(this);
        var moveToPlayer = new MeleMoveToPlayer(this);
        var returnToFirstPosition = new MeleReturnToFirstPosition(this);
        var returnToSecondPosition = new MeleReturnToSecondPosition(this);
        var attack = new MeleAttack(this, delay);
        var waitingForAttack = new MeleWaitingForAttack(this, delay);
        var death = new MeleDeath(this);

        meleStateMachine.AddAnyTransition(death, () => !Stats.IsAlive);
        meleStateMachine.AddAnyTransition(moveToPlayer, () => enemyMeleMovement.hitPlayer.collider.tag == "Player" && enemyMeleMovement.playerDirection.magnitude > enemyMeleMovement.minRange);
        //   meleStateMachine.AddAnyTransition(returnToFirstPosition, () => enemyMeleMovement.hitPlayer.collider.tag != "Player" && enemyMeleMovement.Returning);
        meleStateMachine.AddTransition(returnToSecondPosition, returnToFirstPosition, () => enemyMeleMovement.hitPlayer.collider.tag != "Player" && enemyMeleMovement.Returning);
        meleStateMachine.AddAnyTransition(returnToSecondPosition, () => enemyMeleMovement.hitPlayer.collider.tag != "Player" && !enemyMeleMovement.Returning);
        meleStateMachine.AddAnyTransition(waitingForAttack, () => enemyMeleMovement.playerDirection.magnitude < enemyMeleMovement.minRange && !delay.IsReady);
        meleStateMachine.AddAnyTransition(attack, () => enemyMeleMovement.playerDirection.magnitude < enemyMeleMovement.minRange && delay.IsReady);


        At(returnToSecondPosition, returnToFirstPosition, () => enemyMeleMovement.hitPlayer.collider.tag != "Player" && enemyMeleMovement.Returning);
        meleStateMachine.SetState(returnToFirstPosition);
        void At(IState to, IState from, Func<bool> condition) => meleStateMachine.AddTransition(to, from, condition);

    }

    // Update is called once per frame
    void Update()
    {
        meleStateMachine.Tick();
    }

    public void Attack()
    { 
        if (delay.IsReady)
        {

            delay.Reset();
        }
    }
    public void canShootTrue()
    {
        canShoot = true;
    }



    public void TakeHealth()
    {
        player.GetComponent<Stats>().TakeHealth(Stats.Strength);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    //public void checkPlayer()
    //{
    //    RaycastHit hitPlayer;


    //    Vector3 playerDirection = (Player.transform.position - transform.position);


    //    //Move To Player
    //    if (Physics.Raycast(transform.position, playerDirection, out hitPlayer, 50))
    //    {

    //        Debug.DrawRay(transform.position, playerDirection, Color.black);
    //        if (hitPlayer.collider.tag == "Player")
    //        {

    //            if (playerDirection.magnitude > minRange)
    //            {
    //                animations.SetBool("Attacking",true);
    //                animations.Idle = false;
    //                IsFollowing = true;
    //                followPlayer = new Vector3((Player.transform.position.x - transform.position.x), 0, (Player.transform.position.z - transform.position.z)).normalized * Stats.Speed;
    //                controller.Move(followPlayer * Time.deltaTime);

    //                LastPosition = Player.transform.position;
    //                FirstPosition = transform.position;
    //            }
    //            else
    //            {
    //                animations.Idle = true;
    //                animations.Attacking = true;
    //                player.GetComponent<Stats>().TakeHealth(GetComponent<Stats>().Strength);
    //                controller.Move(Vector3.zero * Time.deltaTime);

    //            }
    //        }
    //        else
    //        {
    //            if (Returning)
    //            {
    //                animations.Idle = false;

    //                IsFollowing = false;

    //                if (Vector2.Distance(FirstPosition, LastPosition) < 0.5)
    //                {
    //                    followPlayer = new Vector3(InitialPosition.x - transform.position.x, 0, InitialPosition.z - transform.position.z).normalized * Stats.Speed;

    //                }
    //                else
    //                {
    //                    followPlayer = new Vector3(FirstPosition.x - transform.position.x, 0, FirstPosition.z - transform.position.z).normalized * Stats.Speed;
    //                }
    //                controller.Move(followPlayer * Time.deltaTime);
    //                if (Vector2.Distance(transform.position, FirstPosition) < 0.03)
    //                {
    //                    Returning = false;
    //                }
    //            }
    //            else
    //            {

    //                animations.Idle = false;
    //                IsFollowing = false;


    //                if (Vector2.Distance(FirstPosition, LastPosition) < 0.5)
    //                {
    //                    followPlayer = new Vector3(InitialPosition.x - transform.position.x, 0, InitialPosition.z - transform.position.z).normalized * Stats.Speed;

    //                }
    //                else
    //                {
    //                    followPlayer = new Vector3(LastPosition.x - transform.position.x, 0, LastPosition.z - transform.position.z).normalized * Stats.Speed;
    //                }
    //                controller.Move(followPlayer * Time.deltaTime);
    //                if (Vector2.Distance(transform.position, LastPosition) < 0.03)
    //                {
    //                    Returning = true;
    //                }
    //            }
    //        }

    //    }
    //}
}
