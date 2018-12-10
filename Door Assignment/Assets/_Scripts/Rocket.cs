using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float moveSpeed;
    private Vector3 direction;
    private Rigidbody _rb;

    //private Vector3 direction;

	// Use this for initialization
	void Start ()
    {
        _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position = transform.Translate.;
        //_rb.AddForce(direction * -moveSpeed, ForceMode.Impulse);
        transform.position += Time.deltaTime * moveSpeed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Door")
            {
                Destroy(other.gameObject);
            }

        Destroy(gameObject);
    }

}
