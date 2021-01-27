using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject nearestEnemy;
    private float fireRate = 0;
    private float fireRefreshRate = 1f;
    private PlayerManager playerManager;
    private bool canShoot = true;
    [SerializeField]
    public RaycastHit raycastHit;
    [SerializeField]
    GameObject animatac;
    Animator a;
    public GameManager gm;

    public GameObject NearestEnemy { get => nearestEnemy; set => nearestEnemy = value; }


    // Start is called before the first frame update
    void Awake()
    {
        a = animatac.GetComponent<Animator>();
      
        playerManager = GetComponentInParent<PlayerManager>();
     //   nearestEnemy = GameObject.Find("Goblin");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Meat" && Input.GetKeyDown("f"))
        {


            playerManager.playerStats.Health +=  10;
            Destroy(other.gameObject);
   
        }
        
        if(other.tag == "House" && Input.GetKeyDown("g"))
        {

            if(gm.currentTimeOfDay > 0.70 || gm.currentTimeOfDay < 0.24)
            {

                gm.currentTimeOfDay = 0.25f;
                gm.fear -= 10;
            }

   
        }
    }

    private void Start()
    {
        fireRate = playerManager.playerStats.FireRate;
    }

    // Update is called once per frame
    void Update()
    {


        NearestEnemy = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).FirstOrDefault();

        if (NearestEnemy == null)
        {
            playerManager.playerAnimations.FocusedOnEnemy = false;
        }
        else
        {
            playerManager.playerAnimations.FocusedOnEnemy = true;
        }
        if (canShoot && Input.GetKeyDown("space"))
        {
            Debug.Log("Hola");
            StartCoroutine(Attack());
        }
    }
    public IEnumerator Attack()
    {
          //  fireRate = Time.time + fireRefreshRate;
            if (NearestEnemy == null)
            {
               
      
                
            }
            else
            {

            Vector3 hitDirection =  nearestEnemy.transform.position- transform.position;
            Vector3 animdirection =  (nearestEnemy.transform.position- transform.position).normalized;

            a.SetFloat("x", hitDirection.x);
            a.SetFloat("y", hitDirection.z);
           var ray = Physics.Raycast(this.transform.position, hitDirection, out raycastHit, 1.5f);
            Debug.DrawRay(this.transform.position, hitDirection *5, Color.black);

            if (ray)
            {
                if (raycastHit.collider.tag == "Enemy")
                {

                    gm.fear += 1;

                    var g = this.gameObject.transform.position;
                    GameObject j =  Instantiate(animatac, this.transform);
                    j.gameObject.GetComponent<Animator>().SetFloat("x", hitDirection.x);
                    j.gameObject.GetComponent<Animator>().SetFloat("y", hitDirection.z);
                    j.gameObject.GetComponent<Animator>().SetBool("atacando", true);
                    Debug.Log("Pegar");
                    nearestEnemy.GetComponent<IDamageable>().TakeHealth(playerManager.playerStats.Strength);

                   // animatac.gameObject.GetComponent<Animator>().SetBool("atacando", false);
                }
                else
                {
                    //var g = this.gameObject.transform.position;
                    //GameObject j = Instantiate(animatac, this.transform);
                    //j.gameObject.GetComponent<Animator>().SetFloat("x", hitDirection.x);
                    //j.gameObject.GetComponent<Animator>().SetFloat("y", hitDirection.z);
                    //j.gameObject.GetComponent<Animator>().SetBool("atacando", true);
                    //raycastHit.transform.gameObject.GetComponent<IDamageable>().TakeHealth(playerManager.playerStats.Strength);

                }

            }
        }

            canShoot = false;

            yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void SetFireRate(float fireRate)
    {
        this.fireRate = fireRate;
    }


    public void Attacking()
    {


    }
}
