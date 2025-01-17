using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class LogoutScript : MonoBehaviour
{
    public void Logout()
    {
        // Appelle PlayFab pour se déconnecter
        PlayFabClientAPI.ForgetAllCredentials();
        Debug.Log("Utilisateur déconnecté avec succès.");
    
        // Optionnel : redirige l'utilisateur vers l'écran de connexion
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
