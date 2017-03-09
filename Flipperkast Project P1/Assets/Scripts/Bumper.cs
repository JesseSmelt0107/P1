using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {
    public Vector3 richting;
    public Rigidbody eenObject;
    public float force;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        richting = collision.contacts[0].point;
        eenObject.AddForce(richting * force);
                        
            //eenObject.AddForce(richting);
    }
}
