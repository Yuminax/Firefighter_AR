using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject lastTouchedObject;
    public GameObject previousTouchedObject;
    public List<GameObject> listHologram;

    [SerializeField] private GameObject handActivity;
    [SerializeField] private GameObject activitiesSelection;
    [SerializeField] private GameObject arrowFollow;

    // Panel quizz
    [SerializeField] private GameObject btnSubmit;
    [SerializeField] private GameObject answers;
    [SerializeField] private GameObject feedback;

    //Switch mode
    [SerializeField] private Interactable toggleSwitch;
    [SerializeField] private TextMesh lblSwitchMode;

    public void LastObjectTouched(GameObject last)
    {
        previousTouchedObject = lastTouchedObject;
        lastTouchedObject = last;

        arrowFollow.GetComponent<DirectionalIndicator>().DirectionalTarget = last.transform;
    }

    // called when toggleSwitch is pressed
    public void SwitchMode()
    {
        // Disable Highlight and panel
        try
        {
            if (lastTouchedObject.tag == "Victime")
            {
                // search highlight in children 
                GameObject lastVictime;
                lastVictime = lastTouchedObject.transform.GetChild(0).gameObject;
                lastVictime.transform.Find("Highlight").gameObject.SetActive(true);
            }
            else
            {
                lastTouchedObject.transform.Find("Highlight").gameObject.SetActive(false);
            }
            GameObject highlight;
            highlight = lastTouchedObject.transform.GetChild(0).gameObject;
            highlight.transform.Find("Highlight").gameObject.SetActive(true);

        }
        catch { }

        try
        {
            GameObject.Find("MenuActivity(Clone)").SetActive(false);
        }
        catch { }
        try
        {
            GameObject.FindGameObjectWithTag("PanelQuiz").SetActive(false);
        }
        catch { }

        previousTouchedObject = null;
        lastTouchedObject = null;
        arrowFollow.GetComponent<DirectionalIndicator>().DirectionalTarget = null;

        // Participant mode, disable buttons and reset lastObjetTouched
        if (toggleSwitch.IsToggled)
        {
            handActivity.SetActive(false);
            lblSwitchMode.text = "Participant";
            btnSubmit.SetActive(true);
            answers.SetActive(true);
            feedback.SetActive(true);
            activitiesSelection.SetActive(false);

        }
        // Instructeur mode
        else
        {
            handActivity.SetActive(true);
            activitiesSelection.SetActive(true);
            btnSubmit.SetActive(false);
            answers.SetActive(false);
            feedback.SetActive(false);
            lblSwitchMode.text = "Instructeur";
        }
    }

    // freeze hologram position
    public void Validate()
    {
        lastTouchedObject.GetComponent<ObjectManipulator>().enabled = false;
    }

    public void DestroyObj()
    {
        Destroy(lastTouchedObject);
    }

    public void DestroyAll()
    {
        foreach (GameObject i in listHologram)
        {
            DestroyImmediate(i, true);
        }
        listHologram.Clear();
    }
}
