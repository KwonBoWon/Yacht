using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public LayerMask Dice; // 클릭 가능한 레이어 설정

    private void Update()
    {
        // 마우스 버튼이 눌렸는지 확인
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치에서 레이 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);
            RaycastHit hit;

            // 레이캐스트를 통해 충돌체 감지
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Dice))
            {
                // 클릭 가능한 오브젝트가 감지됐을 때 실행할 코드
                GameObject clickedObject = hit.collider.gameObject;
                clickedObject.GetComponent<Dice>().DiceLocker();
                Debug.Log("Clicked on: " + clickedObject.name);

                // 클릭한 오브젝트에 대한 추가적인 처리나 동작을 수행할 수 있습니다.
            }
        }
    }
}
