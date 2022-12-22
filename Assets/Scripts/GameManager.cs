using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI moneyCountText;
    public TextMeshProUGUI ballCountText;
    public List<GameObject> Units {get;set;}= new List<GameObject>();

    public int ballCount = 8;
    public int balls;
    public float money = 10f;
    public float moneyIncome = 0.1f;
    public bool isCamOn;

    private void Awake() {
        Instance = this;
    }


    public void BallCountBoost()
    {
        if(money >= 10)
        {
            money -= 10;
            ballCount++;
        }
    }
}
