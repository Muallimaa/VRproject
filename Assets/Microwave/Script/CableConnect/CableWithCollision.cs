using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CableWithCollision : MonoBehaviour

{
    public int segments = 10;
    public float segmentLength = 1.0f;
    public float stiffness = 0.1f;
    public Transform endPoint;
    public float gravity = 9.81f;

    private Transform[] ropeSegments;
    private Vector3[] currentPositions;
    private Vector3[] velocities;

    private void Start()
    {
        InitializeRope();
    }

    private void Update()
    {
        SimulateRope();
        UpdateRopeVisual();
    }

    private void InitializeRope()
    {
        ropeSegments = new Transform[segments];
        currentPositions = new Vector3[segments];
        velocities = new Vector3[segments];

        for (int i = 0; i < segments; i++)
        {
            GameObject segment = GameObject.CreatePrimitive(PrimitiveType.Cube);
            segment.transform.position = transform.position + Vector3.up * i * segmentLength;
            segment.transform.localScale = new Vector3(0.1f, segmentLength, 0.1f);
            ropeSegments[i] = segment.transform;

            currentPositions[i] = ropeSegments[i].position;
            velocities[i] = Vector3.zero;
        }
    }

    private void SimulateRope()
    {
        for (int i = 1; i < segments; i++)
        {
            Vector3 gravityForce = Vector3.down * gravity * Time.deltaTime;
            Vector3 springForce = (currentPositions[i - 1] - currentPositions[i]) * stiffness;

            velocities[i] += (gravityForce + springForce) * Time.deltaTime;
            currentPositions[i] += velocities[i] * Time.deltaTime;

            ropeSegments[i].position = currentPositions[i];
        }

        ropeSegments[segments - 1].position = endPoint.position;
    }

    private void UpdateRopeVisual()
    {
        for (int i = 1; i < segments; i++)
        {
            Debug.DrawLine(currentPositions[i - 1], currentPositions[i], Color.red);
        }
    }
}