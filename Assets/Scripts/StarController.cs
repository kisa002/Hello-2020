using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = GameManager.instance.GetColor();
    }

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * GameManager.instance.speed);

        if (transform.position.z <= Camera.main.transform.position.z)
            Destroy(gameObject);
    }
}
