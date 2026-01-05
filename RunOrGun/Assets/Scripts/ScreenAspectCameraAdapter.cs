using UnityEngine;

public class ScreenAspectCameraAdapter : MonoBehaviour {
    private const float baseScreenAspect = 1920.0f / 1080.0f;

    private const float baseVisiblePhysicalWidth = 160.0f / 9.0f;
    private const float fieldBackgroundWidth = 124.0f / 9.0f;
    private const float fieldBackgroundHeight = 10.0f;
    private const float leftUiPanelRelativeWidth = 9.0f / 40.0f;

    private const float baseCameraOrthographicSize = fieldBackgroundHeight / 2.0f;
    private const float cameraBaseShift = -2.0f;

    private float previousScreenAspect = baseScreenAspect;

    private void Update() {
        AdaptCameraToScreen();
    }

    private void AdaptCameraToScreen() {
        var screenAspect = GetScreenAspect();
        if (AspectIsChanged()) {
            previousScreenAspect = screenAspect;

            if (ScreenIsWide()) {
                SetBaseOrthographicSizeToCamera();

                var visiblePhysicalWidth = GetVisiblePhysicalWidth();
                var cameraShift = GetCameraShift(visiblePhysicalWidth);
                if (cameraShift < 0) {
                    cameraShift = 0;
                }
                ShiftCamera(cameraShift);
            } else {
                SetBaseCameraShift();

                var visiblePhysicalHeight = GetVisiblePhysicalHeight();
                SetCameraOrthographicSize(visiblePhysicalHeight);
            }
        }

        #region
        float GetScreenAspect() => (float)Screen.width / Screen.height;
        bool AspectIsChanged() => screenAspect != previousScreenAspect;
        bool ScreenIsWide() => screenAspect > baseScreenAspect;

        void SetBaseOrthographicSizeToCamera() => Camera.main.orthographicSize = baseCameraOrthographicSize;
        float GetVisiblePhysicalWidth() => screenAspect * fieldBackgroundHeight;
        float GetCameraShift(float visiblePhysicalWidth) => fieldBackgroundWidth / 2.0f - (visiblePhysicalWidth / 2.0f - leftUiPanelRelativeWidth * visiblePhysicalWidth);
        void ShiftCamera(float cameraShift) => Camera.main.transform.position = new Vector3(-cameraShift, 0, -10);

        void SetBaseCameraShift() => Camera.main.transform.position = new Vector3(cameraBaseShift, 0, -10);
        float GetVisiblePhysicalHeight() => baseVisiblePhysicalWidth / screenAspect;
        void SetCameraOrthographicSize(float visiblePhysicalHeight) => Camera.main.orthographicSize = visiblePhysicalHeight / 2.0f;
        #endregion
    }
}
