using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button incomeBut;
    [SerializeField] RectTransform incomeBtn;
    [SerializeField] RectTransform ballCounBtn;
    [SerializeField] float revealDuration = 1f;

    private void Start() {
        ButtonAnimation();
    }

    public void ButtonAnimation()
    {
        incomeBtn.transform.DOScale(1.1f, 0.4f).SetLoops(-1, LoopType.Yoyo);
        ballCounBtn.transform.DOScale(1.1f, 0.4f).SetLoops(-1, LoopType.Yoyo);
    }
}
 