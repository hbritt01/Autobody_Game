using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tire_Pump : MonoBehaviour
{
    public Slider psiSlider;
    public Text countdownText;
    public Text resultText;
    public Button startButton;
    
    private int spacePressCount = 0;
    private bool gameStarted = false;

    private void Start()
    {
        resultText.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartCountdown);
    }

    private void Update()
    {
        if (gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            spacePressCount++;
            // Increase PSI value
            if (psiSlider.value < 40)
            {
                psiSlider.value += 0.5f;
            }
        }
    }

    private void StartCountdown()
    {
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        startButton.interactable = false;
        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "Go!";
        gameStarted = true;
        yield return new WaitForSeconds(1);

        countdownText.text = "10";
        yield return new WaitForSeconds(1);
        countdownText.text = "9";
        yield return new WaitForSeconds(1);
        countdownText.text = "8";
        yield return new WaitForSeconds(1);
        countdownText.text = "7";
        yield return new WaitForSeconds(1);
        countdownText.text = "6";
        yield return new WaitForSeconds(1);
        countdownText.text = "5";
        yield return new WaitForSeconds(1);
        countdownText.text = "4";
        yield return new WaitForSeconds(1);
        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "Times Up!";
        gameStarted = true;
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);
        EndGame();
    }

    private void EndGame()
    {
        gameStarted = false;
        ShowResult();
    }

    private void ShowResult()
    {
        resultText.gameObject.SetActive(true);

        if (spacePressCount > 80)
        {
            resultText.text = "You are amazing!";
        }
        else if (spacePressCount >= 60)
        {
            resultText.text = "I've seen better.";
        }
        else if (spacePressCount >= 40)
        {
            resultText.text = "You stink.";
        }
        else
        {
            resultText.text = "Get a new job.";
        }
    }
}

