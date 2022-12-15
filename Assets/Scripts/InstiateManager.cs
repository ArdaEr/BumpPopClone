using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstiateManager : MonoBehaviour
{
    [SerializeField] int ball;
    [SerializeField] GameObject _prefab;
    [SerializeField] int speed = 2;
    Transform _transform;
    float xoffset;
    float yoffset;

    
    void Start()
    {
        _transform = GetComponent<Transform>();
        xoffset = Random.Range(0f,1f);
        yoffset = Random.Range(0f,1f);

    }

    void Update()
    {
        BallsSpawn();

    }

    public void BallsSpawn()
    {

        if(Input.GetMouseButtonDown(0))
         {
            for(int i = 0; i <= ball ;i++)
            {
                Debug.Log(i);
                GameObject clone = Instantiate(_prefab, new Vector3((transform.position.x + Random.Range(0f,0.3f) ), transform.position.y, transform.position.z + Random.Range(0f,0.3f) ), Quaternion.identity);
                clone.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            }
         }
    }

}
