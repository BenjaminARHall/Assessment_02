using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigTest : MonoBehaviour {

    public GameObject hookPoint;
    public Rigidbody player;
    public bool hooked = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
            DoJoint();
	}

    void DoJoint()
    {
        hooked = !hooked;
        if (hooked)
        {
            hookPoint.AddComponent<ConfigurableJoint>();
            hookPoint.GetComponent<ConfigurableJoint>().connectedBody = player;
            player.AddForce(Vector3.up * 1000);
        }
        else
        {
            Destroy(hookPoint.GetComponent<ConfigurableJoint>());
        }
        
    }
}
