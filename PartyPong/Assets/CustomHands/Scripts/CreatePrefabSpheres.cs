using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabSpheres : MonoBehaviour
{
    public GameObject prefabSphere;
    public float Timer = 2;
    private int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(-5, 5);
        Timer -= Time.deltaTime;

        if(Timer <= 0f)
        {
            Instantiate(prefabSphere, new Vector3(randomNumber, 10, randomNumber), Quaternion.identity);
            Timer = 2f;
            Debug.Log("Prefab Created");
        }
    }
}
