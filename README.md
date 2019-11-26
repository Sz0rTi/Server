# Server
[WIP]

Restowy serwer ze Swaggerem do wygodniejszego testowania kontrolerów.

Należy zmienić wykomentowanie linii 9 na 10 w pliku Server/RESTServer/RESTServer/appsettings.json, a następnie w konsoli
wywołać polecenie "update-database" na projekcie docelowym "DAO".

Po tych operacjach na czystej bazie danych należy dodać przynajmniej po jednym obiekcie TaxStage (stawka vat),
Unit (jednostka miary) oraz Category (kategoria produktów).

Po wprowadzeniu tych obiektów do bazy danych można tworzyć nowe produkty (najwygodniej przez widok "Nowy produkt" w kliencie desktopowym);
W kliencie desktopowym najłatwiej jest też wystawić fakturę sprzedaży.
