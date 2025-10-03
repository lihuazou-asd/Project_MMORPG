using System;
using System.Collections;
using Common;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    public Image bar;
    public Text textProgress;

    public GameObject LoginPanel;


    private void Awake()
    {
        Log.Init("Login Panel");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Load");
        Log.Info("1111");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Load()
    {
        bar.fillAmount = 0;
        UpdateProgressText();
        while (bar.fillAmount < 1)
        {
            bar.fillAmount += Time.deltaTime/2;
            UpdateProgressText();
            yield return null;
        }
        this.gameObject.SetActive(false);
        LoginPanel.SetActive(true);
    
    }


    private void UpdateProgressText()
    {
        textProgress.text = (int)(bar.fillAmount * 100) + "%";    
    }
}
