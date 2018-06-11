using UnityEngine;
using System.Collections;
using Cephalon9;

namespace Cephalon9{
	public class PlayerWeapon : MonoBehaviour {

		[Header("Components")]
		[SerializeField]Transform area;
		[SerializeField]Transform spawnPoint;
		[SerializeField]private AudioSource aSource;

		[Header("Ammo")]
		[SerializeField]private GameObject bullet;
		[SerializeField]private GameObject grenade;

		private PlayerController plr;
		private bool grenadeMode=false;
		private GameObject activeBullet;
		private bool canShoot=true, canThrow=true;

		[Header("properties")]
		[SerializeField]private float cooldown;

		[Header("Audio Clips")]
		[SerializeField]private AudioClip elecBullet;

		void Start () {
			plr = GetComponent<PlayerController> ();
			activeBullet = bullet;
			aSource = GetComponent<AudioSource> ();
		}

		void Update () {
			if (Input.GetMouseButton (1)) {
				grenadeMode = true;
				Vector2 tarPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				area.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 ((tarPos.y - area.position.y), (tarPos.x - area.position.x)) * Mathf.Rad2Deg);
				plr.right = !(area.rotation.eulerAngles.z > 90 && area.rotation.eulerAngles.z < 270);
			}
		}

		public IEnumerator shoot(){
			if (!canShoot)
				yield break;
			if (plr.right)
				area.rotation = Quaternion.identity;
			else
				area.rotation = Quaternion.Euler (0, 0, 180);
			
			plr.anim.SetTrigger ("fire");
			yield return new WaitForSeconds (0.3f);
			GameObject b = Instantiate (activeBullet, (Vector2)spawnPoint.transform.position, Quaternion.identity);
			b.GetComponent<Bullet> ().setDirection (!plr.right);
			aSource.PlayOneShot (elecBullet,1);
			StartCoroutine(shootCooldown());
		}

		public IEnumerator launchGrenade(){
			if (!canThrow)
				yield break;
			Vector2 tarPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			plr.anim.SetTrigger ("throw");
			yield return new WaitForSeconds (0.8f);
			GameObject g = Instantiate (grenade, (Vector2)spawnPoint.transform.position, Quaternion.identity);
			g.GetComponent<Rigidbody2D> ().AddForce ((tarPos - (Vector2)g.transform.position),ForceMode2D.Impulse);
			grenadeMode=false;
			StartCoroutine(throwCooldown());
		}

		private IEnumerator throwCooldown(){
			canThrow = false;
			yield return new WaitForSeconds(cooldown);
			canThrow = true;
		}

		private IEnumerator shootCooldown(){
			canThrow = false;
			yield return new WaitForSeconds(cooldown);
			canThrow = true;
		}

	}
}