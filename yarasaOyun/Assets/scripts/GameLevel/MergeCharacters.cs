using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeCharacters : MonoBehaviour
{
    // karakteri sürüklemek için
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragging = false;
    
    
    private void OnMouseDown()
    {
        isDragging = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }
    
    
    public int value; // Karakterin sayısal değerini saklar
    public Text valueText; // Karakter üzerindeki sayıyı gösteren UI Text

    private void Start()
    {
        // Başlangıçta UI Text'i karakterin değeri ile güncelle
        valueText.text = value.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            // Diğer karakterin Character scriptini al
            MergeCharacters otherCharacter = other.gameObject.GetComponent<MergeCharacters>();
            
            // Toplamı hesapla
            int sum = value + otherCharacter.value;
            
            // İlk karakterin değerini ve UI Text'ini güncelle
            value = sum;
            valueText.text = value.ToString();
            
            // İsteğe bağlı: Birleşme animasyonu veya efekt ekleyin
            
            // Diğer karakteri yok et
            Destroy(other.gameObject);
        }
    }
    
    
    
    
    
    
  
}
