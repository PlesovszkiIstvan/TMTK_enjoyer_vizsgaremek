<h1>{{$content[ 'title' ]}}</h1>
<h2>Kedves {{$content[ 'felhasznalo_nev']}}, köszönjük a rendelését.</h2>
<p>Rendelésed ideje: {{$content[ 'rendeles_ideje' ]}}</p>
<p>Szálitási cím: {{$content[ 'szalitasi_cime' ]}}</p>
<p>Megadott telefonszám: <span style="color:blue;">{{$content[ 'vasarlo_telefonszama' ]}}</span></p>
<p>Megjegyzésed: {{$content[ 'megjegyzes' ]}}</p>
<p style="color:orange; font-weight: bold;">Rendelt termékek:</p>
@foreach($content[ 'rendelt_termekek' ] as $termek)
    <div style="border-color: black; border-style: solid; border-width: 4px; border-radius: 10px; display: inline-block;">
        <p style="padding-left: 5px; padding-right: 5px;">Termék neve: {{$termek->termek_nev}}</p>
        <p style="padding-left: 5px; padding-right: 5px;">Mennyiség: {{$termek->darabszam}}</p>
        <p style="padding-left: 5px; padding-right: 5px;">Ár: {{$termek->egyseg_ar}}</p>
        <p></p>
    </div>
@endforeach
<p style="font-size: 30px;">Összesitet ár: <span style="color:orange; font-weight: bold;">{{$content[ 'osszesitet_ar' ]}}</span></p>






