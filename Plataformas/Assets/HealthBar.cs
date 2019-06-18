using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Transform bar;

    void Awake()
    {
        if (transform.Find("Bar"))
        {
            bar = transform.Find("Bar");
        }

    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector2(sizeNormalized, 1f);
    }
    public void SetColor(Color color)
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
