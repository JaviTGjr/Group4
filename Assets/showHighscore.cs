using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHighscore : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
