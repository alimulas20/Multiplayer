using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    [Header("Input Field")]
    public InputField _nameInput;
    public InputField _RoomName;
    public InputField _MaxPlayer;
    [Header("Login Panel")]
    public GameObject _LoginPanel;
    public GameObject[] _loginPanelGameObjects;
    [Header("GameSettingsPanel")]
    public GameObject _GameSettingsPanel;
    public GameObject[] _GameSettingGameObjects;
    [Header("CreateJoinRoom")]
    public GameObject _CreateJoinRoom;
    public GameObject[] _CreateJoinRoomGameObjects;
    [Header("RandomRoom")]
    public GameObject _RandomRoom;
    public Text _RandomRoomText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region PhotonCallBacks
    public override void OnConnectedToMaster()
    {
        Debug.Log("Photona Baðlandý");
        Debug.Log(PhotonNetwork.NickName);
        _LoginPanel.SetActive(false);
        _GameSettingsPanel.SetActive(true);
        //base.OnConnectedToMaster();
    }
    public override void OnConnected()
    {
        Debug.Log("Ýnternete Baðlandý");
        //base.OnConnected();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name+"room created and joined");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        Debug.Log("Avaliable room not found. Creating New room");
        CreateRandomRoom();
 
    }
    #endregion
    #region UnityMethods
    public void PreEnter()
    {
        Debug.Log("Buton çalýþtý");
        PhotonNetwork.NickName = _nameInput.text;
        PhotonNetwork.ConnectUsingSettings();
    }
    public void CreateRoom()
    {
        _GameSettingsPanel.SetActive(false);
        _CreateJoinRoom.SetActive(true);
    }
    public void CreateRoomButton()
    {
        RoomOptions _RoomOption=new RoomOptions();
        _RoomOption.MaxPlayers = (byte)int.Parse(_MaxPlayer.text);
        PhotonNetwork.CreateRoom(_RoomName.text, _RoomOption);
    }
    public void RandomRoom()
    {
        _GameSettingsPanel.SetActive(false);
        _RandomRoom.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        _RandomRoomText.text = "Searching a room";
    }
    public void CreateRandomRoom()
    {
        string _randomName = "Room" + Random.Range(10, 100);
        RoomOptions _roomOptionsRandom = new RoomOptions();
        _roomOptionsRandom.IsOpen = true;
        _roomOptionsRandom.IsVisible = true;
        PhotonNetwork.CreateRoom(_randomName,_roomOptionsRandom);
    }
    #endregion
}
