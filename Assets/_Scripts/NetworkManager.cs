using UnityEngine;
using System.Collections;


    public class NetworkManager : MonoBehaviour
    {
        public GameObject mainCam;
        // Use this for initialization
        void Start()
        {

            Connect();
        }

        // Update is called once per frame
        void Connect()
        {
            PhotonNetwork.ConnectUsingSettings("version 01");
            print("connect");
            mainCam.active = false;

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
            GameObject myPlayerGO = PhotonNetwork.Instantiate("PlayerController", Vector3.zero, Quaternion.identity, 0) as GameObject;
            //myPlayerGO.GetComponent<FirstPersonController>().enabled = true;

            //((MonoBehaviour)myPlayerGO.GetComponent("FirstPersonController")).enabled = true;
            //((MonoBehaviour)myPlayerGO.GetComponent("MouseLook")).enabled = true;
        }
    }

