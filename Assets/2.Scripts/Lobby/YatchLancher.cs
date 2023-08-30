using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;

// �浹�� �������� ���ӽ����̽�����
namespace Com.Yatch
{
    public class YatchLancher : MonoBehaviourPunCallbacks // Pun �ݹ��Լ���
    {
        #region Private Serializable Fields

        /// <summary>
        /// The maximum number of players per room. When a room is full, 
        /// it can't be joined by new players, and so new room will be created.
        /// </summary>
        [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
        [SerializeField]
        private byte maxPlayersPerRoom = 4; // �� ����Ʈ�ϱ�?? int�� ����ϴµ�?

        #endregion

        #region Private Fields

        /// <summary>
        /// �������� Ŭ���̾�Ʈ���� ��Ī��
        /// </summary>
        string gameVersion = "1";

        #endregion

        #region MonoBehaviour CallBacks

        private void Awake()
        {
            // #Critical
            // ���� Ŭ���̾�Ʈ���� level�� �ڵ����� ������
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        private void Start()
        {
            Connet();
        }


        #endregion


        #region Public Methods
        /// <summary>
        /// ����Ŭ���忡 ���� ����
        /// - If already connected, we attempt joining a random room
        /// - if not yet connected, Connect this application instance to Photon Cloud Network
        /// </summary>
        private void Connet()
        {
            // if connected, join�� �� ������ ����
            // �ƴϸ� ������ �ٽ� Ŀ��Ʈ 
            if (PhotonNetwork.IsConnected)
            {
                // #Critical we need at this point to attempt joining a Random Room.
                // If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // #Critical, �ϴ� ���� �¶��� ������ Ŀ��Ʈ�ؾ���
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        #endregion

        #region MonoBehaviourPunCallbacks Callbacks 
        // PunCallBack�Լ��� ���

        public override void OnConnectedToMaster() // ���� ������
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            // #Critical: The first we try to do is to join a potential existing room.
            // ���� �������� OnJoinRandomFailed() ȣ��
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnDisconnected(DisconnectCause cause) // ���� ������ ��
        {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        
        
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: ������ �ȵǸ� ���� ���� ����
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        }


        #endregion
    }
}


