using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    [SerializeField]
    private bool autoPlay;
    private Ball ball;

    
    public bool AutoPlay
    {
        get
        {
            return autoPlay;
        }

        set
        {
            autoPlay = value;
        }
    }



    // Use this for initialization
    void Start()
    {
        //ball = GetComponent<Ball>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AutoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            SelfPlay();
        }
    }

    private void SelfPlay()
    {
        Vector3 ballPosInBlocks = ball.transform.position;

        Vector3 paddlePos = new Vector3(0.0f, this.transform.position.y, 0f);

        paddlePos.x = Mathf.Clamp(ballPosInBlocks.x, 0.5f, 15.50f);
        this.transform.position = paddlePos;
    }

    private void MoveWithMouse()
    {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3(0.0f, this.transform.position.y, 0f);

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.50f);
        this.transform.position = paddlePos;
    }
}
