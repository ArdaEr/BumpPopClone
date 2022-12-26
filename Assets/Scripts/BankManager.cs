using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BankManager : MonoBehaviour
{
    [SerializeField] int startingBalance = 10;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI _currentBalance;
    public int CurrentBalance {get {return currentBalance;}}

    private void Awake() {
        currentBalance = startingBalance;
        // PlayerPrefs.DeleteAll();
    }
    private void Start() {
        if(PlayerPrefs.HasKey("CurrentBalance"))
        currentBalance = PlayerPrefs.GetInt("CurrentBalance");
        
    }
    private void Update() {
       MoneyText();
    }

    void MoneyText()
    {
        currentBalance = PlayerPrefs.GetInt("CurrentBalance");
        _currentBalance.text = currentBalance.ToString();    
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
    }
    public void Withdraw(int cost)
    {
        currentBalance -= Mathf.Abs(cost);
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
    }

    private void OnApplicationQuit() {
        PlayerPrefs.SetInt("CurrentBalance", currentBalance);
    }
}
