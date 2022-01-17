using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBoardManager : MonoBehaviour
{
    public GameObject DisplayBoardText;
    public int Score = 0;
    void Start()
    {
        DisplayBoardText = GameObject.Find("/DisplayBoard/Canvas/Text");
        DisplayBoardText.GetComponent<Text>().text = "Starting...";
    }

    // Update is called once per frame
    void Update()
    {
        DisplayBoardText.GetComponent<Text>().text = "Score: " + Score;
    }
}
