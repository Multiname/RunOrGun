using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class LeftPanel : MonoBehaviour {
    public static LeftPanel Instance { get; private set; }

    private UIDocument uiDocument;
    private Label firstPlayerScoreText;
    private Label secondPlayerScoreText;
    private Button exitButton;
    private Button soundButton;

    private int[] playerIndexes = new int[PlayerIndex.COUNT] { 0, 0 };
    private Label[] playerScoreTexts;

    private bool soundIsMuted = false;

    private void Awake() {
        if (CheckAlreadyCreated()) {
            return;
        }

        uiDocument = GetComponent<UIDocument>();
        FindElements();

        playerScoreTexts = new Label[PlayerIndex.COUNT] {
            firstPlayerScoreText,
            secondPlayerScoreText
        };

        SetButtonsCallbacks();

        #region
        bool CheckAlreadyCreated() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return false;
            } else {
                Destroy(gameObject);
                return true;
            }
        }

        void FindElements() {
            firstPlayerScoreText = uiDocument.rootVisualElement.Q<Label>("FirstPlayerScore");
            secondPlayerScoreText = uiDocument.rootVisualElement.Q<Label>("SecondPlayerScore");
            exitButton = uiDocument.rootVisualElement.Q<Button>("ExitButton");
            soundButton = uiDocument.rootVisualElement.Q<Button>("SoundButton");
        }

        void SetButtonsCallbacks() {
            exitButton.RegisterCallback<ClickEvent>(_ => HandleExitButtonClick());
            soundButton.RegisterCallback<ClickEvent>(_ => HandleSoundButtonClick());
        }
        #endregion
    }

    public void IncrementPlayerScore(PlayerIndex.Index index) {
        int indexInt = (int)index;
        playerScoreTexts[indexInt].text = (++playerIndexes[indexInt]).ToString();
    }

    private void HandleExitButtonClick() {
        Debug.Log("HandleExitButtonClick");
    }

    private void HandleSoundButtonClick() {
        soundIsMuted = !soundIsMuted;
        if (soundIsMuted) {
            soundButton.AddToClassList("muted");
        } else {
            soundButton.RemoveFromClassList("muted");
        }
    }
}
