Приложение для службы доставки.
Во вкладке "Добавить заказ можно добавить новый заказ"
![image](https://github.com/user-attachments/assets/9db9afe2-2c5e-4a5e-ad95-849934d373c4)
Во вкладке "Фильтры заказов" можно отфильтровать заказы по определенному временому промежутку, а так-же по району доставки.
В случае ввода названия райлна "ALL" (регистр не имеет значения), будут выбраны все заказы
![image](https://github.com/user-attachments/assets/4d5631de-ea62-465f-b363-3688f3d7ca22)
Так-же, все заказы без фильтров находятся во вкладке "Все заказы"
Во вкладке "Начать работу" можно выбрать район доставке, после чего будет сформулирован список заказов для выбранного района и сохранен в таблицу с заказами в доставки (InDelivery)
![image](https://github.com/user-attachments/assets/47a5347f-cd98-44e7-a75b-6bda632f6978)

Все данные хранятся в базе данных MsSQL DeliveryApp. 
Для подключения к базе данных используется строка подключения:
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DeliveryApp;Trusted_Connection=True;MultipleActiveResultSets=true"
Все таблицы и саму базу данных создает Entity Framework самостоятельно. Необходимо только наличие MsSql.
