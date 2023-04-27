using UnityEngine;

namespace PlayerControls
{
    public class PlayerController : MonoBehaviour
    {
        //Oyuncu sabit hızla ileri gidecek-- Movement speed değişkeni + zaman ilerledikçe artan hız(Time.___) + 
        // A-D ve sağ sol ok tuşları karaktere addforce ile sağa veya sola kuvvet ekleyecek -addforce.vector3 right - left
        //Engele çarpınca engel siyah olsun -- GetComponent
        //Engele çarpınca oyun bitsin (tag kontolüyle varsa oyun durdurma kodu yoksa movement speed sıfıra indir ya da iskinematic true yap)
        //Gameplay 1 dakika
        //Setting Default Movement Speed 
        [SerializeField] private float movementSpeed;
        [SerializeField] private float speedIncrease;
    }
}
