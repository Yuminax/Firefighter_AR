using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quizz : MonoBehaviour
{
    public Readjson data;
    public int indice = 0;

    // Panel Quizz
    [SerializeField] private TextMeshPro situationText;
    [SerializeField] private TextMesh answer1Text;
    [SerializeField] private TextMesh answer2Text;
    [SerializeField] private TextMesh answer3Text;
    [SerializeField] private InteractableToggleCollection radioButtons;
    [SerializeField] private TextMeshPro feedback;

    public TextMeshPro title;

    // Check if indice is out of the situations range
    // insert text and answers connect to the indice
    public void CheckJSONOutOfRange()
    {
        // indice == Count -1 
        if (indice < data.situations.Count)
        {
            Situation();
            Answers();
            CorrectAnswer();

            title.text = data.title + " - " + data.theme;
        }
        else if (indice == data.situations.Count)
        {
            CorrectAnswer();
            answer1Text.text = "";
            answer2Text.text = "";
            answer3Text.text = "";

            situationText.text = "Il n'y a plus de question concernant cette situation. Vous pouvez fermer cette fenêtre.";
        }
        else // only if user click on "soumettre" again
        {
            answer1Text.text = "";
            answer2Text.text = "";
            answer3Text.text = "";
            feedback.text = "";

            situationText.text = "Il n'y a plus de question concernant cette situation. Vous pouvez fermer cette fenêtre.";
        }

        indice++;
    }

    public void Answers()
    {
        answer1Text.text = data.answer1[indice];
        answer2Text.text = data.answer2[indice];
        answer3Text.text = data.answer3[indice];
    }

    public void Situation()
    {
        situationText.text = data.situations[indice];
    }

    public void CorrectAnswer()
    {
        if (indice > 0)
        {
            if (data.correct[indice-1] == radioButtons.CurrentIndex+1)
            {
                feedback.text = "Excellent la réponse précédente était correcte.";
            }
            else
            {
                feedback.text = "Dommage, la bonne réponse était la numéro : " + data.correct[indice-1];
            }
        }

    }

}
