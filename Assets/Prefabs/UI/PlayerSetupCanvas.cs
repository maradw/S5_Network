using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerSetupCanvas : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private TextMeshProUGUI _characterNameText;
    [SerializeField] private Button _nextCharacterButton;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private string[] _characterNames; // <-- aquí pondrás los nombres en el inspector.

    [SerializeField] private GameObject _characterSelectionCanvas; // Canvas de selección
    [SerializeField] private GameObject _roomCanvas; // Canvas de crear/unirse a room

    private int _currentCharacterIndex = 0;

    private void Start()
    {
        _nextCharacterButton.onClick.AddListener(NextCharacter);
        _confirmButton.onClick.AddListener(ConfirmSelection);

        UpdateCharacterName();
    }

    private void NextCharacter()
    {
        _currentCharacterIndex = (_currentCharacterIndex + 1) % _characterNames.Length;
        UpdateCharacterName();
    }

    private void UpdateCharacterName()
    {
        _characterNameText.text = _characterNames[_currentCharacterIndex];
    }

    private void ConfirmSelection()
    {
        string playerName = _nameInputField.text;

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Debes poner un nombre antes de continuar.");
            return;
        }

        // Guardamos nombre y personaje
        PhotonNetwork.NickName = playerName;
        PlayerPrefs.SetString("CharacterSelected", _characterNames[_currentCharacterIndex]); // Puedes leerlo después si quieres saber qué personaje eligió.

        // Activar el canvas de rooms
        _characterSelectionCanvas.SetActive(false);
        _roomCanvas.SetActive(true);

        // Conectar a Photon si no estaba conectado
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
