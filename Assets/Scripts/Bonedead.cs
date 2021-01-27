using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonedead : MonoBehaviour
{

    public bool xd=false;
    public bool dx=true;
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
            StartCoroutine(destroybone());
        }
    }

    public IEnumerator destroybone()
    {

        if (!dx)
        {
            Destroy(this.gameObject);
        }
        yield return new WaitForSeconds(10);
        xd = false;
        dx = false;


    }
}
