using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject playerHealthBarUi;
    public GameObject[] players;
    GameObject cameraMain;
    public GameObject cameraIcon;
    Button shootButton;
    GameObject actualPlayer;

    // Start is called before the first frame update
    void Start()
    {
        actualPlayer = null;
        players = GameObject.FindGameObjectsWithTag("Player");
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
        cameraIcon = GameObject.Find("PlayerIconCamera");
        shootButton = GameObject.Find("ShootButton").GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (players.Length == 1)
        {
            players[0].layer = 8;
            shootButton.onClick.AddListener(players[0].GetComponentInChildren<PlayerAttack>().Attacking);
            players[0].GetComponent<Stats>().enabled = true;
            //     players[0].GetComponent<Stats>().IsActive = true;
            cameraMain.transform.parent = players[0].gameObject.transform;
            cameraIcon.transform.parent = players[0].gameObject.transform;
            cameraMain.transform.position = new Vector3(players[0].transform.position.x, 3, players[0].transform.position.z);
            cameraIcon.transform.position = new Vector3(players[0].transform.position.x - 0.02999997f, cameraIcon.transform.position.y, players[0].transform.position.z - 0.75f);
            playerHealthBarUi.GetComponent<Image>().fillAmount = players[0].GetComponent<Stats>().Health / players[0].GetComponent<Stats>().MaxHealth;
        }
        else
        {
            for (int j = 0; j < Input.touchCount; j++)
            {
                RaycastHit hit;

                if (Input.touches[j].phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.touches[j].position); // transform position of the touch to real game position
                    if (Physics.Raycast(ray, out hit))
                    {
                        for (int i = 0; i < players.Length; i++)
                        {
                            if (hit.collider.tag == "Player")
                            {
                                if (hit.collider.name == players[i].name)
                                {
                                    actualPlayer = players[i];
                                    players[i].layer = 8;
                                    players[i].GetComponent<Stats>().enabled = true;
                                    players[i].GetComponent<MovementManager>().enabled = true;
                                    players[i].GetComponent<PlayerAnimations>().enabled = true;
                                    Debug.Log(players[i].name);
                                    //      players[i].GetComponent<PlayerStats>().IsActive = true;
                                    cameraMain.transform.parent = players[i].gameObject.transform;
                                    cameraIcon.transform.parent = players[i].gameObject.transform;
                                    cameraMain.transform.position = new Vector3(players[i].transform.position.x, 3, players[i].transform.position.z);
                                    Debug.Log(cameraIcon.transform.position.y);
                                    cameraIcon.transform.position = new Vector3(players[i].transform.position.x - 0.02999997f, players[i].transform.position.y + 0.41f, players[i].transform.position.z - 0.75f);
                                    shootButton.onClick.AddListener(players[i].GetComponentInChildren<PlayerAttack>().Attacking);

                                }
                                else
                                {
                                    players[i].layer = 0;
                                    shootButton.onClick.RemoveListener(players[i].GetComponentInChildren<PlayerAttack>().Attacking);
                                    //    players[i].GetComponent<Stats>().IsActive = false;
                                    players[i].GetComponent<Stats>().enabled = false;
                                    players[i].GetComponent<MovementManager>().enabled = false;
                                    players[i].GetComponent<PlayerAnimations>().enabled = false;

                                }
                            }
                        }
                    }
                }
            }
        }

        if (actualPlayer != null)
        {
            playerHealthBarUi.GetComponent<Image>().fillAmount = actualPlayer.GetComponent<Stats>().Health / actualPlayer.GetComponent<Stats>().MaxHealth;

        }



    }


}
