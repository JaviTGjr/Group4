using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addScore : MonoBehaviour
{
    public int score;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("TopCanvas").transform.GetChild(3).GetComponent<Text>();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        if (text)
        {
            text.text = (int.Parse(text.text) + score).ToString();
            if (PlayerPrefs.GetInt("Highscore", 0) < int.Parse(text.text))
            {
                PlayerPrefs.SetInt("Highscore", int.Parse(text.text));
            }
        }
    }
}
