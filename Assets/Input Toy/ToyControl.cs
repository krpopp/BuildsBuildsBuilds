using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyControl : MonoBehaviour
{
    bool holding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(holding)
        {
            Vector3 newPos = transform.position;
            Vector3 screenMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.x = screenMouse.x;
            newPos.y = screenMouse.y;
            transform.position = newPos;
        }
        if (Input.GetMouseButtonUp(0) && holding) holding = false;
    }

    void OnMouseDown()
    {
        holding = true;
    }
}
