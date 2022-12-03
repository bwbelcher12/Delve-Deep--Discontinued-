using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{
    private Vector3 rotation = new Vector3(0, 0, 0);

    void Update()
    {
        rotation.y += 3 * Time.deltaTime;

        this.gameObject.transform.eulerAngles = rotation;
    }
}
