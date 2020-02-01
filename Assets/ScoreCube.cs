using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ScoreCube : MonoBehaviour
{
    public GameObject[] gameObjectsToCount;
    public float xWidth;
    public float yWidth;
    public float zWidth;

    public Collider myCollider;

    public float scoreNormalized;
    
    public void Start()
    {
        myCollider = GetComponent<Collider>();
        xWidth = myCollider.bounds.extents.x / 2;
        yWidth = myCollider.bounds.extents.y / 2;
        zWidth = myCollider.bounds.extents.z / 2;

        gameObjectsToCount = new GameObject[gameObject.transform.parent.childCount - 1];

        for (int i = 0; i < gameObject.transform.parent.childCount - 1; i++)
        {
            gameObjectsToCount[i] = gameObject.transform.parent.GetChild(i).gameObject;
        }
    }

    public void CheckOverlap()
    {
        Collider[] overlapping = Physics.OverlapBox(this.transform.position, new Vector3(xWidth, yWidth, zWidth));
        int hits = 0;
        for (int i = 0; i < overlapping.Length; i++)
        {
            for (int j = 0; j < gameObjectsToCount.Length; j++)
            {
                if (gameObjectsToCount[j] == overlapping[i].gameObject)
                {
                    hits++;
                }
            }
        }
        scoreNormalized = (float)hits / (float)gameObjectsToCount.Length;
    }

    // Update is called once per frame
    void Update()
    {
        CheckOverlap();
    }
}
