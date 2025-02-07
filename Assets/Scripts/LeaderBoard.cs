using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public static LeaderBoard instance;
    private RectTransform rect;
    public GameObject wordCellPrefab;
    public Transform scrollViewContent;
    private void Awake()
    {
        instance = this;
    }
    public void ResetLeaderBoard()
    {
        // Destroy all spawned quiz cells
        foreach (Transform child in scrollViewContent)
        {
            Destroy(child.gameObject);
        }
    }
    public void SpawnLeaderBoard(float delay)
    {
        GameObject cell = Instantiate(wordCellPrefab, scrollViewContent);
        print("LeaderBoard spawned");
        Text[] textComponents = cell.GetComponentsInChildren<Text>();
        textComponents[0].text = "#1";
        textComponents[1].text = "Gauraang";
        textComponents[2].text = "0.3";

        cell.transform.DOScale(0, 0.3f).SetEase(Ease.OutBack).From().SetDelay(delay);
    }
}
