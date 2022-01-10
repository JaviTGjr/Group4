using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float smoothness = 1;

    [SerializeField]
    private int times = 10;

    private Color color;

    public Color Color { set { color = value;  } }

    private float timer; 

    void Start()
    {
        color = this.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.1f && color.r > 0)
        {
            color = new Color(color.r - 0.3f, color.g, color.b, color.a);
            this.GetComponent<MeshRenderer>().material.color = color;
            timer = 0;
        }
    }

    public void Reset()
    {
        color.r = 1;
    }
}
