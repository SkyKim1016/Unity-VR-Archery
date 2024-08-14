using System.Collections;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine; // Import the UnityEngine namespace

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _currentScoreText; // Reference to the UI text component displaying the current score
    [SerializeField]
    private TextMeshProUGUI _highestScoreText; // Reference to the UI text component displaying the highest score
    [SerializeField]
    private TimerController _timerController; // Reference to the TimerController component
    [SerializeField]
    private TargetsSpawner _targetSpawner;
    [SerializeField]
    private float _delayBeforeStart;

    private int _currentScore; // Variable to store the current score
    private int _highestScore; // Variable to store the highest score

    // Start is called before the first frame update
    void Start()
    {
        AssignStartingValues(); // Call method: AssignStartingValues
        UpdateUI(); // Call method: UpdateUI
        AddListeners(); // Call method: AddListeners
        LaunchExperience(); // Call method: LaunchExperience
    }

    // Method to start the game experience
    public void LaunchExperience()
    {
        StartCoroutine(DelayExperienceLaunching());
    }

    // Coroutine to delay the experience launch
    private IEnumerator DelayExperienceLaunching()
    {
        yield return new WaitForSeconds(_delayBeforeStart); // Wait for the specified delay
        _timerController.PlayAnimation(); // Call method: _timerController.PlayAnimation
        _targetSpawner.SpawnTargets();
    }

    // Method to add event listeners
    private void AddListeners()
    {
        _timerController.TimeOut.AddListener(FinishGame); // Call method: _timerController.TimeOut.AddListener(FinishGame)
    }

    // Method to assign initial values to variables
    private void AssignStartingValues()
    {
        _currentScore = 0; // Set the current score to 0
        _highestScore = PlayerPrefs.GetInt("HighestScore", 0); // Load the highest score from PlayerPrefs, default to 0 if not found
    }

    // Method to update the UI
    private void UpdateUI()
    {
        UpdateDisplayedCurrentScore(); // Call method: UpdateDisplayedCurrentScore
        UpdateHighestScoreUI(); // Call method: UpdateHighestScoreUI
    }

    // Method called when the game finishes
    private void FinishGame()
    {
        Debug.Log("FinishGame"); // Log that the game has finished
        if (_currentScore > _highestScore) // Check if the current score is greater than the highest score
        {
            _highestScore = _currentScore; // Update the highest score
            PlayerPrefs.SetInt("HighestScore", _highestScore); // Save the new highest score to PlayerPrefs

          /*  // To load:
            PlayerPrefs.GetInt("HighScore");

            // To delete
            PlayerPrefs.DeleteKey("HighestScore");

            //or
            PlayerPrefs.DeleteAll();  // Careful!;*/

        }
        UpdateHighestScoreUI(); // Call method: UpdateHighestScoreUI
        _targetSpawner.DestroyAllTargets();

    }

    // Method called to add one hit to the current score
    public void AddOneHit()
    {
        _currentScore++; // Increment the current score by 1
        UpdateDisplayedCurrentScore(); // Call method: UpdateDisplayedCurrentScore
    }

    // Method to update the displayed current score
    private void UpdateDisplayedCurrentScore()
    {
        _currentScoreText.text = _currentScore.ToString(); // Update the text component with the current score
    }

    // Method to update the displayed highest score
    private void UpdateHighestScoreUI()
    {
        _highestScoreText.text = _highestScore.ToString(); // Update the text component with the highest score
    }
}