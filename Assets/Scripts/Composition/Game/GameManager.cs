using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject playerHealthBarUi;
    [SerializeField]
    public  SoundHandler sh;
   

    [SerializeField]
    public  int fear;
    [SerializeField]
    GameObject player;
    //Start Ciclo dia noche #DN
    public Light sun;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;

    public bool vps = false;

    float sunInitialIntensity;
    //End Ciclo dia noche \#DN

    private void Start()
    {
        fear = 0;
        
        // #DN
        sunInitialIntensity = sun.intensity;
    }
    private void Update()
    {
        // #DN
        UpdateSun();
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
        // \#DN
       playerHealthBarUi.GetComponent<Image>().fillAmount = player.GetComponent<Stats>().Health / player.GetComponent<Stats>().MaxHealth;
        if (!vps)
        {
            vps = true;
            StartCoroutine(VidaPorSegundo());
        }

        

    }


    public IEnumerator VidaPorSegundo()
    {

        player.GetComponent<Stats>().TakeHealth(1);
        yield return new WaitForSeconds(1);
        vps = false;

    }


    // #DN
    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }


}
