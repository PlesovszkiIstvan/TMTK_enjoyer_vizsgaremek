# ISABIKE                         
## _Dokumentáció_


**felhasznált technologiák**

- Laravel\PHP
- mySQL Workbench
- Accsess

**Konzulens**

- Kaczur Sándor [https://it-tanfolyam.hu/]

**Tartalomjegyzék**

- 2.oldal -> x.oldal [követelmények feltárása]

- x.oldal -> y.oldal [specifikáciok]

- y.oldal -> z.oldal [tervek képei]

**Követelmények feltárása**

- [funkcionális]
> felhasználói profilok kezelése
> felhasználoi vélemények hagyása
> vásárloi statisztikák kimutatása
> boltal kapcsolatos informáciok elérése
> termékek kezelése
> termékek megjelenitése
> termékek rendelése 
> rendelések leadása 
> különbözö fizetési és szálitoi lehetöségek
> akciok létrehozása reklámozása email értesitéseken keresztül

- [nem funkcionális]
> Könnyen kezelhetö desktop admin felület
> Egyértelmü Webes vásárloi felület
> profit orientált megjelenités 
> narancssárga fö szin a Web felületen 

**Specifikációk**

A webes felületen a vásárlok fognak tudni profilba bejelentkezni csak profilal tudnak rendelni és véleményt hagyni de a termékék megnézéséhez nem szükséges felhasználoi profilt késziteni a felhsználoi profil email viszaigazolo kodal lehetséges megerösiteni és utáne teljes körüen használni minden vásárloi funkciot (rendelés leadás, vélemény hagyás) a felhasználoi profiloknak tároljuk a kosarazot termékeit és rendeléseit amiböl majd továbfejlesztési célbol statisztikákat lehet leszürni

A desktop felületen tudják majd a cég tulajdonosai a felhasználokat, kedvezményeket, termékeket, rendeléseket kezelni (hozzáadni, kilistázni, megváltoztatni, törölni) statisztikákat megjeleniteni vásárloi szokásokrol 

A kliensek pedig képes lesz külön felhasználoi profilokon keresztül elérni az adatbázist [BrowserUser], [DesktopUser] mely felhasználokhoz külön jkogosultságok lesznek hozzá rendelve amikel Tárolt eljárásokon keresztül fognak tudni CRUD müveleteket végrehajtani az adatbázison más Tárolt eljárásokon lesznek elérhetök a böngészös felhasználoknak és a asztali alkalmazás felhasználoknak

**Terverk**

> Desktop
    > UML
        ![Imgur](https://i.imgur.com/ndPYrlL.png)