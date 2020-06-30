using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    public Scrollbar hb;

    private void Start()
    {
        hb.size = 1;
        hb.targetGraphic.color = Color.green;
    }
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        hb.transform.position = pos;
            
    }
}
