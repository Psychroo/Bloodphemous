using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karma : MonoBehaviour
{

    public int karmaLevel;
    public int maxKarmaLevel;

    void Start()
    {
        
        EnemyController.enemyKilled.AddListener(RemoveKarma);
        EnemyController.enemyLived.AddListener(AddKarma);

    }

    void RemoveKarma()
    {
        karmaLevel -= 3;

        Debug.Log($"{karmaLevel}");
    }

    void AddKarma()
    {
        karmaLevel++;

        Debug.Log($"{karmaLevel}");
    }



}
