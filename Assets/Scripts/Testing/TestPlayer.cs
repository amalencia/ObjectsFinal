using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private ITestInterface testInterfacers;
    //[SerializeReference] private TestChild testChild;
    // Start is called before the first frame update
    void Start()
    {
        //testInterfacers = new TestInterfaceType1();
        //testChild = new TestChild(testInterfacers);
        //testChild.PerformFight();
        //int tester1 = testChild.Health;
        //Debug.Log("testing health if works: " + tester1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
