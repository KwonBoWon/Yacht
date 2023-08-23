using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public LayerMask Dice; // Ŭ�� ������ ���̾� ����

    private void Update()
    {
        // ���콺 ��ư�� ���ȴ��� Ȯ��
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ���� ���� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);
            RaycastHit hit;

            // ����ĳ��Ʈ�� ���� �浹ü ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Dice))
            {
                // Ŭ�� ������ ������Ʈ�� �������� �� ������ �ڵ�
                GameObject clickedObject = hit.collider.gameObject;
                clickedObject.GetComponent<Dice>().DiceLocker();
                Debug.Log("Clicked on: " + clickedObject.name);

                // Ŭ���� ������Ʈ�� ���� �߰����� ó���� ������ ������ �� �ֽ��ϴ�.
            }
        }
    }
}
