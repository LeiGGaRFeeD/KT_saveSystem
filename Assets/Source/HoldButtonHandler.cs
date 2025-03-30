using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int basePoints = 1;
    private float holdStartTime;
    private bool isHolding;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        holdStartTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        float holdDuration = Time.time - holdStartTime;
        GameManager.Instance.AddScore(holdDuration, basePoints);
    }
}