using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{

    private static UiManager instance;
    public static UiManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    public Animator statsBar;

    [Header("StatTitle")]
    public GameObject trapEncountered;
    public GameObject jumpsMade;
    public GameObject dashesDone;

    private void Awake()
    {
        Instance = null;
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != null)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void DragStatsDown()
    {
        statsBar.SetTrigger("PullStats");
        StartCoroutine(ShowStats());
    }

    IEnumerator ShowStats()
    {
        yield return new WaitForSeconds(1);
        trapEncountered.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        trapEncountered.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(GameManager.Instance.trapsEncountered.ToString());
        trapEncountered.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        dashesDone.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        dashesDone.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(GameManager.Instance.dashesDone.ToString());
        dashesDone.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        jumpsMade.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        jumpsMade.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(GameManager.Instance.jumpsDone.ToString());
        jumpsMade.transform.GetChild(0).gameObject.SetActive(true);

    }
}
