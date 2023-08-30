using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;

// 충돌을 막기위한 네임스페이스선언
namespace Com.Yatch
{
    public class YatchLancher : MonoBehaviourPunCallbacks // Pun 콜백함수들
    {
        #region Private Serializable Fields

        /// <summary>
        /// The maximum number of players per room. When a room is full, 
        /// it can't be joined by new players, and so new room will be created.
        /// </summary>
        [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
        [SerializeField]
        private byte maxPlayersPerRoom = 4; // 왜 바이트일까?? int로 사용하는데?

        #endregion

        #region Private Fields

        /// <summary>
        /// 버전별로 클라이언트들이 매칭됨
        /// </summary>
        string gameVersion = "1";

        #endregion

        #region MonoBehaviour CallBacks

        private void Awake()
        {
            // #Critical
            // 룸의 클라이언트들의 level을 자동으로 맞춰줌
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        private void Start()
        {
            Connet();
        }


        #endregion


        #region Public Methods
        /// <summary>
        /// 포톤클라우드에 연결 시작
        /// - If already connected, we attempt joining a random room
        /// - if not yet connected, Connect this application instance to Photon Cloud Network
        /// </summary>
        private void Connet()
        {
            // if connected, join할 수 있으면 조인
            // 아니면 서버에 다시 커넥트 
            if (PhotonNetwork.IsConnected)
            {
                // #Critical we need at this point to attempt joining a Random Room.
                // If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // #Critical, 일단 포톤 온라인 서버에 커넥트해야함
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        #endregion

        #region MonoBehaviourPunCallbacks Callbacks 
        // PunCallBack함수들 사용

        public override void OnConnectedToMaster() // 접속 됐을때
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            // #Critical: The first we try to do is to join a potential existing room.
            // 조인 못했을시 OnJoinRandomFailed() 호출
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnDisconnected(DisconnectCause cause) // 연결 끊겼을 때
        {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        
        
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: 조인이 안되면 방을 새로 만듬
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        }


        #endregion
    }
}


