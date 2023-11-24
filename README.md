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

