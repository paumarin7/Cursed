using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterStates : MonoBehaviour, IEnemyStates
{

    private StateMachine shooterStateMachine;
    public EnemyShooterAnimations enemyShooterAnimations;
    public EnemyShooterMovement enemyShooterMovement;
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
        enemyShooterAnimations = GetComponent<EnemyShooterAnimations>();
        enemyShooterMovement = GetComponent<EnemyShooterMovement>();
        movementManager = GetComponent<MovementManager>();
        delay = new Delay(Stats.FireRate);
        canShoot = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        animations = GetComponent<Animator>();


        shooterStateMachine = new StateMachine();

        var searchPlayer = new ShooterSearchPlayer(this);
        var moveToPlayer = new ShooterMoveToPlayer(this);
        var returnToFirstPosition = new ShooterReturnToFirstPosition(this);
        var returnToSecondPosition = new ShooterReturnToSecondPosition(this);
        var attack = new ShooterAttack(this, delay);
        var waitingForAttack = new ShooterWaitingForAttack(this, delay);
        var death = new ShooterDeath(this);

        shooterStateMachine.AddAnyTransition(death, () => !Stats.IsAlive);
        shooterStateMachine.AddAnyTransition(moveToPlayer, () => enemyShooterMovement.hitPlayer.collider.tag == "Player" && enemyShooterMovement.playerDirection.magnitude > enemyShooterMovement.maxRange);
        //   meleStateMachine.AddAnyTransition(returnToFirstPosition, () => enemyMeleMovement.hitPlayer.collider.tag != "Player" && enemyMeleMovement.Returning);
        shooterStateMachine.AddTransition(returnToSecondPosition, returnToFirstPosition, () => enemyShooterMovement.hitPlayer.collider.tag != "Player" && enemyShooterMovement.Returning);
        shooterStateMachine.AddAnyTransition(returnToSecondPosition, () => enemyShooterMovement.hitPlayer.collider.tag != "Player" && !enemyShooterMovement.Returning);
        shooterStateMachine.AddAnyTransition(attack, () => enemyShooterMovement.playerDirection.magnitude < enemyShooterMovement.maxRange && canShoot);
        shooterStateMachine.AddAnyTransition(waitingForAttack, () => enemyShooterMovement.playerDirection.magnitude < enemyShooterMovement.maxRange && !canShoot);


        At(returnToSecondPosition, returnToFirstPosition, () => enemyShooterMovement.hitPlayer.collider.tag != "Player" && enemyShooterMovement.Returning);
        shooterStateMachine.SetState(returnToFirstPosition);
        void At(IState to, IState from, Func<bool> condition) => shooterStateMachine.AddTransition(to, from, condition);

        canShoot = true;
    }


    public void canShootTrue()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        shooterStateMachine.Tick();
    }

    public IEnumerator Attack()
    {
        //  fireRate = Time.time + fireRefreshRate;
        if (enemyShooterMovement.hitPlayer.collider.tag == "Player")
        {
            var bullet = GetComponentInChildren<IWeapon>();
            bullet.SetNearestEnemy(player);
            bullet.SetHitted("Enemy");
            bullet.Attack();

        }
        canShoot = false;

        yield return new WaitForSeconds(Stats.FireRate);
        canShoot = true;
    }


    public void Attacking()
    {

                StartCoroutine(Attack());
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}

