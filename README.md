### "Gastro" ruoantilausjärjestelmä

###### Järjestelmää hyödynnetään ravintolassa pöytäkohtaisesti, jolloin asiakkaat pystyvät tekemään tilauksia erikseen jokaisesta pöydästä suoraan pöytään. Tilauksen pohjan logiikkana on käytetty 3-numeroista pöytäkohtaista koodia, joka lukee ravintolan pöydässä. Tämän koodin perusteella asiakas pääsee tekemään tilausta, ja valitsemaan haluamansa tuotteet ostoskoriin. Pöytäkoodin yhteydessä asiakkaalle luodaan järjestelmässä myös henkilökohtainen asiakasnumero, jonka perusteella asiakkaan tilaamat tuotteet lisätään tietokantaan, ja tuodaan esiin ostoskorissa. 

###### Ostoskorista tuotteet lähetetään eteenpäin ns. henkiökunnan puolelle, josta tilauksia pääsee seuraamaan kahdesta eri paikkaa. Ensin tilaus lähetetään keittiöön, josta keittiön henkilökunta pystyy merkitsemään tilauksen valmiiksi. Kun tilaus on keittiön puolella merkitty valmiiksi, siirtyy tilaus laskutuspuolelle. Laskutuspuolelta laskun maksamisen jälkeen pystytään myös merkitsemään tilaus kokonaan käsitellyksi, jolloin tietokantaan päivittyy tilaukselle status "closed", ja tilaus on käsitelty loppuun. 

### Lataa frontend

###### Frontend: Angular, TypeScript
###### Frontend https://github.com/elinasylvia/GastroBar-Saimaa---sovellus.git + npm install > ng serve --o

### Backend / GastroAPI, lataa backend

###### Backend järjestelmä hoitaa järjestelmän GET, POST, PUT ja DELETE kutsut
###### Backend: Visual Studio: C# & .NET, ja tietokantana käytetään paikallista Microsoft SQL Serveriä

###### https://github.com/ellu563/GastroAPI.git + npm install > (lue seuraavat ohjeet ennen projektin käynnistämistä)

### Backend ohjeet: Microsoft SQL Server Management Studio

###### Tarkistetaan ensin tietokanta asetukset, jotta saadaan backend toimintaan
###### Avaa Microsoft SQL Server Management Studio ja tarkasta avatessasi ohjelmaa oman lokaalin serverisi nimi: localhost vai localhost\SQLEXPRESS
###### Mikäli serverisi nimi on SQL studiossa "localhost" (tai mahdollisesti oman koneen nimi) > Visual Studio > projektin appsetting.json > vaihda "ConnectionStrings" serverin nimeksi pelkkä localhost
###### Mikäli serverisi nimi on SQL studiossa "localhost\SQLEXPRESS" > saat projektin käyntiin suoraan
##### Nyt voit käynnistää backend projektin Visual Studiossa: PLAY

###### Kun olet saanut backendin käyntiin ja selaimesi on auennut näkymään "[]", tarkasta onko tietokantaan SQL Studiossa ilmestynyt GASTRODB niminen tietokanta, jossa on taulut: Items, Baskets, Orders & Products

### Tiedon lisääminen tietokantaan POSTMAN -ohjelmaa käyttäen

###### Kantaan halutaan lisätä kaksi tuotetta, jotta voidaan testata miten ohjelma toimii
###### Tuotteet ovat tässä tapauksessa: Hampurilainen & Olut

###### Tee POSTMAN ohjelmalla kaksi erillistä POST lähetystä osoitteeseen: https://localhost:7011/api/items 
 {
 "name": "Hampurilainen",
 "price": "10.00",
 "alv":"14",
 "calories": "560",
 "description": "Hampurilainen, ranskalaiset ja aioli.",
 "image": "https://images.unsplash.com/photo-1600688640154-9619e002df30?ixlib=rb4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=
627&q=80"
 }
 
 {
 "name": "Olut",
 "price": "12.00",
 "alv":"24",
 "calories": "660",
 "description": "Mallasolut.",
 "image": "https://images.unsplash.com/photo-1567696911980-2eed69a46042?ixlib=rb4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=
387&q=80"
 }
 
 ###### Jos saat vastaukseksi 200 OK, ovat lähetykset menneet oikein tietokantaan, voit tarkastaa asian myös suoraan SQL studiosta "Items" kokoelmasta
 
 ### Projektin ajaminen
 
 ###### Projektia ajetaan tästä eteenpäin laittamalla ensin backend käyntiin Visual Studiossa, ja tämän jälkeen frontend Visual Studio Codessa
 
 ### Ohjeet sivulla navigoimiseen ja käyttöliittymän käyttöön
 
 ###### Alussa kysytään pöytäkohtaista koodia, joka lukee ravintolan pöydässä valmiina, esim. "234"
 ###### Syötä oikea koodi input kenttään > ja napista painamalla pääset eteenpäin tilaamaan, tässä vaiheessa sinulle luodaan järjestelmässä myös yksilöity asiakasnumero, jolle tilaus tehdään
 ###### Valitse koriin hampurilainen ja/tai olut, ja mene ostoskoriin
 ###### Pystyt ostoskorissa vielä poistamaan tuotteen, jota et halua mukaan vahvistettuun tilaukseen 
 ###### Ostoskoriin haetaan tilaamasi tuotteet alussa luodun asiakasnumeron perusteella 
 ###### Kun tilauksesi on valmis, lähetä se eteenpäin käsiteltäväksi vahvistamalla tilaus > tässä vaiheessa tilaukselle myös luodaan status: OPEN
 ###### Näet kaikki avoinna olevat tilaukset localhost:*portti*/staff-orders, johon haetaan kaikki tilaukset pöytien perusteella, joissa status: OPEN
 ###### Kun tilaus on käsitelty esim. keittiön puolesta, koko tilaus voidaan checkata valmiiksi nappulaa painamalla, jolloin tilauksen statukseksi vaihdetaan: BILLING
 ###### Laskutus osiossa: localhost:*portti*/billing, nähdään kaikki tilaukset joiden status on: BILLING
 ###### Kun lasku halutaan merkata maksetuksi, ja poistaa se sivulta, painetaan napista se valmiiksi ja täten muunnetaan sen status: CLOSED
 
 ##### Pystyt seuraamaan ohjelman toimintaa suoraan tietokannasta
 ###### Items kokoelma > näet tietokannassa valmiina olevat tuotteet
 ###### Basket kokoelma > näet kaikki ostoskorissa olevat tuotteet ja kenelle tuotteet kuuluvat, mm. asiakasnumero
 ###### Orders kokoelma > näet vahvistetut tilaukset
 ###### Products kokoelma > tilauksen (Orders) mukana lähetetyt tuotteet
 
 ### Huomioitavia asioita
 
 ###### Tilauksen tekeminen ja ostoskorin näkeminen toimii nyt vain jos pysyt pöytäkoodin kysymisen jälkeen samassa istunnossa, eli päivittäessä (refresh) sivua joudut navigoimaan alkuun eli pöytäkoodin kysymiseen uudelleen
