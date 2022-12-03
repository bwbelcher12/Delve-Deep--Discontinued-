using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text alerts;

    private void Start()
    {
        alerts.gameObject.SetActive(false);
    }

}
