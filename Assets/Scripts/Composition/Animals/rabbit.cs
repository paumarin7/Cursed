using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit : MonoBehaviour, IDamageable
{

    public bool arein = false;

    public Animator animator;

    public float speed;
    public float randomX;
    public float randomZ;
    public float minWaitTime;
    public float maxWaitTime;
    private Vector3 currentRandomPos;
    Vector3 currentPos;


    public GameObject Almorir;

    void Start()
    {
        PickPosition();

    }

    void PickPosition()
    {

            currentRandomPos = new Vector3(this.transform.position.x -   Random.Range(-randomX, randomX), 0,this.transform.position.z - Random.Range(-randomZ, randomZ));
  

  
        StartCoroutine(MoveToRandomPos());

    }

    IEnumerator MoveToRandomPos()
    {
        animator.SetBool("moviendose", true);
        float i = 0.0f;
        float rate = 1.0f / speed;
        currentPos = transform.position;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(currentPos, currentRandomPos, i);
            yield return null;
        }

        float randomFloat = Random.Range(0.0f, 1.0f); // Create %50 chance to wait
        if (randomFloat < 0.5f)
            StartCoroutine(WaitForSomeTime());
        else
            PickPosition();
    }

    IEnumerator WaitForSomeTime()
    {
        animator.SetBool("moviendose", false);
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        PickPosition();
    }

    public void TakeHealth(float damage)
    {
        almorir();
    }

    private void Update()
    {

        var direction = (currentPos - currentRandomPos).normalized;
        animator.SetFloat("x", direction.x);
    }

    public void almorir()
    {
        GameObject dead = Instantiate(Almorir, this.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }

}
