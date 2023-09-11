using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

 //metodo para da load na cena selecionada pelo seu numero   
 public void LoadScene(int indexScene){
    SceneManager.LoadSceneAsync(indexScene);

 }
 //metodo para sair do jogo
 public void ExitGame(){
    Application.Quit();

 }
}
