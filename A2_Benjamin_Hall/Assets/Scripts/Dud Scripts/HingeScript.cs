using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeScript : MonoBehaviour {

    public GameObject tetherPoint;
    public GameObject tetherOrigin;
    

    
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (tetherPoint.gameObject.CompareTag("tetherPoint"))
        {
            tetherPoint.AddComponent<HingeJoint>();
            //tetherPoint.GetComponent<HingeJoint>().connectedBody = ;
        }
    }

}

