using UnityEngine;
using TMPro;

public class TextFontChanger : MonoBehaviour
{
	[SerializeField] TMP_FontAsset font;
	private TMP_Text[] textElements;

	public void UpdateFontOnAllText()
	{
        textElements = FindObjectsOfType<TMP_Text>();

		foreach (TMP_Text textElement in textElements)
		{
			textElement.font = font;
		}
	}
}