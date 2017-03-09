using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public GameObject bal;
    public GameObject balPrefab;
    public Transform resetPos;
    public int score;
    public float force;
    public Text scoreText;
    public Text forceText;
    public Text ballAmount;
    public int balls;
    public int maxLives;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (bal == null)
        {
            if(balls >= 0)
            {
                if (Input.GetButtonDown("Reset"))
                {
                    Instantiate(balPrefab, resetPos.position, Quaternion.identity);
                    bal = balPrefab;
                    bal.GetComponent<BallScript>().manager = gameObject;
                }
            }
        }
        force = bal.GetComponent<BallScript>().launchForce;
        scoreText.text = "Score: " + score;
        forceText.text = "Force: " + force;
        ballAmount.text = "Balls: " + balls;
	}
}
