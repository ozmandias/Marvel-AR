using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] GameObject arObjectPanel;
    [SerializeField] GameObject characterInfoPanel;
    [SerializeField] Text nameText;
    [SerializeField] Text historyText;
    [SerializeField] Image powerGridImage;

    #region Singleton
        public static UIManager instance;

        void Awake() {
            if(instance != null) {
                return;
            }
            instance = this;
        }
    #endregion

    void Start() {
        // HideARObjectPanel();
        SwitchARObjectPanel(false);
        ToggleCharacterInfoPanel();
    }

    void Update() {

    }

    public void ShowARObjectPanel() {
        arObjectPanel.SetActive(true);
    }
    public void HideARObjectPanel() {
        arObjectPanel.SetActive(false);
    }

    public void ShowCharacterInfoPanel() {
        characterInfoPanel.SetActive(true);
    }
    public void HideCharacterInfoPanel() {
        characterInfoPanel.SetActive(false);
    }

    public void SwitchARObjectPanel(bool _switch) {
        Button[] arObjectButtons = arObjectPanel.GetComponentsInChildren<Button>();
        foreach(Button arObjectButton in arObjectButtons) {
            // arObjectButton.enabled = _switch;
            arObjectButton.interactable = _switch;
        }
    }

    public void ToggleCharacterInfoPanel() {
        if(characterInfoPanel.activeSelf == true) {
            HideCharacterInfoPanel();
        } else {
            ShowCharacterInfoPanel();
        }
    }

    public void SetNameText(string _name) {
        nameText.text = _name;
    }
    public void SetHistoryText(string _history) {
        historyText.text = _history;
    }
    public void SetPowerGridImage(Sprite _powerGridSprite) {
        powerGridImage.sprite = _powerGridSprite;
    }
}