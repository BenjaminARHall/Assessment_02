using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;




public class HookFinal : MonoBehaviour {
    public Transform camera;
    public GameObject hookPoint;
    public Rigidbody player;
    public bool hooked = false;
    private RaycastHit hit;
    public float boost;
    //public float minD;
    //public float maxD;
    //public float damper;
    //public float spring;
    public Rigidbody rb;
    public RigidbodyFirstPersonController cc;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // rb.isKinematic = false;
       // rb.useGravity = true;
    }

    public void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camera.position, camera.forward, out hit) && (hit.transform.tag == "tetherPoint"))
            {
                Debug.Log("Hit");
                hookPoint = hit.collider.gameObject;
                DoJoint();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            UndoJoint();
        }
    }

    public void DoJoint()
    {
        hooked = !hooked;
        if (hooked)
        {
            player.AddForce(Vector3.back * boost);
            StartCoroutine(Hooked());
        }
        else
        {
            Destroy(hookPoint.GetComponent<HingeJoint>());
          //  rb.constraints = RigidbodyConstraints.None;
           // rb.isKinematic = false;
        }

    }

    IEnumerator Hooked()
    {
        yield return new WaitForSeconds(0.5f);
           // rb.isKinematic = true;
            hookPoint.AddComponent<HingeJoint>();
           hookPoint.GetComponent<HingeJoint>().connectedBody = player;
        if (Input.GetMouseButtonUp(0))
        {
            UndoJoint();
        }
        // cc.mouseLook.XSensitivity = 0;
        //  cc.mouseLook.YSensitivity = 0;
        //  rb.constraints = RigidbodyConstraints.FreezeRotationY;
        // rb.constraints = RigidbodyConstraints.FreezeRotationZ;

        // hookPoint.GetComponent<SpringJoint>().minDistance = minD;
        // hookPoint.GetComponent<SpringJoint>().maxDistance = maxD;
        // hookPoint.GetComponent<SpringJoint>().damper = damper;
        // hookPoint.GetComponent<SpringJoint>().spring = spring;
        // hookPoint.GetComponent<SpringJoint>().enablePreprocessing = true;

        yield break;
    }

    public void UndoJoint()
    {
        rb.isKinematic = false;
        hooked = !hooked;
        Destroy(hookPoint.GetComponent<HingeJoint>());
       // cc.mouseLook.XSensitivity = 5;
       // cc.mouseLook.YSensitivity = 5;
        // rb.constraints = RigidbodyConstraints.None;
    }


}
