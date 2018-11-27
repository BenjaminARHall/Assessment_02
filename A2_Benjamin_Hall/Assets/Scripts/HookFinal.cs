using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;




public class HookFinal : MonoBehaviour {
    public Transform camera;
    public GameObject hookPoint;
    public Rigidbody player;
    public bool hooked = false;
    private RaycastHit hit;

    public void Update()
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

            hookPoint.AddComponent<HingeJoint>();
            hookPoint.GetComponent<HingeJoint>().connectedBody = player;
            player.AddForce(Vector3.up * 1000);
        }
        else
        {
            Destroy(hookPoint.GetComponent<HingeJoint>());
        }

    }

    public void UndoJoint()
    {
        hooked = !hooked;
        Destroy(hookPoint.GetComponent<HingeJoint>());
    }


}
