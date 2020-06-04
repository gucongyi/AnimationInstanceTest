using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventTest : MonoBehaviour
{
    public void TestEvent(object obj)
    {
        Debug.LogError($"TestEvent:{obj}");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
