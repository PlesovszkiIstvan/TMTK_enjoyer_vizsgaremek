<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Mail;
use App\Mail\Email;

class EmailController extends Controller
{
    public function sendVisszaIgazoloMail($code, $email){
        $content = [
<<<<<<< HEAD
            "subject" => "Visszaigazoló kód.",
            "title" => "Visszaigazoló kód.",
            "code" => $code,
            "view" => 'mail'
        ];

        Mail::to( $email )->send( new Email($content) );
    }

    public function sendRendelesMail($rendelt_termekek, $rendeles_ideje, $megjegyzes, $felhasznalo_nev, $szalitasi_cime, $vasarlo_telefonszama, $email){

        $teljesar = 0;

        foreach ($rendelt_termekek as $termek) {
            $egytermekar = $termek->darabszam*$termek->egyseg_ar;
            $teljesar = $teljesar+$egytermekar;
        }

        $content = [
            "subject" => "Isabike Rendeles",
            "title" => "Köszönjük a rendelést!",
            "rendeles_ideje" => $rendeles_ideje,
            "megjegyzes" => $megjegyzes,
            "felhasznalo_nev" => $felhasznalo_nev,
            "szalitasi_cime" => $szalitasi_cime,
            "vasarlo_telefonszama" => $vasarlo_telefonszama,
            "rendelt_termekek" => $rendelt_termekek,
            "osszesitet_ar" => $teljesar,
            "view" => 'rendeles'
        ];

        Mail::to( $email )->send( new Email($content) );
    }

    public function asd($email){
        $content = [
            "subject" => "Visza igazolo kod",
=======
>>>>>>> 35691a7f6a53f4362a94f28f74e382f56e4cfaa4
            "title" => "Visza Igazolo kod",
            "code" => $code
        ];

        Mail::to( $email )->send( new Email($content) );
    }
}
