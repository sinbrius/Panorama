# 🌍 HaritaWeb - 360° Panorama ve Harita Yönetim Portalı

HaritaWeb; mahalle, lokasyon ve 360 derece panoramik görüntülerin hotspot (etkileşim noktaları) ile zenginleştirilerek harita üzerinde interaktif bir şekilde sunulmasını ve yönetilmesini sağlayan çok katmanlı bir web uygulamasıdır.

---

## 🚀 Özellikler

* **🗺️ İnteraktif Harita Yönetimi:** Mahalle, kategori ve lokasyon bazlı harita işaretleme ve filtreleme.
* **📸 360° Panorama Entegrasyonu:** Koordinat bazlı panoramik görüntüleme ve görüntüler arası hotspot geçişleri.
* **🛡️ Gelişmiş Yönetim Paneli (Admin Area):** Kategori, mahalle, lokasyon ve panorama kayıtlarını dinamik yönetme.
* **⚡ Performans & Önbellekleme:** Statik dosya optimizasyonları ve cache yönetimi.

---

## 📸 Demo & Ekran Görüntüleri

<div align="center">

### 🗺️ Harita ve 360° Panorama Görünümü
<!-- GIF veya ana ekran görüntüsü -->
<img src="assets/demo5.gif" alt="HaritaWeb Demo" width="850"/>

## 🛠️ Kullanılan Teknolojiler & Mimari

Proje **N-Tier Architecture (Çok Katmanlı Mimari)** prensiplerine uygun olarak geliştirilmiştir:

* **Çatı:** .NET 8 (ASP.NET Core MVC)
* **ORM:** Entity Framework Core
* **Veritabanı:** MSSQL / SQLite
* **Bağımlılık Yönetimi:** Scrutor (Assembly Scanning ile Dependency Injection)
* **Veri Eşleme:** AutoMapper
* **Ön Yüz:** HTML5, CSS3, JavaScript, Bootstrap

### Katman Yapısı
```text
HaritaProjesi/
├── HaritaWeb.Entities/       # Veritabanı model ve varlıkları
├── HaritaWeb.Repositories/   # Veri erişim katmanı ve DbContext
├── HaritaWeb.Services/       # İş kuralları ve servis yöneticileri
└── HaritaWeb.UI/             # MVC Presentation katmanı, Areas & View bileşenleri
