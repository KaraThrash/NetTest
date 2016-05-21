using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Count : Photon.MonoBehaviour
{
    public int theCount;
    public Text scoreText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{ theCount++;

        //}
	}
    [PunRPC]
    public void AddPoint(int num)
    {
        theCount = theCount;
        theCount +=num;
        scoreText.text = theCount.ToString();
    }
    [PunRPC]
    public void SyncScore()
    {
        theCount = theCount;
        scoreText.text = theCount.ToString();
    }

}