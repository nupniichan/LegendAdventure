using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CineMachineCamera : MonoBehaviour
{
    private Transform target;
    CinemachineVirtualCamera CineCam;
    CinemachineConfiner Ground;
    private void Start()
    {
        target = GameObject.FindWithTag("player").transform;
        CineCam = GetComponent<CinemachineVirtualCamera>();
        CineCam.Follow = target;
        Ground.m_BoundingShape2D = FindObjectOfType<PolygonCollider2D>();
    }
    private void Update()
    {
    }
}
