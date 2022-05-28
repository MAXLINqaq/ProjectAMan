using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 postion;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = playerTransform.position;

    }

    // Update is called once per frame
    void Update()
    {
        postion = Camera.main.ScreenToWorldPoint(Input.mousePosition) + playerTransform.position;
        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, postion.x / 2, 0.01f), Mathf.Lerp(this.transform.position.y, postion.y / 2, 0.01f), -10);

    }
}
