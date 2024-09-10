using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CurrencyManager : MonoBehaviour
{

    public List<GameObject> currencies = new List<GameObject>();
    public List<GameObject> favorites = new List<GameObject>();
    public List<GameObject> createdOBJs = new List<GameObject>();
    public GameObject theParent;

    private bool favsStarted;

    private void Start()
    {

        favsStarted = false;

    }

    public void PrepareFavourites()
    {
        if (createdOBJs != null)
        {
            foreach (var item in createdOBJs)
            {
                Destroy(item);
            }
        }

        favorites.Clear();

        foreach (var item in currencies)
        {
            if (item.GetComponent<CardUpdater>().isFav)
            {
                favorites.Add(item);
            }
        }

        foreach (var item in favorites)
        {
            if (!createdOBJs.Contains(item))
            {
                var tmpItem = Instantiate(item);
                tmpItem.transform.SetParent(theParent.transform);
                tmpItem.transform.localScale = new Vector3(1, 1, 1);
                tmpItem.transform.localPosition = new Vector3(0,0,0);
                tmpItem.name = tmpItem.GetComponent<CardUpdater>().goName;
                createdOBJs.Add(tmpItem);
            }
        }

    }

    private void startCurrs()
    {
        if (!favsStarted)
        {
            bool loopDone = false;
            int total = 0;

            while (!loopDone)
            {
                total = 0;

                foreach (var item in currencies)
                {
                    if (!item.GetComponent<CardUpdater>().cardStarted)
                    {
                        return;
                    }
                    else
                    {
                        total++;
                    }
                }

                if (total == currencies.Count)
                {
                    loopDone = true;
                }

            }

            PrepareFavourites();
            favsStarted = true;

        }


    }

    private void Update()
    {

        startCurrs();
    }

}


