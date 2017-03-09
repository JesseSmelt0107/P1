using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
    public bool launchable;
    public float launchForce;
    public float forceAdd;
    Vector3 richting;
    public float force;
    public GameObject manager;
    public int scoreAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //launched de bal
        if(launchable == true)
        {
            if (Input.GetButton("Jump"))
            {
                launchForce += forceAdd * Time.deltaTime;
            }

            if (Input.GetButtonUp("Jump"))
            {
                transform.parent = null;
                GetComponent<Rigidbody>().AddForce(0, 10f, -launchForce);
                launchForce = 0;
                launchable = false;
                
                
            }
        }
	
	}

    void OnCollisionEnter(Collision collision) {
        //checkt of de bal de launcher raakt
        if(collision.collider.tag == "launcher")
        {
            transform.parent = collision.collider.transform.GetChild(0);
            launchable = true;
        }
        //checkt de of de bal het onderste gedeelte raakt
        if(collision.collider.tag == "fail")
        {
            manager.GetComponent<Manager>().balls--;    
            Destroy(gameObject);
           
        }
        //chekt de bal of die een bumper raakt
        if(collision.collider.tag == "bumper")
        {
            richting = collision.contacts[0].point;
            print(richting);
            GetComponent<Rigidbody>().AddForce(richting.x * force, 1f, richting.z * force);
            manager.GetComponent<Manager>().score += scoreAmount;
        }
        //checkt of de bal een bonus object raakt
        if(collision.collider.tag == "bonusBall")
        {
            manager.GetComponent<Manager>().balls++;
        }


    }
}
