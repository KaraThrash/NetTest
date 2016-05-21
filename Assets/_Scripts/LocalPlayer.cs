using UnityEngine;
using System.Collections;

public class LocalPlayer : Photon.MonoBehaviour
{
    public float thrust;
    public GameObject obj;
    public GameObject myHat;
    public GameObject myCam;
    public GameObject camHolder;
    public GameObject camHolderL;
    public GameObject camHolderR;
    public GameObject netManager;
    // Update is called once per frame
    void Start()
    {
        netManager = GameObject.Find("myScripts");
        if (photonView.isMine)
        {
            GameObject clone = Instantiate(myCam, myHat.transform.position, transform.rotation) as GameObject;
            clone.transform.parent = this.transform;
            netManager.GetComponent<NetworkManager>().num++;
        }
            //myCam = this.gameObject.transform.GetChild(0);
        //myCam.gameObject.active = true;
        //GameObject thisCam =  Instantiate(myCam, transform.position, transform.rotation) as GameObject;
        // thisCam.transform.parent = this.transform;


        //myCam = GameObject.Find("Main Camera");
        //myCam.gameObject.active = true;

        //myCam.transform.position = camHolder.transform.position;
        //myCam.transform.rotation = camHolder.transform.rotation;
        //myCam.transform.parent = camHolder.transform;
    }
    void Update()
    {
        if (photonView.isMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * (thrust * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * -(thrust * Time.deltaTime));

            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.right * -(thrust * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * (thrust * Time.deltaTime));

            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(Vector3.right * (thrust * Time.deltaTime));
                myHat.active = true;

            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                transform.Translate(Vector3.right * (thrust * Time.deltaTime));
                myHat.active = false;
            }
            if (Input.GetKeyUp(KeyCode.V))
            {
                PhotonNetwork.Instantiate("randomCap", myHat.transform.position, transform.rotation,0);
                //clone.GetComponent<Rigidbody>().isKinematic = false;
                //clone.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
    public void TakeCamLeft()
    {
       // myCam.transform.position = camHolderL.transform.position;
        //myCam.transform.rotation = camHolderL.transform.rotation;
    }
    public void TakeCamRight()
    {
       // myCam.transform.position = camHolderR.transform.position;
      //  myCam.transform.rotation = camHolderR.transform.rotation;
    }
}
