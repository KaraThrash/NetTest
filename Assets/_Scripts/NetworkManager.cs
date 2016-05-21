using UnityEngine;
using System.Collections;


    public class NetworkManager : MonoBehaviour
    {
    //public GameObject mainCam;
    public float num;
    public GameObject theCounter;
    public GameObject myCam;
    public GameObject camHolderL;
    public GameObject camHolderR;
    // Use this for initialization
    void Start()
        {

        PhotonNetwork.autoJoinLobby = true;
        Connect();
        }

        // Update is called once per frame
        void Connect()
        {
            PhotonNetwork.ConnectUsingSettings("1");
        
        print("connect");
      //  PhotonNetwork.JoinLobby();
        //mainCam.active = false;

    }
        void OnGUI()
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }
        void OnJoinedLobby()
        {
            print("Joinlobby");
            PhotonNetwork.JoinRandomRoom();

        }
        void OnPhotonRandomJoinFailed()
        {
            print("JoinFailed");
            PhotonNetwork.CreateRoom(null);
        }
        void OnJoinedRoom()
        {
            print("Join");
            SpawnMyPlayer();
        }
        void SpawnMyPlayer()
        {
            print("SpawnMyPl");
            GameObject myPlayerGO = PhotonNetwork.Instantiate("NetPlayer", Vector3.zero, Quaternion.identity, 0) as GameObject;
         myPlayerGO.GetComponent<NetworkCharacter>().myScore = theCounter.GetComponent<Count>().theCount ;
        num++;
        // GameObject clone = Instantiate(myCam, myPlayerGO.transform.position, myPlayerGO.transform.rotation) as GameObject;
        // clone.transform.parent = myPlayerGO.transform;
        //myPlayerGO.GetComponent<FirstPersonController>().enabled = true;

        //((MonoBehaviour)myPlayerGO.GetComponent("FirstPersonController")).enabled = true;
        //((MonoBehaviour)myPlayerGO.GetComponent("MouseLook")).enabled = true;
    }
    public void TakeCamLeft()
    {
        myCam.transform.position = camHolderL.transform.position;
        myCam.transform.rotation = camHolderL.transform.rotation;
    }
    public void TakeCamRight()
    {
        myCam.transform.position = camHolderR.transform.position;
        myCam.transform.rotation = camHolderR.transform.rotation;
    }
}

