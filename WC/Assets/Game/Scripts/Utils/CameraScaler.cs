using UnityEngine;

namespace WC
{
    [RequireComponent(typeof(Camera))]
    public class CameraScaler : MonoBehaviour
    {
        [SerializeField] private Vector2Int _targetAspectRatio = new Vector2Int(9, 16);
        [SerializeField, Range(0, 1)] private float _widthOrHeight = 0f;

        private Camera _camera;
    
        private float _originalOrthographicSize;
        private float _targetAspect;

        private float _verticalFov;
        private float _horizontalFov;

        private Vector2Int _resolution;

        private void Awake()
        {
            _camera = GetComponent<Camera>();

            InitializeScales();
        }
    
        private void InitializeScales()
        {
            _resolution = new Vector2Int(0, 0);
        
            _originalOrthographicSize = _camera.orthographicSize;

            _targetAspect = (float)_targetAspectRatio.x / _targetAspectRatio.y;

            _verticalFov = _camera.fieldOfView;
            _horizontalFov = ConvertFov(_verticalFov, 1 / _targetAspect);
        }

        private void Update()
        {
            if (_resolution.x == Screen.width && _resolution.y == Screen.height)
            {
                return;
            }
            _resolution.x = Screen.width;
            _resolution.y = Screen.height;
        
            if (_camera.orthographic)
            {
                float currentWidthSize = _originalOrthographicSize * (_targetAspect / _camera.aspect);
                _camera.orthographicSize = Mathf.Lerp(currentWidthSize, _originalOrthographicSize, _widthOrHeight);
            }
            else
            {
                float currentVerticalFov = ConvertFov(_horizontalFov, _camera.aspect);
                _camera.fieldOfView = Mathf.Lerp(currentVerticalFov, _verticalFov, _widthOrHeight);
            }
        }

        private float ConvertFov(float fovInDeg, float aspectRatio)
        {
            float fovInRads = fovInDeg * Mathf.Deg2Rad;

            float convertedFovInRads = 2f * Mathf.Atan(Mathf.Tan(fovInRads / 2f) / aspectRatio);

            return convertedFovInRads * Mathf.Rad2Deg;
        }
    }
}
