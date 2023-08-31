using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{
    private GameObject objCamera;
    private Vector3 SpawnPosition;
    private float DistanceToCamera = 1f;

    // Menu to load
    [SerializeField] private GameObject VictimeMenu;
    [SerializeField] private GameObject FireMenu;
    [SerializeField] private GameObject activitySelection;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        objCamera = (GameObject)GameObject.FindWithTag("MainCamera");
        gameManager = GameManager.FindAnyObjectByType<GameManager>();
    }

    public void loadMenu()
    {
        SpawnPosition = objCamera.transform.forward * DistanceToCamera + objCamera.transform.position;
        
        if (!GameObject.Find("MenuActivity(Clone)"))
        {
            Instantiate(activitySelection, SpawnPosition, objCamera.transform.rotation);
        }
        else
        {
            GameObject menu = GameObject.Find("MenuActivity(Clone)");
            menu.transform.position = SpawnPosition;
            menu.transform.rotation = objCamera.transform.rotation;
        }
        
    }

    public void loadQuizzSelection()
    {

        SpawnPosition = objCamera.transform.forward * DistanceToCamera + objCamera.transform.position;

        if(gameManager.lastTouchedObject.tag == "Victime")
        {
            if(!GameObject.Find("PanelVictime(Clone)"))
            {
                Instantiate(VictimeMenu, SpawnPosition, objCamera.transform.rotation);
            }
            
        }
        else
        {
            if (!GameObject.Find("PanelFire(Clone)"))
            {
                Instantiate(FireMenu, SpawnPosition, objCamera.transform.rotation);
            }
        }
    }
}
