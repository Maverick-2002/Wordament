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
    public void SpawnLeaderBoard(string name, int pos , string time , float delay)
    {
        GameObject cell = Instantiate(wordCellPrefab, scrollViewContent);
        print("LeaderBoard spawned");
        Text[] textComponents = cell.GetComponentsInChildren<Text>();
        textComponents[0].text = pos.ToString();
        textComponents[1].text = name;
        textComponents[2].text = time;

        cell.transform.DOScale(0, 0.3f).SetEase(Ease.OutBack).From().SetDelay(delay);
    }
}
