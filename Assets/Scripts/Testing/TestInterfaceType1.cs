using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TestInterfaceType1 : ITestInterface
{
    public void Fight()
    {
        Debug.Log("Fight Style 1");
    }
    

}
