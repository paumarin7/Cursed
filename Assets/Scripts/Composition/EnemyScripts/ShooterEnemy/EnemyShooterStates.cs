using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterStates : MonoBehaviour, IEnemyStates
{
     public List<GameObject> toHunt = new List<GameObject>();

    private StateMachine shooterStateMachine;
    public EnemyShooterAnimations enemyShooterAnimations;
    public EnemyShooterMovement enemyShooterMovement;
    public MovementManager movementManager;
    [SerializeField]
    private GameObject player;
    public GameObject animal;
    public Animator animations;
    public Stats Stats;
    private GameManager gameManager;
    private Delay delay;
    public bool inForest = false;
    [SerializeField]
    public GameObject forest;
    [SerializeField]
    public GameObject bed;

    public RaycastHit hitAnimal;

    public Vector3 animalDirection;

    public bool hunt = true;

    [SerializeField]
    private bool canShoot;
    public GameObject Player { get => player; set => player = value; }
    public bool CanShoot { get => canShoot; set => canShoot = value; }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
        var moveToHunt = new MoveToHunt(this);
        var moveToForest = new HunterMoveToForest(this);
        var moveToBed = new HunterMoveToHouse(this);
        var searchunt = new HunterSearchHunt(this);
        var hunting = new HunterHunt(this, delay);
        var returnToFirstPosition = new ShooterReturnToFirstPosition(this);
        var returnToSecondPosition = new ShooterReturnToSecondPosition(this);
        var attack = new ShooterAttack(this, delay);
        var waitingForAttack = new ShooterWaitingForAttack(this, delay);
        var death = new ShooterDeath(this);

        shooterStateMachine.AddAnyTransition(death, () => !Stats.IsAlive);


        shooterStateMachine.AddAnyTransition(moveToPlayer, () => hunt == false && enemyShooterMovement.hitPlayer.collider.tag == "Player" && enemyShooterMovement.playerDirection.magnitude > enemyShooterMovement.maxRange);
        shooterStateMachine.AddAnyTransition(attack, () => hunt == false && enemyShooterMovement.playerDirection.magnitude < enemyShooterMovement.maxRange && canShoot);
        shooterStateMachine.AddAnyTransition(waitingForAttack, () => hunt == false && enemyShooterMovement.playerDirection.magnitude < enemyShooterMovement.maxRange && !canShoot);
             
        shooterStateMachine.AddAnyTransition(moveToBed, () =>hunt == true && gameManager.currentTimeOfDay >= 0.75 || gameManager.currentTimeOfDay <= 0.25);
        shooterStateMachine.AddAnyTransition(moveToForest, () =>hunt == true &&  (gameManager.currentTimeOfDay >= 0.26 || gameManager.currentTimeOfDay <= 0.74) && !inForest);
        shooterStateMachine.AddAnyTransition(searchunt, () => hunt == true && inForest && animal == null);

        shooterStateMachine.AddAnyTransition(moveToHunt, () => hunt == true && animal != null  && animalDirection.magnitude > enemyShooterMovement.maxRange);
        shooterStateMachine.AddAnyTransition(hunting, () => hunt == true && inForest &&  animal != null&& animalDirection.magnitude < enemyShooterMovement.maxRange && canShoot);
        shooterStateMachine.AddAnyTransition(waitingForAttack, () =>    hunt == true &&  inForest  && animalDirection.magnitude < enemyShooterMovement.maxRange && !canShoot && animal !=null);


        shooterStateMachine.AddTransition(returnToSecondPosition, returnToFirstPosition, () => enemyShooterMovement.hitPlayer.collider.tag != "Player" && enemyShooterMovement.Returning);
        shooterStateMachine.AddAnyTransition(returnToSecondPosition, () => enemyShooterMovement.hitPlayer.collider.tag != "Player" && !enemyShooterMovement.Returning);


        At(returnToSecondPosition, returnToFirstPosition, () => enemyShooterMovement.hitPlayer.collider.tag != "Player" && enemyShooterMovement.Returning);
        shooterStateMachine.SetState(returnToFirstPosition);
        void At(IState to, IState from, Func<bool> condition) => shooterStateMachine.AddTransition(to, from, condition);

        canShoot = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Forest")
        {
            inForest = true;
        }
        else
        {
            inForest = false;
        }

        if (other.tag == "House")
        {

            Stats.Health = 10;
        }

    }
    public void canShootTrue()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        shooterStateMachine.Tick();
        Debug.Log(toHunt.Count);

        if(gameManager.fear <= 0)
        {
            hunt = true;
        }
        else
        {
            hunt = false;
        }

        if(animal != null)
        {
            animalDirection = animal.transform.position - transform.position;
            Physics.Raycast(transform.position, animalDirection, out hitAnimal, 50);
            Debug.DrawRay(transform.position, animalDirection*3);
        }


        Debug.Log(animalDirection.magnitude > enemyShooterMovement.maxRange);

    }

    public IEnumerator Attack()
    {
      //  fireRate = Time.time + fireRefreshRate;
        if (hunt == false && enemyShooterMovement.hitPlayer.collider.tag == "Player")
        {
            var bullet = GetComponentInChildren<IWeapon>();
            bullet.SetNearestEnemy(player);
            bullet.SetHitted("Enemy");
            bullet.Attack();
        }
        if (hunt == true)
        {

            var bullet = GetComponentInChildren<IWeapon>();
            bullet.SetNearestEnemy(animal);
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

