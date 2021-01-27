using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnrabbits : MonoBehaviour
{

    public bool xd=false;
    public float time;
    public GameObject rabbit;
    public float randomX;
    public float randomZ;
    public float minWaitTime;
    public float maxWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!xd)
        {
            xd = true;
            StartCoroutine(spawnrabits());
        }

    }

    public  IEnumerator spawnrabits()
    {
        Instantiate(rabbit, new Vector3(Random.Range(this.transform.position.x - randomX, this.transform.position.x + randomX), 0, Random.Range(this.transform.position.z - randomZ, this.transform.position.z + randomZ)),Quaternion.identity);

       yield return new  WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        xd = false;


    }
}
