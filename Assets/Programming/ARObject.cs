using UnityEngine;

public class ARObject : MonoBehaviour {
    float mouseHorizontal = 0;
    float mouseVertical = 0;
    float speed = 10f;
    public CharacterInfo arCharacterInfo;
    UIManager arObjectUIManager;

    #region Singleton
        public static ARObject instance;

        void Awake() {
            if(instance != null) {
                return;
            }
            instance = this;
        }
    #endregion

    void Start() {
        arObjectUIManager = UIManager.instance;

        ClearARObject();
    }

    void Update() {
        ViewARObject();
    }

    void ViewARObject() {
        mouseHorizontal -= Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        // mouseVertical += Input.GetAxis("Mouse Y");

        Quaternion mouseRotation = Quaternion.Euler(0, mouseHorizontal, 0);
        gameObject.transform.localRotation = mouseRotation;
    }

    public void SpawnARObject(GameObject _arObject) {
        // Debug.Log("SpawnARObject");
        // Debug.Log("_arObject: " + _arObject);

        if(arObjectUIManager != null) {
            // arObjectUIManager.ShowARObjectPanel();
            arObjectUIManager.SwitchARObjectPanel(true);
        }
        mouseHorizontal = 0;

        GameObject newARObject = Instantiate(_arObject, this.gameObject.transform);
        newARObject.transform.localPosition = new Vector3(0, -0.1f, 0);
        newARObject.transform.localRotation = Quaternion.Euler(0, 180f, 0);
        Renderer[] newARObjectRenderers = newARObject.GetComponentsInChildren<Renderer>();
        foreach(Renderer arObjectRenderer in newARObjectRenderers) {
            arObjectRenderer.enabled = true;
        }

    }

    public void ClearARObject() {
        if(arObjectUIManager != null) {
            // arObjectUIManager.HideARObjectPanel();
            arObjectUIManager.SwitchARObjectPanel(false);
        }
        if(gameObject.transform.childCount > 0) {
            for(int i = 0; i < gameObject.transform.childCount; i = i + 1) {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }
        }
    }
}