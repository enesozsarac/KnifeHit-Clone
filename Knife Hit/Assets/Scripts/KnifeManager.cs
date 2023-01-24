using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();
    [SerializeField] private List<GameObject> knifeIconList = new List<GameObject>();

    [SerializeField] private Vector2 knifeIconPositon;

    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject knifeIconPrefab;

    [SerializeField] private Color activeColor;
    [SerializeField] private Color disableColor;


    [SerializeField] private int knifeCount;
    private int knifeIndex;
   
    private void Start()
    {
        CreateKnife();
        CreateKnifeIcon();
    }


    private void CreateKnife()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnife = Instantiate(knifePrefab, transform.position , Quaternion.identity);
            newKnife.SetActive(false);
            knifeList.Add(newKnife);
        }

        knifeList[0].SetActive(true);
    }

    private void CreateKnifeIcon()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnifeIcon = Instantiate(knifeIconPrefab, knifeIconPositon, knifeIconPrefab.transform.rotation);
            newKnifeIcon.GetComponent<SpriteRenderer>().color = activeColor;
            knifeIconPositon.y += 0.5f;
            knifeIconList.Add(newKnifeIcon);
        }
    }

    public void SetDisableKnifeIconColor()
    {
        knifeIconList[(knifeIconList.Count -1 )- knifeIndex].GetComponent<SpriteRenderer>().color = disableColor;
    }

    public void SetActiveKnife()
    {
        if (knifeIndex < knifeCount -1)
        {
            knifeIndex++;
            knifeList[knifeIndex].SetActive(true);
        }
    }
}
