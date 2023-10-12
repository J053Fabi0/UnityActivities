using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movement : MonoBehaviour
{
    void Start() {

    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * 5f * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * 5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += Vector3.up * 5f * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position += Vector3.down * 5f * Time.deltaTime;
        }
    }
}
