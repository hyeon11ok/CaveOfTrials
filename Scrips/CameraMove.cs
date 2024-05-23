using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    private float damp = 2;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update() {
        transform.position = Vector3.Lerp(transform.position, player.position +  offset, Time.deltaTime * damp);
    }
}
