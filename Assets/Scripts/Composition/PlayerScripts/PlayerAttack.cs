using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private GameObject nearestEnemy;
    private float fireRate = 0;
    private float fireRefreshRate = 1f;
    private PlayerManager playerManager;
    private bool canShoot = true;

    public GameObject NearestEnemy { get => nearestEnemy; set => nearestEnemy = value; }


    // Start is called before the first frame update
    void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
     //   nearestEnemy = GameObject.Find("Goblin");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("f"))
        {
            if(GetComponent<BasicBullet>()!=null)
            {
                this.gameObject.AddComponent<FireBullet>();
                Destroy(this.GetComponent<BasicBullet>());
            }else if (GetComponent<FireBullet>() != null)
            {
                this.gameObject.AddComponent<BasicBullet>();
                Destroy(this.GetComponent<FireBullet>());
            }
        }
        NearestEnemy = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).FirstOrDefault();
        if (NearestEnemy == null)
        {
            playerManager.playerAnimations.FocusedOnEnemy = false;
            GetComponent<IWeapon>().SetNearestEnemy(null);
        }
        else
        {
            playerManager.playerAnimations.FocusedOnEnemy = true;
            GetComponent<IWeapon>().SetNearestEnemy(NearestEnemy);
        }
    }
    public IEnumerator Attack()
    {
          //  fireRate = Time.time + fireRefreshRate;
            if (NearestEnemy == null)
            {
               
                GetComponent<IWeapon>().Attack();
                
            }
            else
            {
            var weapon = GetComponent<IWeapon>();
            weapon.SetHitted("Player");
            weapon.Attack();
    
            
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
        if (canShoot && !playerManager.playerAnimations.IsMoving)
        {
            StartCoroutine(Attack());
        }

    }
}
