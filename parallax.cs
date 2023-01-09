using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [SerializeField] public Transform _cam;
    [SerializeField] public float _movespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * _movespeed * Time.deltaTime, 0f, 0f);
        if (_cam.position.x >= transform.position.x + -5f)
        {
            transform.position = new Vector2(_cam.position.x + -3f, transform.position.y);
        }

    }
}
