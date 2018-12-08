using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public bool isEmpty;
    public bool RL;
    public bool platform;

	// Use this for initialization
	void Start ()
    {
        isEmpty = true;
        RL = false;
        platform = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space) && !isEmpty)
        {
            if (RL)
            {
                //code for firing rocket
                //code for dropping launcher
                RL = false;
                isEmpty = true;
            }
            else if (platform)
            {
                //code for dropping platform
                platform = false;
                isEmpty = true;
            }
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Forcefield" && Input.GetKeyDown(KeyCode.Space) && isEmpty)
            Destroy(gameObject);

        if (other.gameObject.tag == "Rocket Launcher" && Input.GetKeyDown(KeyCode.Space) && isEmpty)
        {
            //code for picking up the launcher
            isEmpty = false;
            RL = true;
        }

        if (other.gameObject.tag == "Platform" && Input.GetKeyDown(KeyCode.Space) && isEmpty)
        {
            //code for picking up the platform
            isEmpty = false;
            platform = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deathbox")
        {
            SceneManager.LoadScene("Door Level");
        }
    }
}
