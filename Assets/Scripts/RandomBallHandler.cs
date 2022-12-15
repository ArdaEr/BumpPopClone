using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBallHandler : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabs;
    [SerializeField] int i;
    Transform _transform;
   
    void Start()
    {
        _transform = GetComponent<Transform>();
       
        BallSpawner();
    }

    
    void Update()
    {
        
    }

    public void BallSpawner()
    {
        i = Random.Range(0,3);
        GameObject myNewBall = Instantiate(_prefabs[i],transform.position, Quaternion.identity);
        myNewBall.transform.parent = this.gameObject.transform;
        
    }
}
