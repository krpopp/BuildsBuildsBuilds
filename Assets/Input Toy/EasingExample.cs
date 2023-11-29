using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingExample : MonoBehaviour
{
    [SerializeField] AnimationCurve moveCurve;

    bool easeIn = false;

    Vector3 startValue;
    [SerializeField] Vector3 endValue;
    [SerializeField] float time = 1f;

    // Start is called before the first frame update
    void Start()
    {
        startValue = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!easeIn)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //start the movement
                //MoveAlso();
                StartCoroutine(Move());
                easeIn = true;
            }
        }
    }

    //coroutine allows us to control when it executes
    //when this one reaches "yielf return null", it will pause execution for this frame
    //and return the next frame
    IEnumerator Move()
    {
        float i = 0;
        float rate = 1 / time;
        while(i < 1)
        {
            i += rate * Time.deltaTime;
            transform.localScale = Vector3.LerpUnclamped(startValue, endValue, moveCurve.Evaluate(i));
            yield return null;
        }
    }

    //if we were to run the same code in a regular function
    //it would execute all at once
    //and then not animate
    private void MoveAlso()
    {
        float i = 0;
        float rate = 1 / time;
        while (i < 1)
        {
            i += rate * Time.deltaTime;
            transform.localScale = Vector3.LerpUnclamped(startValue, endValue, moveCurve.Evaluate(i));
        }
    }
}
