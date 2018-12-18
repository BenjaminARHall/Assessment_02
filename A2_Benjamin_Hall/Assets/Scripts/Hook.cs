using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Hook : MonoBehaviour {

    
   

    public Transform cam;

    private RaycastHit hit;

    private Rigidbody rb;

    public bool attached = false;

    public float momentum;
    public float speed;
    public float step;
    public RigidbodyFirstPersonController cc;

    
    

    
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();	

	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit) && (hit.transform.tag == "tetherPoint"))
            {
                cc.mouseLook.XSensitivity = 0;
                cc.mouseLook.YSensitivity = 0;
                attached = true;
                rb.isKinematic = true;
                

            }
            else
            {
                attached = false;
                rb.isKinematic = false;
                
            }

        }
        if(Input.GetMouseButtonUp(0))
        {
            cc.mouseLook.XSensitivity = 5;
            cc.mouseLook.YSensitivity = 5;
            attached = false;
            rb.isKinematic = false;
            rb.velocity = cam.forward * momentum;
            StartCoroutine(LoseMomentum());
        }

        if (attached)
        {
            momentum += Time.deltaTime * speed;
            step = momentum * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, hit.point, step);
            
        }

        if (attached && momentum >= 0)
        {
            momentum -= Time.deltaTime * 5;
            step = 0;
            StartCoroutine(CapMomentum());
        }

        //if (attached && momentum == 20)
        //{
        //    momentum = 20;
        //}

        if(cc.Grounded && momentum <= 0)
        {
            momentum = 0;
            step = 0;
        }
	}

    IEnumerator LoseMomentum()
    {
        yield return new WaitForSeconds(1);
        for(float m = momentum; momentum > 0; momentum-- )
        {
            
            yield return null;
        }
    }

    IEnumerator CapMomentum()

    {
        
        for (float m = momentum; momentum ==20;)
        {           
            yield return null;
        }
    }

}


