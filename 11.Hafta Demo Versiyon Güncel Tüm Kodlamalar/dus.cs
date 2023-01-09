using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dus : MonoBehaviour
{
    public UIManager UIManagerScript;

    void Start()
    {
        UIManagerScript = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "dus")
        {
            UIManagerScript.GetComponent<Canvas>().enabled = true;

        }
    }
}
