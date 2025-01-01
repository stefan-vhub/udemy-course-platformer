using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TrapSaw : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] wayPoint;

    public int wayPointIndex = 1;

    private void Start()
    {
        transform.position = wayPoint[0].position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint[wayPointIndex].position, moveSpeed * Time.deltaTime);
    }
}
