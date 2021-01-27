using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{

    public bool up=false;
    SpriteRenderer renderer;
    [SerializeField]
    public Sprite Wheat2;
    [SerializeField]
    public Sprite Wheat1;
    // Start is called before the first frame update
    void Start()
    {

        renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown()
    {
       int seconds = Random.Range(30, 60);
        while ( true)
        {
            yield return new WaitForSeconds(seconds);
            up=true;
            renderer.sprite = Wheat2;
            seconds = Random.Range(3, 10);
        }
    }
}
