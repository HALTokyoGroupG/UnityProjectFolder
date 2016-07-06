using UnityEngine;
using System;
using System.Collections;


public class Backdrop : MonoBehaviour
{
	public GameObject RightTrigger;
	public GameObject LeftTrigger;

	//[HideInInspector]
	public int nLimitRight = 5;
	//[HideInInspector]
	public int nLimitLeft = -5;

	public GameObject player;
	public float FadeRate = 0.1f;
	public SpriteRenderer Fader;
	private bool bFadeOut = false;
	private bool bFadeIn = false;
	private Color col = new Color(0f, 0f, 0f, 0f);
	private LocalMove localmove;
	private bool bRightSide = true;
	[HideInInspector]
	public enum MVSwitch
	{
		MVNONE = 0,
		MVRIGHT,
		MVLEFT,
		MVUP,
		MVDOWN,
		MVIN
	};
	private MVSwitch moveSwitch = MVSwitch.MVNONE;

	//==============================
	// 初期化処理
	//==============================
	void Awake()
	{
		localmove = GameManager.instance.GetComponent<LocalMove>();
	}

	//==============================
	// 更新処理
	//==============================
	void Update()
	{
		if (bFadeOut)
		{
			col.a += FadeRate;

			if (col.a > 1f)
			{
				bFadeOut = false;
				Vector3 posStore = transform.position;
				GetComponentInParent<ExplorationView>().Scenery.GetComponent<SceneryScript>().DecodeSceneryData();
				Vector3 pos = player.transform.position;
				if (bRightSide)//consider switch or direct position instead of flag for when including rooms and move flags
				{
					pos.x = LeftTrigger.transform.position.x + 1.0f;
					posStore.x = -nLimitLeft;
				}
				else
				{
					pos.x = RightTrigger.transform.position.x - 1.0f;
					posStore.x = -nLimitRight;
				}
				player.transform.position = pos;
				transform.position = posStore;
				bFadeIn = true;
			}
			Fader.color = col;
		}
		else if (bFadeIn)
		{
			col.a -= FadeRate;

			if (col.a < 0f)
			{
				bFadeIn = false;
			}
			Fader.color = col;
		}
		else
		{
			////////// プレイヤーの動き //////////
			Vector3 pos = transform.position;

			if (!localmove.LimitHit())
			{
				pos.x += localmove.GetMovement();
			}

			if (-pos.x > nLimitRight)
			{
				localmove.SetLimitFlag(true);
				pos.x = -nLimitRight;
			}
			if (-pos.x < nLimitLeft)
			{
				localmove.SetLimitFlag(true);
				pos.x = -nLimitLeft;
			}

			transform.position = pos;
		}
	}

	//==============================
	// 初期化処理
	//==============================
	public void FadeOutMove(bool rightside)
	{
		bFadeOut = true;
		bRightSide = rightside;
	}

	public void FadeOutMove(MVSwitch mvSwitch)
	{
		bFadeOut = true;
		moveSwitch = mvSwitch;
	}

}
