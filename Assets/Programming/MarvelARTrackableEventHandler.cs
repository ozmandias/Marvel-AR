using UnityEngine;
using Vuforia;

public class MarvelARTrackableEventHandler : DefaultTrackableEventHandler {
    ARObject marvelARObject;
    UIManager marvelUIManager;
    bool tracking = false;

    protected override void Start() {
        base.Start();
        marvelARObject = ARObject.instance;
        marvelUIManager = UIManager.instance;
    }

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        tracking = true;
        Debug.Log("Marvel AR OnTrackingFound");
        if(marvelARObject != null) {
            marvelARObject.ClearARObject();
        }
        if(marvelUIManager != null) {
            GameObject currentARObject = gameObject.transform.GetChild(0).gameObject;
            marvelUIManager.SetNameText(currentARObject.GetComponent<ARData>().arCharacterInfo.name);
            marvelUIManager.SetHistoryText(currentARObject.GetComponent<ARData>().arCharacterInfo.wiki);
            marvelUIManager.SetPowerGridImage(currentARObject.GetComponent<ARData>().arCharacterInfo.powerGrid);
        }
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        Debug.Log("Marvel AR OnTrackingLost");
        if(marvelARObject != null && tracking == true) {
            // Debug.Log("trackingGameObject: " + gameObject.transform.GetChild(0).gameObject /*base.mTrackableBehaviour.gameObject*/);
            GameObject currentARObject = gameObject.transform.GetChild(0).gameObject;
            marvelARObject.SpawnARObject(currentARObject);
        }
        tracking = false;
    }
}