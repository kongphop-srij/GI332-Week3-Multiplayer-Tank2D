using UnityEngine;
using TMPro;
using Unity.Collections;
using Unity.Netcode;

public class PlayerNameDisplay : NetworkBehaviour
{
    [SerializeField] private TankPlayer player;
    [SerializeField] private TMP_Text playerNameText;

    public override void OnNetworkSpawn()
    {
        HandlePlayerNameChanged(default, player.PlayerName.Value);
        player.PlayerName.OnValueChanged += HandlePlayerNameChanged;
    }

    private void HandlePlayerNameChanged(FixedString32Bytes oldName, FixedString32Bytes newName)
    {
        playerNameText.text = newName.ToString();
    }
    public override void OnNetworkDespawn()
    {
        player.PlayerName.OnValueChanged -= HandlePlayerNameChanged;
    }
}
