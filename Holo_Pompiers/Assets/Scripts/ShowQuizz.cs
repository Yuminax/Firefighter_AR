using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuizz : MonoBehaviour
{

    private GameObject objCamera;
    private Vector3 SpawnPosition;
    private float DistanceToCamera = 0.5f;
    [SerializeField] GameObject quizz;


    // Start is called before the first frame update
    void Start()
    {
        objCamera = (GameObject)GameObject.FindWithTag("MainCamera");
    }

    public void showUnshow()
    {
        quizz.SetActive(!quizz.activeSelf);

        SpawnPosition = objCamera.transform.forward * DistanceToCamera + objCamera.transform.position;
        quizz.transform.position = SpawnPosition;
    }
}
