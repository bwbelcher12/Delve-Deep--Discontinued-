using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtMouse : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    private GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver.Equals(true))
        {
            return;
        }

        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane p = new(Vector3.up, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        if (p.Raycast(mouseRay, out float hitDist))
        {
            Vector3 hitPoint = mouseRay.GetPoint(hitDist);
            transform.LookAt(hitPoint);
        }
    }
}
