using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandQuickActions : MonoBehaviour
{
    // Ball Fields
    private GameObject ballGameObject;
    private Transform ballTransform;
    private float ballXStart;
    private float ballYStart;
    private float ballZStart;
    private Vector3 ballVectorStart;
    private Rigidbody ballRb;

    // Player Fields
    private GameObject playerGameObject;
    private Transform playerTransform;
    private float playerXStart;
    private float playerYStart;
    private float playerZStart;
    private Vector3 playerVectorStart;
    private Quaternion playerRotation = new Quaternion(0, 180, 0, 0);

    // Cupset Fields
    private GameObject cupSetGameObject;
    private Transform[] cupSetOriginalTransforms;
    private Transform[] cupSetCurrentTransforms;
    public GameObject cupSetPrefab;

    void Start()
    {
        // Get Ball Properties
        ballGameObject = GameObject.Find("Ball");
        ballTransform = ballGameObject.GetComponent<Transform>();
        ballXStart = ballTransform.position.x;
        ballYStart = ballTransform.position.y;
        ballZStart = ballTransform.position.z;
        ballVectorStart = new Vector3(ballXStart, ballYStart, ballZStart);
        ballRb = ballGameObject.GetComponent<Rigidbody>();

        // Get Player Properties
        playerGameObject = GameObject.Find("OVRPlayerController");
        playerTransform = playerGameObject.GetComponent<Transform>();
        playerXStart = playerTransform.position.x;
        playerYStart = playerTransform.position.y;
        playerZStart = playerTransform.position.z;
        //playerVectorStart = new Vector3(playerXStart, playerYStart, playerZStart);
        playerVectorStart = new Vector3(0, 0.5f, 0);
        Debug.Log(
            "Player x start: " + playerXStart +
            "Player y start: " + playerYStart +
            "Player z start: " + playerZStart
            );

        // Get CupSet Properties
        cupSetGameObject = GameObject.Find("CupSet");
        Debug.Log("Position (x,y,z) of CupSet GameObject: " + cupSetGameObject.transform.position.x + ", " + cupSetGameObject.transform.position.y + ", " + cupSetGameObject.transform.position.z);
        cupSetOriginalTransforms = cupSetGameObject.GetComponentsInChildren<Transform>();
        foreach(Transform cupTransform in cupSetOriginalTransforms)
        {
            Debug.Log("Position: " + cupTransform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move Ball back to starting position when "A" is pressed
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            ballTransform.position = ballVectorStart;
            //ballTransform.rotation = Quaternion.Euler(0, 0, 0);
            ballRb.velocity = new Vector3(0, 0, 0);
            Debug.Log("Button A was pressed");
        }
        // Move Player back to starting position when "B" is pressed
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            playerTransform.rotation = playerRotation;
            playerTransform.position = playerVectorStart;
            Debug.Log("Button B was pressed");
        }
        //if (OVRInput.GetDown(OVRInput.Button.Three))
        //{
        //    var newBall = Instantiate(ballGameObject, new Vector3(0, 1.133f, -2), Quaternion.Euler(0,0,0));
        //    var newBallRb = newBall.GetComponent<Rigidbody>();
        //    newBall.gameObject.tag = "Ball";
        //    newBallRb.velocity = new Vector3(0, 0, 0);
        //}
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            cupSetCurrentTransforms = cupSetGameObject.GetComponentsInChildren<Transform>();
            for(int i = 0; i < cupSetCurrentTransforms.Length; i++)
            {
                cupSetCurrentTransforms[i].position = cupSetOriginalTransforms[i].position;
            }
            //var newCupSet = Instantiate(cupSetGameObject, new Vector3(-0.006f, 1.05f, -3), Quaternion.Euler(0,0,0));
            //var originalCupSet = GameObject.FindGameObjectWithTag("CupSet");
            //Destroy(originalCupSet);
            //newCupSet.gameObject.tag = "CupSet";
            
        }
    }
}
