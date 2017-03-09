using UnityEngine;
using System.Collections;

public class FlipperScriptTwee : MonoBehaviour {

    public float minRot = 5f;
    public float maxRot = 90f; 
    public float speed;
    public string control;
    public float rotating;
    Vector3 richting;
    public float force;
    
     
	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {

       

        if (Input.GetButton(control))
        {
            rotating += speed;
        }
        else
        {
            rotating -= speed;
        }

        rotating = Mathf.Clamp(rotating, minRot, maxRot);

        transform.rotation = Quaternion.Euler(-90f, rotating, 0);




    }

    void OnCollisionStay (Collision collision) {

        if (Input.GetButtonDown(control))
        {
            if (collision.collider.tag == "ball")
            {
                //richting = collision.contacts[0].point;
                collision.collider.GetComponent<Rigidbody>().AddForce(0, 5f, -force);
            }
        }

    }
}
