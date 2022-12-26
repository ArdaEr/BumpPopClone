using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChainDurability : MonoBehaviour
{
    [SerializeField] int chainBallStuck;
    [SerializeField] TextMeshProUGUI chainBallText;
    [SerializeField] GameObject chain;
    public bool isFinal = false;

    private void Start() {
        chainBallText.text = chainBallStuck.ToString();
    }

    private void OnTriggerEnter(Collider collision) {
        chainBallStuck--;
        chainBallText.text = chainBallStuck.ToString();
        if(chainBallStuck <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody>().drag = 0;
            Destroy(chain);
            isFinal = true;
            GameManager.Instance.LevelCompleted();
        }
    }
    

}
