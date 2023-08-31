using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LoadPrefabs : MonoBehaviour
{
    private GameObject objCamera;
    private Vector3 SpawnPosition;
    private float DistanceToCamera = 0.5f;
    [SerializeField] private GameObject prefabs;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        objCamera = (GameObject)GameObject.FindWithTag("MainCamera");
        gameManager = GameManager.FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load()
    {
        SpawnPosition = objCamera.transform.forward * DistanceToCamera + objCamera.transform.position;
        GameObject activitie = Instantiate(prefabs, SpawnPosition, Quaternion.identity);

        gameManager.listHologram.Add(activitie);
    }
   
}
