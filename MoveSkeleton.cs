using UnityEngine;
using System.Collections;

public class MoveSkeleton : MonoBehaviour
{
    public float movespeed = 2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
            transform.Translate(new Vector3(-1, 0, 0));

    }

}