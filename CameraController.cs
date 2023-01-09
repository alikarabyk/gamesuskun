using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform Player;
    [SerializeField]
    private float smoothX;
    [SerializeField]
    private float smoothy;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float miny;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float maxY;
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        float posX = Mathf.MoveTowards(transform.position.x, Player.position.x, smoothX);
        float posY = Mathf.MoveTowards(transform.position.y, Player.position.y, smoothy);
        transform.position = new Vector3(Mathf.Clamp(posX, minX, maxX), Mathf.Clamp(posY, miny, maxY), transform.position.z);
    }
}
