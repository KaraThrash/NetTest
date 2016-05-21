using UnityEngine;
using System.Collections;

public class NuetralItems : MonoBehaviour {
    private Rigidbody rb;
    public GameObject theCounter;
	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody>();
        //rb.useGravity = true;
        theCounter = GameObject.Find("count");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward * Time.deltaTime);
       


    }
}
