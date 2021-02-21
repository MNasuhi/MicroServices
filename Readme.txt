Docker üzerinde 27017 portuna mongodb kuruldu.

Docker üzerinde 15672 portuna rabbitmq kuruldu.

Projelerin içinde bulunan appsettings.json dosyasında DatabaseSettings altında veritabanı bağlantısı için gerekli connectionstringler mevcut ve özelleştirilebilir durumda.

Docker üzerinde projenin ayağa kaldırılması için docker-compose dosyasının bulunduğu dizinde cmd açılıp docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d komutu çalıştırılmalı. Yine docker üzerinde projenin ayağa kaldırılmadan önce özelleştirilmesi(port vb. bilgilerin belirtilmesi) gibi ayarlar docker-composeöoverride.yml dosyasından yapılmalı.


