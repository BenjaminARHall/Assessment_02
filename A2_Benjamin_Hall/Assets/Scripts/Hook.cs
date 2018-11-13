using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    public Transform cam;

    private RaycastHit hit;

    private Rigidbody rb;

    public bool attached = false;

    public float momentum;
    public float speed;
    public float step;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast (cam.position, cam.forward, out hit))
            {
            attached = true;
                rb.isKinematic = true;
                
            }
           

        }

        if (attached)
        {
            momentum += Time.deltaTime * speed;
            step = momentum * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, hit.point, step);
        }
	}
}
