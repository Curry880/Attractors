using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyOrbit : MonoBehaviour
{
    public List<int> currentSequence = new List<int>();
    List<List<int>> targetSequences = new List<List<int>>()
    {
        new List<int>(){1, 2, 3, 4},
        new List<int>(){2, 3, 4, 1},
        new List<int>(){3, 4, 1, 2},
        new List<int>(){4, 1, 2, 3},
        new List<int>(){4, 3, 2, 1},
        new List<int>(){3, 2, 1, 4},
        new List<int>(){2, 1, 4, 3},
        new List<int>(){1, 4, 3, 2}
    };

    Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsArrayInMultiArray(currentSequence, targetSequences))
        {
            ScoreManager.instance.AddScore(100 * enemy.mergeCount * enemy.mergeCount);
            Debug.Log("Destroy:AddScore");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Up")
        {
            currentSequence.Add(1);
        }
        else if (collision.gameObject.name == "Right")
        {
            currentSequence.Add(2);
        }
        else if (collision.gameObject.name == "Down")
        {
            currentSequence.Add(3);
        }
        else if (collision.gameObject.name == "Left")
        {
            currentSequence.Add(4);
        }
        if (currentSequence.Count > 4)
        {
            currentSequence.RemoveAt(0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Orbit")
        {
            Debug.Log("Exit");
            currentSequence.Clear();
        }
    }
    bool IsArrayInMultiArray(List<int> target, List<List<int>> multiArray)
    {
        foreach (var array in multiArray)
        {
            if (target.SequenceEqual(array))
            {
                return true;
            }
        }
        return false;
    }
}
