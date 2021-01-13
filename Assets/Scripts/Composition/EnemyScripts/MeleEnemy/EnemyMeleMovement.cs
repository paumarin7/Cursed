using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleMovement : MonoBehaviour
{
    EnemyMeleStates enemyMeleStates;
    [SerializeField]
    private Vector3 lastPosition;
    [SerializeField]
    private Vector3 firstPosition;
    [SerializeField]
    private Vector3 initialPosition;

    [SerializeField]
    private bool returning = false;

    public CharacterController controller;
    public RaycastHit hitPlayer;

    public float minRange;

    public Vector3 followPlayer;
    public Vector3 playerDirection;

    public Vector3 FirstPosition { get => firstPosition; set => firstPosition = value; }
    public Vector3 InitialPosition { get => initialPosition; set => initialPosition = value; }
    public Vector3 LastPosition { get => lastPosition; set => lastPosition = value; }
    public bool Returning { get => returning; set => returning = value; }


    // Start is called before the first frame update

    void Awake()
    {

        InitialPosition = transform.position;
        controller = GetComponent<CharacterController>();

        enemyMeleStates = GetComponent<EnemyMeleStates>();

    }

    public void SetMinRange(float minRange)
    {
        this.minRange = minRange;
    }
    void Start()
    {
        SetMinRange(enemyMeleStates.Stats.Distance);
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, FirstPosition) < 0.03f)
        {
            Returning = false;
        }
        else if (Vector2.Distance(transform.position, LastPosition) < 0.03f)
        {
            Returning = true;
        }
        Physics.Raycast(transform.position, playerDirection, out hitPlayer, 50);
        Debug.DrawRay(transform.position, playerDirection, Color.black);

    }
    // Update is called once per frame
    void Update()
    {

        playerDirection = new Vector3(enemyMeleStates.Player.transform.position.x - transform.position.x, transform.position.y, enemyMeleStates.Player.transform.position.z - transform.position.z);


    }
}
