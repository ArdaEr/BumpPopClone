using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.TryGetComponent(out InstiateManager im))
        {
            other.gameObject.SetActive(false);
            im.BallsSpawn();
        }
    }

}
