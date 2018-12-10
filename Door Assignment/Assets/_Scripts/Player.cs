using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public bool isEmpty;
    public bool RL;
    public bool platform;


    public GameObject launcher;
    public Transform launchPoint;
    public GameObject rocket;
    public GameObject grating;
    public Transform grateSpot;

	// Use this for initialization
	void Start ()
    {
        isEmpty = true;
        RL = false;
        platform = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1) && !isEmpty)
        {
                if (RL)
                {
                Instantiate(rocket, launchPoint.position, transform.rotation);
                //Instantiate(rocket, launchPoint);
                    launcher.SetActive(false);
                    RL = false;
                    isEmpty = true;
                }

                /*else if (platform)
                {
                    grating.SetActive(false);
                    platform = false;
                    isEmpty = true;
                }*/
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) && isEmpty)
        {
            if (other.gameObject.tag == "Forcefield")
            {
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == "Rocket Launcher")
            {
                Destroy(other.gameObject);
                launcher.SetActive(true);
                isEmpty = false;
                RL = true;
            }

            if (other.gameObject.tag == "Platform")
            {
                Destroy(other.gameObject);
                grating.SetActive(true);
                isEmpty = false;
                platform = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deathbox")
        {
            SceneManager.LoadScene("Door Level");
            //SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        if (other.gameObject.tag == "Crossing" && platform)
        {
            Instantiate(grating, grateSpot);

            grating.SetActive(false);
            platform = false;
            isEmpty = true;
        }
    }
}
