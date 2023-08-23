using Photon.Pun;
using UnityEngine;

public class Ball : MonoBehaviourPun
{
    // photonView 자신의 포톤뷰 프로퍼티
    public bool IsMasterClientLocal => PhotonNetwork.IsMasterClient && photonView.IsMine;

    private Vector2 direction = Vector2.right;
    private readonly float speed = 10f;
    private readonly float randomRefectionIntensity = 0.1f;
    
    private void FixedUpdate()
    {
        // 방장이 아니거나 플레이어가 부족하면
        if (!IsMasterClientLocal || PhotonNetwork.PlayerList.Length < 2)
        {
            return;
        }

        var distance = speed * Time.deltaTime;
        var hit = Physics2D.Raycast(transform.position, direction, distance);

        if(hit.collider != null)
        {
            var goalPost = hit.collider.GetComponent<Goalpost>();

            if(goalPost != null)
            {
                if(goalPost.playerNumber == 1)
                {
                    GameManager.Instance.AddScore(2 , 1);
                }
                if (goalPost.playerNumber == 2)
                {
                    GameManager.Instance.AddScore(1, 1);
                }

            }

            direction = Vector2.Reflect(direction, hit.normal); // 반사되는 방향
            direction += Random.insideUnitCircle * randomRefectionIntensity; // 1,1까지의 랜덤값
        }

        transform.position = (Vector2)transform.position + direction * distance;
    }
}