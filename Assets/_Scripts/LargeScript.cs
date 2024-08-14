using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeScript : MonoBehaviour
{
    [SerializeField] private SmallScript _smallScript;


    private void Start()
    {
        CallSmallScript();
    }

    public void CallSmallScript()
    {
        int firstRandom = Random.Range(0, 10);
        int secondRandom = Random.Range(0, 10);
        int finalResult =_smallScript.Mult(firstRandom, secondRandom);
        Debug.Log(finalResult); 
    }

}
