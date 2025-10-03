using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    public Image bar;
    public Text textProgress;

    public GameObject LoginPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Load");
        Log.Info("");
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
