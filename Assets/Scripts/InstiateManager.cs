using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstiateManager : MonoBehaviour
{

    
    
    //[SerializeField] int ball;
    [SerializeField] GameObject _prefab;
    [SerializeField] int speed = 2;
    
    //[SerializeField] int ballCounter = 1;
    
    //public bool isCamOn = false;
    Transform _transform;
    BankManager bankManager;
    float xoffset;
    float yoffset;
     

    void Start()
    {
        bankManager = GetComponent<BankManager>();
        _transform = GetComponent<Transform>();
        xoffset = Random.Range(0f,1f);
        yoffset = Random.Range(0f,1f);

    }
    public void BallsSpawn()
    {

            for(int i = 1; i <= GameManager.Instance.ballCount ;i++)
            {
                //GameManager.Instance.money += GameManager.Instance.moneyIncome;
                GameManager.Instance.MoneyAdd();
                GameManager.Instance.balls++;
                GameObject clone = Instantiate(_prefab, new Vector3((transform.position.x + Random.Range(0f,0.3f) ), transform.position.y, transform.position.z + Random.Range(0f,0.3f) ), Quaternion.identity);
                Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
                cloneRB.AddForce(transform.forward * speed);
                GameManager.Instance.Units.Add(clone);
                Debug.Log(GameManager.Instance.Units);
                //Debug.Log(_bankM.CurrentBalance);
                //Debug.Log(GameManager.Instance.money);
            }
    }
}
