using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    public bool anyDefenders;
    public List<GameObject> defenders ;
    public float percent;
    // Start is called before the first frame update
    void Start()
    {
        ChangeDefenders();
    }

    public void ChangeDefenders()
    {
        float canCreate = Random.Range(0f, 100f);
        if (canCreate < percent)
        {
            RemoveAllDefenders();
            if (anyDefenders)
            {
                GameObject[] GetTotalDefenders = Resources.LoadAll<GameObject>("Defenders");
                Instantiate(GetTotalDefenders[Random.Range(0, GetTotalDefenders.Length)], transform);
            }
            else
            {
                Instantiate(defenders[Random.Range(0, defenders.Count)], transform);
            }
        }
    }
    private void RemoveAllDefenders()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
