using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayerManager : MonoBehaviour
{
    public GameObject Ball;
    private int Attempts = 0;

    private GameObject Cupset_1;
    public float ballSpeed;
    private float gravity = Physics.gravity.y;
    void Start()
    {
        Cupset_1 = GameObject.Find("CupSet_1/Cup_4");
        StartCoroutine(ShootBall());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator ShootBall()
    {
        for (; ; )
        {
            //float distance = Cupset_1.transform.position.z - transform.position.z;
            //Debug.Log(distance);
            //Vector3 directionalVector = Cupset_1.transform.position - new Vector3(0, 2, -4.5f);
            //Debug.Log(directionalVector.x + " " + directionalVector.y + " " + directionalVector.z);

            //float v2 = ballSpeed * ballSpeed;
            //float v4 = v2 * v2;

            //float z = Cupset_1.transform.position.z;
            //float z2 = z * z;
            //float y = Cupset_1.transform.position.y;

            //float theta = 0.5f * Mathf.Asin((gravity * distance) / (ballSpeed * ballSpeed));
            //Vector3 releaseVector = (Quaternion.AngleAxis(theta * Mathf.Rad2Deg, -Vector3.forward) * directionalVector).normalized;
            //Debug.Log(releaseVector.x + " " + releaseVector.y + " " + releaseVector.z);
            //Debug.DrawRay(transform.position, releaseVector * 5, Color.cyan, 0.5f);

            Random.Range(2, 4);
            var ballClone = Instantiate(Ball, new Vector3(0, 2, -4.5f), Quaternion.Euler(0, 45, 0));
            ballClone.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-0.3f,0.3f), Random.Range(3,4), Random.Range(2,4));
            Debug.Log("Shooting Ball...");
            Attempts += 1;
            Debug.Log(Attempts);
            yield return new WaitForSeconds(2f);
        }
    }
}
