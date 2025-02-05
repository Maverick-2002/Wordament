using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuizScroll : MonoBehaviour
{
    private RectTransform rect;
    public static QuizScroll instance;
    public GameObject wordCellPrefab;
    public Transform scrollViewContent;
    private void Awake()
    {
        instance = this;
       /* rect = GetComponent<RectTransform>();
        WordHunt wh = WordHunt.instance;
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, (wh.cellSize.y + wh.cellSpacing.y) * wh.gridSize.y);*/
    }
    public void SpawnQuizCell(string word, float delay)
    {
        GameObject cell = Instantiate(wordCellPrefab, scrollViewContent);
        cell.GetComponentInChildren<Text>().text = word.ToUpper();
        cell.transform.DOScale(0, 0.3f).SetEase(Ease.OutBack).From().SetDelay(delay);
    }
}
