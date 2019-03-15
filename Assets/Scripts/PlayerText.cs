using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Tmptxt;
    public GameObject Box;
   

   

    public IEnumerator print(string text, float time, bool clear = true, bool typewriter = true)
    {
        Box.SetActive(true);
        if (typewriter)
        {
            Tmptxt.ForceMeshUpdate();
            int currentCharacter = 0;
            int textf = text.Length + 1;
            Tmptxt.text = text;
            Tmptxt.color = new Color32(0, 0, 0, 255);
            TMP_TextInfo textInfo = Tmptxt.textInfo;
            Color32[] newVertexColors;
            Color32 c0 = Tmptxt.color;
            int characterCount = textInfo.characterCount;
            while (currentCharacter < characterCount + 1)
            {
                
                int materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
                newVertexColors = textInfo.meshInfo[materialIndex].colors32;
                int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;
                c0 = new Color32(255, 255, 255, 255);

                newVertexColors[vertexIndex + 0] = c0;
                newVertexColors[vertexIndex + 1] = c0;
                newVertexColors[vertexIndex + 2] = c0;
                newVertexColors[vertexIndex + 3] = c0;
                Tmptxt.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
                currentCharacter = (currentCharacter + 1);

                yield return new WaitForSeconds(0.05f);
                Debug.Log(characterCount);
            }
            /*for (int x = 0; x < textf; x++)
            {
                string display = text.Substring(0, x);
                Tmptxt.text = display;
                Tmptxt.color = new Color32(51, 51, 255, 255);
                yield return new WaitForSeconds(.065f);
            }*/
        }
        else
        {
            Tmptxt.text = text;
        }
        if (clear)
        {
            yield return new WaitForSeconds(time);
            Box.SetActive(false);
            Tmptxt.text = " ";
        }

    }

    }
