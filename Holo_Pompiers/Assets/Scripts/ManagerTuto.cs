using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerTuto : MonoBehaviour
{
    private int step = 0;
    
    // Camera
    private GameObject objCamera;
    private Vector3 SpawnPosition;
    private float DistanceToCamera = 1f; 

    public GameManager gameManager;

    [SerializeField] private TextMeshPro instruction;

    [SerializeField] private GameObject panelinstruction;
    [SerializeField] private GameObject btnActivities;
    [SerializeField] private GameObject btnDelete;
    [SerializeField] private GameObject btnDeleteAll;
    [SerializeField] private GameObject btnAssignQuizz;
    [SerializeField] private GameObject btnShowQuizz;
    [SerializeField] private GameObject quitTuto;

    [SerializeField] private Interactable toggleSwitch;

    // Start is called before the first frame update
    void Start()
    {
        objCamera = (GameObject)GameObject.FindWithTag("MainCamera");
        gameManager = Quizz.FindAnyObjectByType<GameManager>();
    }

    public void ShowQuizz()
    {
        step = 7;
        quitTuto.SetActive(true);
        instruction.text = "Maintenant vous pouvez r�pondre aux questions du quiz.\n\n" +
                           "Ceci conclu le tutoriel, vous pouvez continuer d'essayer l'application ou quitter le tutoriel via le bouton ci-dessous.";
    }

    public void Activities()
    {
        step = 3;
        instruction.text = "Choisissez un hologramme � placer. \n\nTouchez le pour le d�placer o� vous le souhait� puis regardez votre paume droite.\n\n" +
                           "Le dernier objet touch� � un rep�re visuel bleu et une fl�che indiquant son emplacement.";

    }


    public void AssignQuizzPanel()
    {
        step = 5;
        instruction.text = "Le panel affiche les quiz reli� au type de l'objet actif. Il faut appuyer sur un bouton pour assigner le quiz souhait�.\n\n" +
                           "Une fois le quiz assign� passer en mode \"Participant\"";
    }

    public void SwitchMode()
    {
        switch(step){
            case 0:
                step = 1;
                instruction.text = "Vous �tes dans le mode Participant. Beaucoup d'int�ractions ne sont plus disponible.\n\n" +
                  "Repassez en mode instructeur pour la suite des instructions.";
                break;

            case 1:
                step = 2;
                instruction.text = "Le bouton \"Activit�s\" vous permets d'ouvrir un panel contenant tous les hologrammes que vous pouvez poser.";
                btnActivities.SetActive(true);
                break;
            case 5:
                step = 6;
                btnShowQuizz.SetActive(true);
                instruction.text = "Pincez l'hologramme o� un quiz est assign� puis appuyez sur \"afficher quiz\"";
                break;
            default:
                if (toggleSwitch.IsToggled)
                {
                    instruction.text = "Vous �tes dans le mode Participant. Le but est de r�pondre aux questions des quiz.";
                }
                else
                {
                    instruction.text = "Vous �tes dans le mode Instructeurs. Le but est de poser des hologrammes et assigner des quiz � ceux-ci.";
                }
                break;
        }
    }

    public void Validate()
    {
        step = 4;
        instruction.text = "Ce bouton fige la position de l'hologramme, mais vous pouvez toujours le s�lectionner, ce n'est pas une action obligatoire.\n\nSi la place ne vous convient pas vous pouvez supprimer l'hologramme s�lectionn� ou tous en m�me temps.\n\n" +
                           "Pour la suite appuyer sur \"assigner un quiz\"";
        btnDelete.SetActive(true);
        btnDeleteAll.SetActive(true);
        btnAssignQuizz.SetActive(true);
    }
}
