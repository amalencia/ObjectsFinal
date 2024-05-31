using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class ShipPlayerParent : CharacterAbstract
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private int numOfNukes;
    [SerializeField] private GameObject NukeExplode;

    [SerializeField] protected Camera mainCamera;
    protected float specialWeaponTimer;
    [SerializeField] protected SpecialTimer specialImageTimer;



    public UnityEvent<int> OnHealthChanged;

    protected override void Start()
    {
        base.Start();
        mainCamera = FindObjectOfType<Camera>();
        _weaponBehaviour = new BaseWeapon(_bulletReference);
        uiManager = FindObjectOfType<UIManager>();
        uiManager.UpdateHealthUI(_health.GetCurrentHealth());
        uiManager.UpdateArmorUI(_armor.CurrentArmor());
    }

    public override void SetWeaponBehaviour()
    {
        
    }

    protected void Update()
    {
        if (specialWeaponTimer > 0)
        {
            specialWeaponTimer -= Time.deltaTime;
            GetSpecialTimerPosition();

        }
    }

    public virtual Vector3 GetSpecialTimerPosition()
    {
        Vector3 vector3 = mainCamera.WorldToScreenPoint(transform.position);
        return vector3;
    }

    public override void Move(Vector2 direction, float angle)
    {
        _rigidBody.AddForce(_speed.CurrentSpeed() * Time.deltaTime * 500f * direction);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Die()
    {
        Destroy(gameObject);
        GameManager.singleton.EndGame();
    }

    public override void Attack()
    {
        _weaponBehaviour.WeaponBehaviour(transform.position, transform.rotation, _power.CurrentPower(), "Enemy");
    }

    public override void ReceiveDamage(int damage)
    {
        base.ReceiveDamage(damage);
        //Debug.Log("Player health now: " + _health.GetCurrentHealth());
        uiManager.UpdateHealthUI(_health.GetCurrentHealth());
        //Debug.Log("Player armor now: " + _armor.CurrentArmor());
        uiManager.UpdateArmorUI(_armor.CurrentArmor());
        OnHealthChanged.Invoke(_health.GetCurrentHealth());
    }

    protected override IEnumerator ArmorRegen()
    {
        while (_armor.CurrentArmor() < _armor.MaxArmor())
        {
            yield return new WaitForSeconds(1f);

            _armor.ArmorRegen();
            uiManager.UpdateArmorUI(_armor.CurrentArmor());
        }
    }

    public virtual void IncreaseNukes()
    {
        numOfNukes++;
        uiManager.UpdateNukeUI(numOfNukes);
    }

    public virtual void Nuke()
    {
        if (numOfNukes > 0)
        {
            numOfNukes--;
            uiManager.UpdateNukeUI(numOfNukes);
            NukeExplode.SetActive(true);
            Invoke("DisableNuke", 1f);
        }
    }

    public virtual void DisableNuke()
    {
        NukeExplode.SetActive(false);
    }

    public virtual void SpecialWeapon()
    {

    }
}
