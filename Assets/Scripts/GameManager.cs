using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject levelFail;
    [SerializeField] GameObject levelComplete;
    [SerializeField] GameObject _button;
    [SerializeField] GameObject replay;
    //[SerializeField] Button _buttonSecond;
    [SerializeField] BankManager _bank;

    [SerializeField] TextMeshProUGUI ballCountText;
    [SerializeField] TextMeshProUGUI moneyCostBallText;
    [SerializeField] TextMeshProUGUI moneyCostText;

    [SerializeField] int moneyCost = 10;
    [SerializeField] int moneyCostBall = 10;
    [SerializeField] int moneyIncome = 1;

    // public TextMeshProUGUI moneyCountText;

    public List<GameObject> Units {get;set;}= new List<GameObject>();

    public int ballCount = 8;
    public int balls;
    public bool isCamOn;
    public bool isStart;


    private void Awake() {
        
        Instance = this;
        if(PlayerPrefs.HasKey("MoneyIncomeBoost"))
            {moneyIncome = PlayerPrefs.GetInt("MoneyIncomeBoost");}
        if(PlayerPrefs.HasKey("MoneyIncomeCost"))
            {moneyCost = PlayerPrefs.GetInt("MoneyIncomeCost");}
        if(PlayerPrefs.HasKey("CloneBallCount"))
            {ballCount = PlayerPrefs.GetInt("CloneBallCount");}
        if(PlayerPrefs.HasKey("MoneyIncomeCost"))
            {moneyCostBall = PlayerPrefs.GetInt("CloneBallCost");}
        
        // PlayerPrefs.DeleteAll();

    }
    private void Start() {
        //_bank = GetComponent<BankManager>();
        
    }

    private void Update() {
        UIUptade();
    }
    void UIUptade()
    {
        ballCountText.text = balls.ToString();
        moneyCostBallText.text = moneyCostBall.ToString();
        moneyCostText.text = moneyCost.ToString();
    }
    public void ReplayButton()
    {
        replay.SetActive(true);
    }

    public void StartGame()
    {
        isStart = true;
        _button.SetActive(false);   
    }

    public void LevelFailed()
    {
        levelFail.SetActive(true);
    }

    public void LevelCompleted()
    {
        levelComplete.SetActive(true);
    }

    public void BallCountBoost()
    {
        // BankManager bank = FindObjectOfType<BankManager>();
        if(_bank.CurrentBalance >= moneyCostBall)
        {
            _bank.Withdraw(moneyCostBall);
            //PlayerPrefs.SetInt("CurrentMoney", _bank.CurrentBalance);
            ballCount++;
            PlayerPrefs.SetInt("CloneBallCount",ballCount);
            moneyCostBall *= 2;
            PlayerPrefs.SetInt("CloneBallCost", moneyCostBall);
        }
    }
    public void MoneyIncomeBoost()
    {
        // BankManager bank = FindObjectOfType<BankManager>();
        if(_bank.CurrentBalance >= moneyCost)
        {
            _bank.Withdraw(moneyCost);
            // PlayerPrefs.SetInt("CurrentMoney", _bank.CurrentBalance);
            moneyIncome++;
            PlayerPrefs.SetInt("MoneyIncomeBoost", moneyIncome);
            moneyCost *= 2;
            PlayerPrefs.SetInt("MoneyIncomeCost", moneyCost);
        }
    }

    public void MoneyAdd()
    {
        // BankManager bank = FindObjectOfType<BankManager>();
        _bank.Deposit(moneyIncome);

    }

    private void OnApplicationQuit() {
        PlayerPrefs.SetInt("MoneyIncomeBoost", moneyIncome);
        PlayerPrefs.SetInt("MoneyIncomeCost", moneyCost);
        PlayerPrefs.SetInt("CloneBallCount",ballCount);
        PlayerPrefs.SetInt("CloneBallCost", moneyCostBall);
    }
    
}
