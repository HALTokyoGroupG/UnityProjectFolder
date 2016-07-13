using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageEffects : MonoBehaviour
{

	public bool Bulge = false;
	public float fBulgeScale = 0.03f;
	public float fBulgeRate = 0.05f;
	private float fScale;

	public bool Flash = false;
	public float fFlashRate = 10f;

	private float fTheta = 0;
	private Image image;
	private Color originalCol;

	//==============================
	// 初期化処理
	//==============================
	void Start()
	{
		image = GetComponent<Image>();
		originalCol = image.color;
		fScale = transform.localScale.y;
	}

	//==============================
	// 初期化処理
	//==============================
	void Update()
	{
		if (Bulge)
		{
			float fWork = fScale + (Mathf.Sin(fTheta) * fBulgeScale);
			transform.localScale = new Vector3(fWork, fWork, 1f);
			fTheta += fBulgeRate;
		}

		if (Flash)
		{
			Color color = originalCol;
			int nFlicker = (int)(fTheta * fFlashRate) % 2;

			color.a = nFlicker;

			image.color = color;
			fTheta += Time.deltaTime;
		}

		fTheta = Mathf.Repeat(fTheta, Mathf.PI * 2);
	}
}
