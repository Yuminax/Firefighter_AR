using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{
    [SerializeField] private GameObject highlight;

    public Readjson data;
    public Quizz quizzManager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = Quizz.FindAnyObjectByType<GameManager>();
        quizzManager = Quizz.FindAnyObjectByType<Quizz>();

        // add listener for manipulation
        var pointerHandler = this.gameObject.AddComponent<PointerHandler>();
        pointerHandler.OnPointerClicked.AddListener((e) => onSelect());

    }

    // called when you touched an hologram
    public void onSelect()
    {
        gameManager.LastObjectTouched(this.gameObject);
        Debug.Log("Last object touched is : " + gameObject.name);

        if(gameManager.previousTouchedObject != gameManager.lastTouchedObject)
        {
            if(gameManager.lastTouchedObject.name =="WildFire(Clone)")
            {
                highlight.SetActive(true);
            }
            else
            {
                highlight.SetActive(false);
            }
            
            // disable highlight on previous hologram if it exist
            try
            {
                if (gameManager.previousTouchedObject.tag == "Victime")
                {
                    // search highlight in children 
                    GameObject previousVictime;
                    previousVictime = gameManager.previousTouchedObject.transform.GetChild(0).gameObject;
                    previousVictime.transform.Find("Highlight").gameObject.SetActive(true);
                }
                else
                {
                    gameManager.previousTouchedObject.transform.Find("Highlight").gameObject.SetActive(false);
                }
            }
            catch
            {
                Debug.Log("No previous");
            }
        }

        // close panel quiz if exist
        try
        {
           GameObject.FindGameObjectWithTag("PanelQuiz").SetActive(false);
        }
        catch { }
        
        // panel quiz refere to this hologram
        quizzManager.indice = 0;
        quizzManager.data = this.data;
        quizzManager.CheckJSONOutOfRange();
    }

}
