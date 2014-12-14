using UnityEngine;
using System.Collections;

public class trapLaserBeam : MonoBehaviour
{
    public float enabledTime = 2;
    public float disabledTime = 1;
    public float waitTime = 0;
    public bool isVertical = true;

    private float maxSize;
    private float elapsedTime = 0;
    private float growthRate = 100;

    private enum States
    {
        waiting,
        growing,
        activated,
        shrinking,
        deactivated
    };
    private States currentState = States.waiting;

    // Use this for initialization
    void Start()
    {
        if (isVertical)
        {
            maxSize = transform.localScale.x;
        }
        else
        {
            maxSize = transform.localScale.y;
        }
        gameObject.collider2D.enabled = false;
        gameObject.renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float currentSize;
        switch (currentState)
        {
            case States.waiting:
                if (elapsedTime >= waitTime)
                {
                    elapsedTime = 0;
                    currentState = States.growing;
                    if (isVertical)
                    {
                        transform.localScale = new Vector3(Vector3.one.x, transform.localScale.y, transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(transform.localScale.x, Vector3.one.y, transform.localScale.z);
                    }
                    gameObject.collider2D.enabled = true;
                    gameObject.renderer.enabled = true;
                }
                else
                {
                    elapsedTime += Time.deltaTime;
                }
                break;

            case States.growing:

                if (isVertical)
                {
                    transform.localScale += new Vector3(Vector3.one.x * growthRate * Time.deltaTime, 0, 0);
                    currentSize = transform.localScale.x;
                }
                else
                {
                    transform.localScale += new Vector3(0, Vector3.one.y * growthRate * Time.deltaTime, 0);
                    currentSize = transform.localScale.y;
                }
                if (currentSize >= maxSize)
                {
                    currentState = States.activated;
                }
                break;

            case States.activated:
                if (elapsedTime >= enabledTime)
                {
                    elapsedTime = 0;
                    currentState = States.shrinking;
                }
                else
                {
                    elapsedTime += Time.deltaTime;
                }
                break;

            case States.shrinking:

                if (isVertical)
                {
                    transform.localScale -= new Vector3(Vector3.one.x * growthRate * Time.deltaTime, 0, 0);
                    currentSize = transform.localScale.x;
                }
                else
                {
                    transform.localScale -= new Vector3(0, Vector3.one.y * growthRate * Time.deltaTime, 0);
                    currentSize = transform.localScale.y;
                }
                if (currentSize <= Vector3.one.x)
                {
                    currentState = States.deactivated;
                    gameObject.collider2D.enabled = false;
                    gameObject.renderer.enabled = false;
                }
                break;

            case States.deactivated:
                if (elapsedTime >= disabledTime)
                {
                    elapsedTime = 0;
                    currentState = States.growing;
                    gameObject.collider2D.enabled = true;
                    gameObject.renderer.enabled = true;
                }
                else
                {
                    elapsedTime += Time.deltaTime;
                }
                break;
        }
    }
}