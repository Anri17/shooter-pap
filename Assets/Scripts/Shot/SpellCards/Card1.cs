using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card1 : SpellCard
{
    Coroutine spellCardCoroutine;

    [SerializeField] _Bullet bullet1;

    private void Start()
    {
        spellCardCoroutine = StartCoroutine(PlaySpellCard());
    }

    public override IEnumerator PlaySpellCard()
    {
        while (true)
        {
            StartCoroutine(MoveToDestination(new Vector3(2, 4, 0), 1f));
            yield return new WaitForSeconds(1f);
            fire();
            yield return new WaitForSeconds(1f);
            StartCoroutine(MoveToDestination(new Vector3(-10, 6, 0), 1f));
            yield return new WaitForSeconds(1f);
            fire();
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator MoveToDestination(Vector3 destination, float time)
    {
        print("moving");
        float t = 0;
        Vector3 startPosition = transform.position;
        while (transform.position != destination)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            yield return null;
        }

        yield return null;
    }

    void fire()
    {
        int x = 10;
        float angle = 0;
        float angleIncreaseRation = 360 / x;
        for (int i = 0; i < x; i++)
        {
            _Bullet bullet = Instantiate(bullet1, transform.position, Quaternion.identity);
            bullet.Speed = 40f;
            bullet.Angle = angle;
            angle += angleIncreaseRation;
        }
    }

    public void StopSpellCard()
    {
        StopCoroutine(spellCardCoroutine);
    }
}
