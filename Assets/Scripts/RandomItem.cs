using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] itemPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    private void Start()
    {
        StartCoroutine(ItemSpawn());

    }

    IEnumerator ItemSpawn()
    {
        while(true)
        {
            var posInit = Random.Range(minX, maxX);
            var position = new Vector3(posInit, transform.position.y);
            GameObject gameObject = Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
}
