using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class RegexManager : MonoBehaviour
{
    private static RegexManager _instance;

    public static RegexManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우 새로운 인스턴스를 생성
            if (_instance == null)
            {
                GameObject singleton = new GameObject("RegexManager");
                _instance = singleton.AddComponent<RegexManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // 두 번째 인스턴스가 생성되었을 때 오류 방지
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // 카드 유효성 검사 메서드 
    public bool IsValidCard(string cardCondition, string diceCondition){
        return Regex.IsMatch(diceCondition,cardCondition);
    }
}
