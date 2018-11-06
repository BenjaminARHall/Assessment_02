using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherScript : MonoBehaviour {

    // Use this for initialization
    public GameObject tether;
    public GameObject tetherGun;
    public float tetherDistance;


    private Vector3 initialLocalPosition;
    private Vector3 initialLocalRotation;

    // Use this for initialization
    void Start()
    {
        tether.GetComponent<Rigidbody>().useGravity = false;
        tether.GetComponent<Rigidbody>().isKinematic = true;
        initialLocalPosition = transform.localPosition;
        initialLocalRotation = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
       // int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
       // layerMask = ~layerMask;
       if (Input.GetMouseButtonDown(0))
        {
            tether.GetComponent<Rigidbody>().useGravity = true;
            tether.GetComponent<Rigidbody>().isKinematic = false;
            tether.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
            int layerMask = 1 << 9;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            //layerMask = layerMask;
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, tetherDistance, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
               
                Debug.Log("Did Hit");
                
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                Debug.Log("Did not Hit");
            }
        }
       if(Input.GetMouseButtonUp(0))
        {
            tether.GetComponent<Rigidbody>().useGravity = false;
            tether.GetComponent<Rigidbody>().isKinematic = true;
            tether.transform.localPosition.initialLocalPosition;
        }
    }
}
