# yaftech.auth
.Net Core Identity'nin implementasyonu olacak bir proje. Identity implementasyonu için adım adım ne yapılması gerektiği anlatılacaktır.

# Bilinmesi gereken temel kavramlar 
Authentication : Sistem, kullanıcının tanımlanıp tanımlanmadığını bu aşamada yapmaktadır.

Authorization : Tanımlı olan kullanıcının, nerelere yetkisi olduğunun kontrolü yapılan aşamadır.

Claims : Sistemde tanımlı olan kullanıcının demografik bilgilerinin tutulduğu alandır; username, password, email etc.

JWT : Web uygulamaları için güvenli bir yetkilendirme yöntemidir. Token şeklinde kullanıcı yetkilendirme bilgilerini, uygulamalar arası güvenli bir şekilde kullanılmasını sağlar.

# Peki JWT süreci nasıl işleyecek? 
Bir token oluşturulması adına, kullanıcıya örnek olarak bir login endpointi verilir, kullanıcı demografik bilgileri ile giriş yaptığı anda sistemde kayıtlı olup olmadığı kontrol edilir. Eğer kullanıcı var ise  bilgilerinin şifreli bir şekilde kullanılması tüm uygulama içerisinde kontrol edilmesi, rol bazlı olarak nerelere ulaşabileceği gibi yetkilere bakmak adına Token bilgisini oluştururuz.

Temel bilgileri edindiğimize göre artık implementasyona geçebiliriz. Oluşturacağım tüm uygulamalarda ortak bir auth mekanizması kullanmak istediğim için projeme genel bir isim veriyorum, haliyle herhangi bir business kodlamadan direkt olarak Identity implementasyonunu gerçekleştireceğim.

# Proje oluşturma süreci
.Net 7 ile boş bir proje açarak içerisine bir API projesi ve Data adında class library ekliyorum. Süreç içerisinde database olarak MsSql, ORM olarak ise EntityFramework kullanacağım.

API projesine eklenmesi gereken NuGet paketler;

* Microsoft.EntityFrameworkCore.Design
* Microsoft.AspNetCore.Authentication.JwtBearer 

Data library eklenmesi gerekn NuGet paketler;

* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.AspNetCore.Identity.EntityFrameworkCore

# AppSettings konfigürasyonu
  "ConnectionStrings": {
    "MsSql": ""
  },
  "JWT": {
    "ValidAudience": "http://localhost:5207",
    "ValidIssuer": "http://localhost:5207",
    "Secret": "3a4f8656e0298c7a8f6b1d0e2c5a971b2d7e940d8254a81f0cf72155abcf1a47"
  }

Yukarıda görmüş olduğunuz değerleri appsettings'e ekleyelim; Connection string database için orası sizlere kalmış. JWT alanında üç alan var; ValidAudience üretilecek olan JWT token hangi kitle için geçerli? ilgili projenizin URL bilgilerini verebilirsiniz, ValidIssuer ise JWT tokenin hangi proje tarafından oluştuğunu gösteren alandır, Secret alanı JWT'yi doğrulamak için kullanılır,  proje özelinde saklanmalı bu bilgi paylaşılmamalıdır. Üretmek için basit bir c# programı yazabilirsiniz.

coming soon:)
