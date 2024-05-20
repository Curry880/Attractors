using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int mergeCount { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        mergeCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementMergeCount()
    {
        mergeCount++;
    }
}
