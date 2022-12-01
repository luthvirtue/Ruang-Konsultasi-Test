using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public GameObject SeminarPanel;
    public GameObject[] WebinarPanels;

    void Start()
    {
        ShowMainMenu();
    }

    public void SelectWebinar(int index)
    {
        SeminarPanel.SetActive(false);
        foreach (GameObject panel in WebinarPanels)
        {
            panel.SetActive(false);
        }
        WebinarPanels[index].SetActive(true);
    }

    public void ShowMainMenu()
    {
        SeminarPanel.SetActive(true);
        foreach (GameObject panel in WebinarPanels)
        {
            panel.SetActive(false);
        }
    }
}
