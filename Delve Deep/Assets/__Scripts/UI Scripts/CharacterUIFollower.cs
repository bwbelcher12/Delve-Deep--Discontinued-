using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIFollower : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text collectionPrefab;
    [SerializeField] TMPro.TMP_Text scoreTracker;
    [SerializeField] float speed;

    public void CollectPoints(int points)
    {
        var collection = Instantiate(collectionPrefab);

        collection.rectTransform.SetParent(this.transform);
        collection.transform.localScale = new Vector3(6, 6, 6);
        collection.transform.position = this.transform.position;
        collection.transform.rotation = this.transform.rotation;
        collection.text = "+" + points;

        scoreTracker.GetComponent<ScoreTracker>().UpdateScore(points);

        StartCoroutine(PointsFade(collection));
    }

    IEnumerator PointsFade(TMPro.TMP_Text collection)
    {
        float x = 0;

        while(x < .7f)
        {
            collection.transform.Translate(0, speed * Time.deltaTime, 0);
            x += Time.deltaTime;

            yield return null;
        }

        Destroy(collection);
    }
}
    
