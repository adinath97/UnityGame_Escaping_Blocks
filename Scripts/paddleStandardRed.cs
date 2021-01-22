using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleStandardRed : MonoBehaviour
{
    public float padding = 1f;
    private float moveSpeed = 5f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float newXPos;
    float newYPos;
    Vector2 screenPosition;
    Vector2 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayerPaddle();
    }

    private void MovePlayerPaddle()
    {
        screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        float mousePosInUnits = worldPosition.x;
        newXPos = Mathf.Clamp(mousePosInUnits, xMin, xMax);
        this.transform.position = new Vector2(newXPos, transform.position.y);

        //var deltaX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        //var newXPos = transform.position.x + deltaX;
        //var xPosFinal = Mathf.Clamp(newXPos, xMin, xMax);
        //transform.position = new Vector2(xPosFinal, transform.position.y);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
