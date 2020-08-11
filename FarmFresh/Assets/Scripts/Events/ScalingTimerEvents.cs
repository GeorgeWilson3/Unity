
using System;
using UnityEngine;

public class ScalingTimerEvents : MonoBehaviour
{
    private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
    public float timer;
    private float freshTimer = 999f;
    private bool reducedTo25 = false;
    private bool reducedTo50 = false;
    private bool reducedTo75 = false;


    // Start is called before the first frame update
    void Start()
    {
        GameEvents.countdownTimer.AddListener(SetAndStartTimer);
    }

    private void SetAndStartTimer(float countdownTime)
    {
        stopwatch.Start();
        freshTimer = countdownTime;
    }

    public void FixedUpdate()
    {
        if(! stopwatch.IsRunning)
        {
            return;
        }

        long timeSpan = stopwatch.ElapsedMilliseconds / 1000;
        timer += Time.deltaTime;
        float secondsRunning = timer;
        float scalingSize = 1f;

        Vector3 vector3 = new Vector3();
        vector3 = transform.localScale;

        if (timeSpan > freshTimer)
        {
            stopwatch.Stop();
            freshTimer = 0;

            GameEvents.CollisionEvent?.Invoke(new GameObjectCollisionData(this.gameObject, this.gameObject));
        }
        else if ((freshTimer - timeSpan) / freshTimer * 100 < 25)
        {
            if (!reducedTo25)
            {
                scalingSize = .5f;
                reducedTo25 = true;
            }
        }
        else if ((freshTimer - timeSpan) / freshTimer * 100 < 50)
        {
            if (!reducedTo50)
            {
                scalingSize = .65f;
                reducedTo50 = true;
            }
        }
        else if ((freshTimer - timeSpan) / freshTimer * 100 < 75)
        {
            if (!reducedTo75)
            {
                scalingSize = .85f;
                reducedTo75 = true;
            }
        }

        vector3.x *= scalingSize;
        vector3.y *= scalingSize;

        transform.localScale = vector3;
    }
}
