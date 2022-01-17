using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupManager : MonoBehaviour
{
    // CupSet Fields
    private Transform[] cupSetTransforms;
    // Cup Fields
    private Transform cupTransform;
    // Ball Fields
    private GameObject ball;
    private GameObject[] balls;
    private Rigidbody ballRb;
    private Transform ballTransform;
    // DisplayBoardManager
    DisplayBoardManager DisplayBoardManager;
    void Start()
    {
        cupSetTransforms = GetComponentsInChildren<Transform>();
        foreach(Transform child in cupSetTransforms)
        {
            Debug.Log("X Position for " + child.name + " : " + child.position.x + " Z Position for " + child.name + " : " + child.position.z);
        }
        // Get Cup Components
        cupTransform = this.transform;
        // Get Ball Components
        ball = GameObject.Find("Ball");
        ballRb = ball.GetComponent<Rigidbody>();
        ballTransform = ball.GetComponent<Transform>();
        Debug.Log("X Position: " + cupTransform.position.x + " Z Position: " + cupTransform.position.z);
        // Get Balls based on tags
        if(balls == null)
        {
            balls = GameObject.FindGameObjectsWithTag("Ball");
        }
        DisplayBoardManager = GameObject.Find("DisplayBoard").GetComponent<DisplayBoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        for(int i = 0; i < cupSetTransforms.Length; i++) //Transform child in cupSetTransforms)
        {
            foreach(GameObject ball in balls)
            {
                Rigidbody ballRb = ball.GetComponent<Rigidbody>();
                Transform ballTransform = ball.GetComponent<Transform>();
                if (Mathf.Abs(ballRb.velocity.x) <= 0.5f &&
                   ballRb.velocity.y == 0 &&
                   Mathf.Abs(ballRb.velocity.z) <= 0.5f &&
                   Vector3.Distance(cupSetTransforms[i].position, ballTransform.position) < .07f &&
                   cupSetTransforms[i].name != "CupSet_0")
                {
                    //Destroy(cupSetTransforms[i].gameObject);
                    //cupSetTransforms[i] = null;
                    cupSetTransforms[i].position = new Vector3(0, 0, 0);
                    DisplayBoardManager.Score += 1;
                }
            }
        }
    }
}
