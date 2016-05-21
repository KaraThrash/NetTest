using UnityEngine;
using UnityEngine.UI;
public class NetworkCharacter : Photon.MonoBehaviour
{
    public GameObject theCounter;
    public Text score;
    public int myScore;
    private Vector3 correctPlayerPos = Vector3.zero; // We lerp towards this
    private Quaternion correctPlayerRot = Quaternion.identity; // We lerp towards this
    void Start()
    {
        print(PhotonNetwork.playerList.Length);
        
        theCounter = GameObject.Find("count");
        theCounter.GetComponent<PhotonView>().RPC("SyncScore", PhotonTargets.All, null);
        // myScore = theCounter.GetComponent<Count>().theCount;
        score = GameObject.Find("Text").GetComponent<Text>();
        score.text = myScore.ToString();
       
        
    }
    // Update is called once per frame
    void Update()
    {

        if (!photonView.isMine)
        {

            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                score.text = theCounter.GetComponent<Count>().theCount.ToString();
                theCounter.GetComponent<PhotonView>().RPC("AddPoint", PhotonTargets.All, 2);

                // theCounter.GetComponent<Count>().AddPoint();

            }
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            
            LocalPlayer myC = GetComponent<LocalPlayer>();
            transform.Translate(transform.forward * Time.deltaTime);

            

            //stream.SendNext((int)myC._characterState);
        }
        else
        {
            // Network player, receive data
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();

            LocalPlayer myC = GetComponent<LocalPlayer>();
           // myC._characterState = (CharacterState)stream.ReceiveNext();
        }
    }
}
